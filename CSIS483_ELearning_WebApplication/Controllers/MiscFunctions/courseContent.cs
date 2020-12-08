using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Controllers.MiscFunctions
{
    public class courseContent
    {

        //-----------------------------appsettings file reference-----------------------------
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        //---------------------Populate model with course content data--------------------------
        public Models.CourseContentModel populateCourseContentModel(string username, string password, string courseID)
        {
            try
            {
                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Declare variables
                Models.CourseContentModel coursecontentmodel = new Models.CourseContentModel();
                coursecontentmodel.videoLinks = new List<string>();
                coursecontentmodel.webAndPDFLinks = new List<string>(); 

                //Open connection
                using(MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    //Confirm user is authorized to take this course
                    MySqlCommand cmdUserAuth = new MySqlCommand("SELECT COUNT(*) FROM loginTable INNER JOIN assignedCoursesTable ON assignedCoursesTable.assignedToID = @username WHERE username = @username AND userspassword = @password AND assignedCoursesTable.courseID = @courseID", conn);
                    cmdUserAuth.Parameters.Add("@username", MySqlDbType.VarChar).Value = username; 
                    cmdUserAuth.Parameters.Add("@password", MySqlDbType.VarChar).Value = password; 
                    cmdUserAuth.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                    if (int.Parse(cmdUserAuth.ExecuteScalar().ToString()) > 0)
                    {
                        //Get all course content
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM coursesContentTable INNER JOIN coursesTable ON coursesContentTable.testID = coursesTable.courseTitle WHERE coursesContentTable.testID = @courseID", conn);
                        cmd.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Loop through all course content in course. Assign to model
                        while (reader.Read())
                        {
                            coursecontentmodel.courseTitle = reader["testID"].ToString();
                            coursecontentmodel.difficultyRating = reader["difficultyRating"].ToString();
                            if (reader["linkType"].ToString() == "Video")
                            {
                                coursecontentmodel.videoLinks.Add(reader["linkAddress"].ToString());
                            }
                            else
                            {
                                coursecontentmodel.webAndPDFLinks.Add(reader["linkAddress"].ToString());
                            }
                            coursecontentmodel.notes = reader["notes"].ToString();


                        }

                        return coursecontentmodel; 
                    }
                    //If user is not assigned to course
                    else
                    {
                        return null; 
                    }
                }
            }
            catch(Exception e)
            {
                EmailErrors errors = new EmailErrors();
                errors.autoEmailDeveloperAboutIssue("courseContent.cs", "populateCourseContentModel", e.ToString());
                return null; 
            }
        }
    }
}
