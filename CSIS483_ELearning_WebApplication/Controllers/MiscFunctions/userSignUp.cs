using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;



namespace CSIS483_ELearning_WebApplication.Controllers
{
    public class userSignUp
    {
        //appsettings file reference
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

         
        //Register new user
        public string RegisterNewUser(string firstName, string lastName, string email, string username, string password)
        {
            try
            {
                if (firstName.Length >= 2 && firstName.Length <= 12 && lastName.Length >= 2 && lastName.Length <= 12 && email.Length >= 7  && email.Length <= 35 && username.Length >= 5 && username.Length <= 12 && password.Length >= 5 && password.Length <= 12)
                {
                    //Get AWSDB info
                    var configuration = GetConfiguration();
                    string connectionString = configuration.GetConnectionString("AWSMAINDB");
                    
                    //Open connection and add user registration data
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        //Check if username exists
                        MySqlCommand cmdSearch = new MySqlCommand("SELECT COUNT(*) from loginTable WHERE username = @username",conn);
                        cmdSearch.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                        long usernameCount = (long)cmdSearch.ExecuteScalar();
                        conn.Close();

                        //If username doesn't exist
                        if (usernameCount < 1)
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("INSERT INTO loginTable (firstName, lastName, email, username, usersPassword) VALUES (@firstName, @lastName, @email, @username, @usersPassword)", conn);
                            cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
                            cmd.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = lastName;
                            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                            cmd.Parameters.Add("@usersPassword", MySqlDbType.VarChar).Value = password;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            return "username taken"; 
                        }
                    }
                    //Connection auto closed and return true
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch(Exception e)
            {
                EmailErrors emailErrors = new EmailErrors();
                emailErrors.autoEmailDeveloperAboutIssue("EmailErrors.cs", "RegisterNewUser", e.ToString()); 
                return "Fatal error: record not saved. The developer has been paged and will look into this issue";
            }
        }
        

    }
}
