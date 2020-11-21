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
        public AdminModel checkAdminPrivileges(string username, string password)
        {
            try
            {
                //variable
                AdminModel adminmodel = new AdminModel(); 
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
                        //Check access
                        if(reader["adminPrivileges"].ToString() == "true")
                        {
                            adminmodel.doesUserHaveAdminPrivileges = true; 
                        }
                        else
                        {
                            adminmodel.doesUserHaveAdminPrivileges = false; 
                        }

                        //Check if requested access
                        if(reader["didUserRequestPrivileges"].ToString() == "true")
                        {
                            adminmodel.didUserRequestAdminPrivileges = true;
                        }
                        else
                        {
                            adminmodel.didUserRequestAdminPrivileges = false;
                        }

                    }
                    return adminmodel; 
                }
            }
            catch(Exception e)
            {
                //If error email the developer
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("Admin Functions", "checkAdminPrileges", e.ToString());
                return null; 
            }
        }


        //----------------------------User requested access-----------------------------------
        public bool requestAdminPrivileges(bool didUserRequestAccess, string username, string password)
        {
                try
                {
                    if (didUserRequestAccess == true)
                    {
                        //Get Connection String
                        var configuration = GetConfiguration();
                        string connectionString = configuration.GetConnectionString("AWSMAINDB");

                        //Update table that user requested access
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("UPDATE loginTable SET didUserRequestPrivileges = 'true' WHERE username = @username AND usersPassword = @usersPassword", conn);
                            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                            cmd.Parameters.Add("usersPassword", MySqlDbType.VarChar).Value = password;
                            cmd.ExecuteNonQuery();
                        }

                        return true;
                    }
                    else
                    {
                        return false; 
                    }
                }
            catch(Exception e)
            {
                EmailErrors errors = new EmailErrors();
                errors.autoEmailDeveloperAboutIssue("adminFunction.cs", "requestAdminPrivileges", e.ToString());
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
                foreach (string question in questions)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO coursesTestQuestionsTable (testID, questionNumber, question, answerOption1, answerOption2, answerOption3, answerOption4, isAnswerOption1Correct, isAnswerOption2Correct, isAnswerOption3Correct, isAnswerOption4Correct) VALUES (@testID ,@questionNumber, @question, @answerOption1, @answerOption2, @answerOption3, @answerOption4, @isAnswerOption1Correct, @isAnswerOption2Correct, @isAnswerOption3Correct, @isAnswerOption4Correct) ", conn);
                        cmd.Parameters.Add("@testID", MySqlDbType.VarChar).Value = createACourseModel[2].courseName;
                        cmd.Parameters.Add("@questionNumber", MySqlDbType.VarChar).Value = iterator + 1;
                        cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = question;
                        cmd.Parameters.Add("@answerOption1", MySqlDbType.VarChar).Value = option1[iterator];
                        cmd.Parameters.Add("@answerOption2", MySqlDbType.VarChar).Value = option2[iterator];
                        cmd.Parameters.Add("@answerOption3", MySqlDbType.VarChar).Value = option3[iterator];
                        cmd.Parameters.Add("@answerOption4", MySqlDbType.VarChar).Value = option4[iterator];
                        cmd.Parameters.Add("@isAnswerOption1Correct", MySqlDbType.VarChar).Value = isOption1Correct[iterator];
                        cmd.Parameters.Add("@isAnswerOption2Correct", MySqlDbType.VarChar).Value = isOption2Correct[iterator];
                        cmd.Parameters.Add("@isAnswerOption3Correct", MySqlDbType.VarChar).Value = isOption3Correct[iterator];
                        cmd.Parameters.Add("@isAnswerOption4Correct", MySqlDbType.VarChar).Value = isOption4Correct[iterator];
                        cmd.ExecuteNonQuery();
                        iterator++;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("adminFunctions.cs", "submitNewCourse", e.ToString());
                return false;
            }
        }


        //---------------------------Assign Courses---------------------------------------
        public bool assignCourses(assignCourseModel[] assigncoursesmodel)
        {
            try
            {
                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //create variables
                List<string> users = new List<string>();
                List<string> courses = new List<string>(); 

                //Populate variables
                foreach(assignCourseModel objectModel in assigncoursesmodel)
                {
                    if(objectModel.user != null)
                    {
                        users.Add(objectModel.user); 
                    }
                    if(objectModel.course != null)
                    {
                        courses.Add(objectModel.course); 
                    }
                }

                //Push data to database
                foreach (string user in users)
                {
                    foreach (string course in courses)
                    {
                        //Create security verification variable.
                        bool isOkToAssignCourse = true;



                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                       
                            //Verify user exists
                            MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(*) FROM loginTable WHERE username = @username",conn);
                            cmd1.Parameters.Add("@username", MySqlDbType.VarChar).Value = user; 
                            if(int.Parse(cmd1.ExecuteScalar().ToString()) != 1)
                            {
                                isOkToAssignCourse = false; 
                            }
                            
                            //Verify course exists
                            MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM coursesTable WHERE courseTitle = @courseTitle", conn);
                            cmd2.Parameters.Add("@courseTitle", MySqlDbType.VarChar).Value = course;
                            if (int.Parse(cmd2.ExecuteScalar().ToString()) != 1)
                            {
                                isOkToAssignCourse = false;
                            }
                          
                            //Check user isn't already assigned to course
                            MySqlCommand cmd3 = new MySqlCommand("SELECT COUNT(*) FROM assignedCoursesTable WHERE assignedToID = @assignedToID AND courseID = @courseID", conn);
                            cmd3.Parameters.Add("@assignedToID", MySqlDbType.VarChar).Value = user;
                            cmd3.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = course; 
                            if (int.Parse(cmd3.ExecuteScalar().ToString()) > 0)
                            {
                                isOkToAssignCourse = false;
                            }

                            //If all verification checks pass assign course to user
                            if (isOkToAssignCourse == true)
                            {
                                    MySqlCommand cmd4 = new MySqlCommand("INSERT INTO assignedCoursesTable (assignedByID, assignedToID, courseID) VALUES (@assignedByID, @assignedToID, @courseID)", conn);
                                    cmd4.Parameters.Add("@assignedByID", MySqlDbType.VarChar).Value = "fname and lname"; /*This has to be changed*/
                                    cmd4.Parameters.Add("@assignedToID", MySqlDbType.VarChar).Value = user;
                                    cmd4.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = course;
                                    cmd4.ExecuteNonQuery();
                            }

                        }




                    }
                }

                return true;

            }
            catch (Exception e)
            {
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("adminFunction.cs", "assignCourses", e.ToString());
                return false;
            }

        }


        //--------------------------Retrieve users report-----------------------
        public List<RetrieveUsersReportModel> retrieveUsersReport(string username)
        {
            //Get Connection String
            var configuration = GetConfiguration();
            string connectionString = configuration.GetConnectionString("AWSMAINDB");

            //Declare variables
            List<RetrieveUsersReportModel> retrieveUsersReportModel = new List<RetrieveUsersReportModel>(); 

            //Open Sql connection
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM testScoringTable WHERE LOWER(assignedTo) = @assignedTo", conn);
                    cmd.Parameters.Add("@assignedTo", MySqlDbType.VarChar).Value = username.ToLower();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Populate variables
                    while (reader.Read())
                    {
                        retrieveUsersReportModel.Add(new RetrieveUsersReportModel
                        {
                            courseName = reader["courseName"].ToString(),
                            assignedBy = reader["assignedBy"].ToString(),
                            dateAssigned = reader["dateAssigned"].ToString(),
                            dateTaken = reader["dateTaken"].ToString(),
                            grade = (int.Parse(reader["grade"].ToString()))
                        });
                    }

                    return retrieveUsersReportModel;
                }
                catch(Exception e)
                {
                    EmailErrors error = new EmailErrors();
                    error.autoEmailDeveloperAboutIssue("adminFunctions.cs", "retrieveUserReports", e.ToString()); 
                    return null; 
                }
            }
        }


    }
}
