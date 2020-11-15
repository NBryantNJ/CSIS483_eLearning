using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSIS483_ELearning_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CSIS483_ELearning_WebApplication.Controllers.adminControls
{
    public class adminFunctions : Controller
    {
        //-----------------------------appsettings file reference-----------------------------
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //-------------------------------Check if user has admin priveleges ----------------------------
        public bool checkAdminPrivileges(string username, string password)
        {
            try
            {
                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Open Sql connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM loginTable WHERE username = @username AND usersPassword = @password", conn);
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password; 

                    MySqlDataReader reader = cmd.ExecuteReader();
                    //Check users admin privileges
                    while(reader.Read())
                    {
                        if(reader["adminPrivileges"].ToString() == "true")
                        {
                            return true; 
                        }
                    }
                    return false; 
                }
            }
            catch(Exception e)
            {
                //If error email the developer
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("Admin Functions", "checkAdminPrileges", e.ToString());
                return false; 
            }
        }


        //----------------------------Get usernames of all users-------------------------------
        public List<string> getAllUsernames()
        {
            try
            {
                //Variables
                List<string> allUsernames = new List<string>(); 

                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Open Sql connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM loginTable ORDER BY username ASC", conn);
                    MySqlDataReader reader = cmd.ExecuteReader(); 
                    while(reader.Read())
                    {
                        allUsernames.Add(reader["username"].ToString()); 
                    }
                }
                return allUsernames; 
            }
            catch(Exception e)
            {
                EmailErrors emailErrors = new EmailErrors();
                emailErrors.autoEmailDeveloperAboutIssue("adminFunctions.cs", "getAllUsernames", e.ToString()); 
                return null; 
            }
        }


        //---------------------------Submit New Course---------------------------------------
        public bool submitNewCourse(createACourseModel[] createACourseModel)
        {
            //Create variables
            List<string> links = new List<string>();
            List<string> linkTypes = new List<string>();
            List<string> questions = new List<string>();
            List<string> option1 = new List<string>(); 
            List<string> option2 = new List<string>(); 
            List<string> option3 = new List<string>(); 
            List<string> option4= new List<string>();
            List<string> isOption1Correct = new List<string>();
            List<string> isOption2Correct = new List<string>();
            List<string> isOption3Correct = new List<string>();
            List<string> isOption4Correct = new List<string>();

            //Populate Links
            foreach (createACourseModel courseModel in createACourseModel)
            {
                if(courseModel.link != null)
                {
                    links.Add(courseModel.link);
                }
            }

            //Populate Link Types
            foreach (createACourseModel courseModel in createACourseModel)
            {
                if (courseModel.linkType != null)
                {
                    linkTypes.Add(courseModel.linkType);
                }
            }

            //Populate question data
            foreach (createACourseModel courseModel in createACourseModel)
            {
                if (courseModel.question != null)
                {
                    questions.Add(courseModel.question); 
                    option1.Add(courseModel.option1);
                    option2.Add(courseModel.option2);
                    option3.Add(courseModel.option3);
                    option4.Add(courseModel.option4);
                    isOption1Correct.Add(courseModel.isOptionCorrectOrIncorrect1);
                    isOption2Correct.Add(courseModel.isOptionCorrectOrIncorrect2);
                    isOption3Correct.Add(courseModel.isOptionCorrectOrIncorrect3);
                    isOption4Correct.Add(courseModel.isOptionCorrectOrIncorrect4);
                }
            }


            try
            {
                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Insert course name & difficulty rating
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO coursesTable (courseTitle, difficultyRating) VALUES (@courseTitle,@difficultyRating) ", conn);
                    cmd.Parameters.Add("@difficultyRating", MySqlDbType.VarChar).Value = createACourseModel[1].difficultyRating;
                    cmd.Parameters.Add("@courseTitle", MySqlDbType.VarChar).Value = createACourseModel[2].courseName;
                    cmd.ExecuteNonQuery();
                }

                //Insert Links
                int iterator = 0; 
                foreach (string link in links)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO coursesContentTable (testID, linkAddress, linkType) VALUES (@testID ,@linkAddress, @linkType) ", conn);
                        cmd.Parameters.Add("@testID", MySqlDbType.VarChar).Value = createACourseModel[2].courseName;
                        cmd.Parameters.Add("@linkAddress", MySqlDbType.VarChar).Value = link;
                        cmd.Parameters.Add("@linkType", MySqlDbType.VarChar).Value = linkTypes[iterator];
                        cmd.ExecuteNonQuery();
                        iterator++;
                    }
                }

                //Insert Questions
                iterator = 0;
                //foreach (string question in questions)
                //{
                //    using (MySqlConnection conn = new MySqlConnection(connectionString))
                //    {
                //        conn.Open();
                //        MySqlCommand cmd = new MySqlCommand("INSERT INTO coursesContentTable (testID, linkAddress, linkType) VALUES (@testID ,@linkAddress, @linkType) ", conn);
                //        cmd.Parameters.Add("@testID", MySqlDbType.VarChar).Value = createACourseModel[2].courseName;
                //        cmd.Parameters.Add("@linkAddress", MySqlDbType.VarChar).Value = link;
                //        cmd.Parameters.Add("@linkType", MySqlDbType.VarChar).Value = linkTypes[iterator];
                //        cmd.ExecuteNonQuery();
                //        iterator++;
                //    }
                //}

                return true;
            }
            catch (Exception e)
            {
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("adminFunctions.cs", "submitNewCourse", e.ToString());
                return false;
            }
        }









    }
}
