using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSIS483_ELearning_WebApplication.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace CSIS483_ELearning_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult Admin()
        {
            //Return admin privileges
            AdminModel adminmodel = new AdminModel();
            adminControls.adminFunctions admincontrols = new adminControls.adminFunctions();
            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");
                string password = HttpContext.Session.GetString("password");
                adminmodel.doesUserHaveAdminPrivileges = admincontrols.checkAdminPrivileges(username, password);
            }
            else
            {
                adminmodel.doesUserHaveAdminPrivileges = false;
            }
            //Return username 
            adminControls.adminFunctions adminfunction = new adminControls.adminFunctions();
            adminmodel.allUsernames = adminfunction.getAllUsernames();

            return View(adminmodel);
        }

        //--------------------test function---------------------------
        public bool submitNewCourse(createACourseModel[] createcoursemodel)
        {
            adminControls.adminFunctions adminfunctions = new adminControls.adminFunctions();
            return adminfunctions.submitNewCourse(createcoursemodel); 
        }


        public IActionResult Support()
        {
            SessionModel sessionmodel = new SessionModel(); 
            if(HttpContext.Session.GetString("firstname") != null)
            {
                sessionmodel.firstName = HttpContext.Session.GetString("firstname"); 
                sessionmodel.lastName = HttpContext.Session.GetString("lastname"); 
                sessionmodel.email = HttpContext.Session.GetString("email"); 
                sessionmodel.username = HttpContext.Session.GetString("username");
            }
            return View(sessionmodel);
        }

        //Support page send email
        public bool sendSupportMail(string firstname, string lastname, string username, string email, string reasonForContacting, string additionalDetails)
        {
            try
            {
                //Get Credentials
                var configuration = GetConfiguration();
                string botsEmail = configuration.GetSection("data").GetSection("botsEmail").Value;
                string botsPassword = configuration.GetSection("data").GetSection("botsEmailPassword").Value;
                string developersEmail = configuration.GetSection("data").GetSection("developersEmail").Value;

                //Setup SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Credentials = new NetworkCredential(botsEmail, botsPassword);
                smtp.EnableSsl = true;
                smtp.Port = 587;

                //Create Message
                MailMessage mail = new MailMessage(botsEmail, developersEmail);
                mail.Subject = "CSIS_483 Support Request";
                mail.Body = "Name: " + firstname + " " + lastname;
                if (username != null)
                {
                    mail.Body += "\nUsername: " + username;
                }
                else
                {
                    mail.Body += "\nUsername: " + "Not listed.";
                }
                mail.Body += "\nEmail: " + email;
                if (additionalDetails != null)
                {
                    mail.Body += "\n\n\nAdditional Details: " + additionalDetails;
                }
                else
                {
                    mail.Body += "\n\n\nAdditionalDetails: Not listed.";
                }

                //Send message and return true
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                //If failed return false
                return false;
            }
        }


        //appsettings file reference
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //Sign up Page
        public IActionResult SignUp()
        {
            return View();
        }


        //Register new user
        public string registernewuser(string firstname, string lastname, string email, string username, string password)
        {
            userSignUp usersignuplogin = new userSignUp();
            string returnValue = usersignuplogin.RegisterNewUser(firstname, lastname, email, username, password);
            //Set session variables
            if (returnValue == "true")
            {
                HttpContext.Session.SetString("firstname", firstname);
                HttpContext.Session.SetString("lastname", lastname);
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("password", password);
            }
            return returnValue;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //----------------------Shared Layout Functions----------------------------------------
        //Captcha Global
        private static bool CaptchaCompletionStatus = false;

        //Login existing users
        public string loginExistingUser(string username, string password,string captcha)
        {

            //Check Captcha Status
            //If Captcha was not set
            if (CaptchaCompletionStatus == false)
            {
                MiscFunctions.LoginControls logincontrols = new MiscFunctions.LoginControls();
                CaptchaCompletionStatus = logincontrols.checkRecaptcha(captcha);
            }

            try
            {
                if (CaptchaCompletionStatus == true)
                {
                    //Get AWSDB info
                    var configuration = GetConfiguration();
                    string connectionString = configuration.GetConnectionString("AWSMAINDB");

                    //Check for user info
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM loginTable WHERE username = @username AND usersPassword = @password", conn);
                        cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                        cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                        MySqlDataReader reader = cmd.ExecuteReader();
                        string doesUserExist = "false";

                        while (reader.Read())
                        {
                            HttpContext.Session.SetString("firstname", reader["firstName"].ToString());
                            HttpContext.Session.SetString("lastname", reader["lastName"].ToString());
                            HttpContext.Session.SetString("email", reader["email"].ToString());
                            HttpContext.Session.SetString("username", reader["username"].ToString());
                            HttpContext.Session.SetString("password", reader["usersPassword"].ToString());
                            doesUserExist = "true";
                        }

                        return doesUserExist;

                    }
                }
                else
                {
                    return "Captcha Required"; 
                }

            }
            catch (Exception e)
            {
                EmailErrors emailErrors = new EmailErrors();
                emailErrors.autoEmailDeveloperAboutIssue("Home Controller", "LoginExistingUser", e.ToString());
                return "System Error";
            }



        }
    }

}
