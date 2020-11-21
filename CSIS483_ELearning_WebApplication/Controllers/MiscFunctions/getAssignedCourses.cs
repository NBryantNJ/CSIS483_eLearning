using CSIS483_ELearning_WebApplication.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Controllers.MiscFunctions
{
    public class getAssignedCourses
    {
        //-----------------------------appsettings file reference-----------------------------
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //-------------------------------Get current assigned courses----------------------------
        public List<getAssignedCoursesModel> getCurrentAssignedCourses(string username)
        {
            try
            {
                //Declare variable
                List<getAssignedCoursesModel> getAssignedCourses = new List<getAssignedCoursesModel>();

                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Get data
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM assignedCoursesTable WHERE assignedToID = @username", conn);
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        getAssignedCourses.Add(new getAssignedCoursesModel
                        {
                            assignedByID = reader["assignedByID"].ToString(),
                            assignedtoID = reader["assignedToID"].ToString(),
                            courseID = reader["courseID"].ToString()
                        });
                    }
                    return getAssignedCourses;
                }
            }
            catch (Exception e)
            {
                EmailErrors errors = new EmailErrors();
                errors.autoEmailDeveloperAboutIssue("GetAssignedCourses.cs", "getCurrentAssignedCourses", e.ToString());
                return null;
            }
        }


    }
}