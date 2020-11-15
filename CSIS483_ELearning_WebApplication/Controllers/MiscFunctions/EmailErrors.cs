using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace CSIS483_ELearning_WebApplication.Controllers
{
    public class EmailErrors
    {

        //appsettings file reference
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //Auto email developer about errors encountered
        public void autoEmailDeveloperAboutIssue(string documentLocation, string methodName, string errorMessage)
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
            mail.Subject = "Fatal Error: CSIS483_Application";
            mail.Body = "Document Location: " + documentLocation + "\n\n" + "Method Name: " + methodName + "\n\n" + "Error Message: " + errorMessage;

            //Send message and return true
            smtp.Send(mail);
        }
    }
}
