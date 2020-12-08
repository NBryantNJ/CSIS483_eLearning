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
    public class takeATestFunctions
    {

        //-----------------------------appsettings file reference-----------------------------
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        //----------------------------Get questions for test-----------------------------------
        public List<TakeATestModel> getTestQuestions(string username, string password, string courseID)
        {
            try
            {
                //Declare variables
                List<TakeATestModel> testModel = new List<TakeATestModel>();

                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Open connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    //Confirm user is authorized to take this course
                    MySqlCommand cmdUserAuth = new MySqlCommand("SELECT COUNT(*) FROM loginTable INNER JOIN assignedCoursesTable ON assignedCoursesTable.assignedToID = @username WHERE username = @username AND userspassword = @password AND assignedCoursesTable.courseID = @courseID", conn);
                    cmdUserAuth.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    cmdUserAuth.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                    cmdUserAuth.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                    if (int.Parse(cmdUserAuth.ExecuteScalar().ToString()) > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM coursesTestQuestionsTable WHERE testID = @courseID", conn);
                        cmd.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //Populate testModel with test questions
                            testModel.Add(new TakeATestModel()
                            {
                                testID = reader["testID"].ToString(),
                                questionNumber = int.Parse(reader["questionNumber"].ToString()),
                                question = reader["question"].ToString(),
                                answerOption1 = reader["answerOption1"].ToString(),
                                answerOption2 = reader["answerOption2"].ToString(),
                                answerOption3 = reader["answerOption3"].ToString(),
                                answerOption4 = reader["answerOption4"].ToString(),
                                isAnswerOption1Correct = reader["isAnswerOption1Correct"].ToString(),
                                isAnswerOption2Correct = reader["isAnswerOption2Correct"].ToString(),
                                isAnswerOption3Correct = reader["isAnswerOption3Correct"].ToString(),
                                isAnswerOption4Correct = reader["isAnswerOption4Correct"].ToString()

                            });
                        }
                        return testModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                EmailErrors emailerrors = new EmailErrors(); 
                emailerrors.autoEmailDeveloperAboutIssue("takeATestFuctions.cs", "getTestQuestions", e.ToString());
                return null;
            }
        }




        //-------------------------------Grade users test----------------------------------------------
        public string gradeTest(string username, string password, string courseID, string[] answers)
        {
            try
            {
                //Declare variables 
                double totalQuestions = 0;
                double correctAnswers = 0;
                int i = 0;
                bool wasAnswerCorrect = false;
                DateTime assigedCourseDate = new DateTime();
                string assignedBy = ""; 
                int totalScore = 0;

                //Get Connection String
                var configuration = GetConfiguration();
                string connectionString = configuration.GetConnectionString("AWSMAINDB");

                //Open connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    //Confirm user is authorized to take this course
                    MySqlCommand cmdUserAuth = new MySqlCommand("SELECT COUNT(*) FROM loginTable INNER JOIN assignedCoursesTable ON assignedCoursesTable.assignedToID = @username WHERE username = @username AND userspassword = @password AND assignedCoursesTable.courseID = @courseID", conn);
                    cmdUserAuth.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    cmdUserAuth.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                    cmdUserAuth.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                    if (int.Parse(cmdUserAuth.ExecuteScalar().ToString()) > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM coursesTestQuestionsTable WHERE testID = @testID", conn);
                        cmd.Parameters.Add("@testID", MySqlDbType.VarChar).Value = courseID; 
                        MySqlDataReader reader = cmd.ExecuteReader(); 
                        while(reader.Read())
                        {
                            //Check if answer is correct
                            wasAnswerCorrect = false; 

                            //Check if question is correct out of any 4 options
                            if(answers[i] == reader["answerOption1"].ToString() && reader["isAnswerOption1Correct"].ToString() == "Correct")
                            {
                                wasAnswerCorrect = true; 
                            }
                            else if(answers[i] == reader["answerOption2"].ToString() && reader["isAnswerOption2Correct"].ToString() == "Correct")
                            {
                                wasAnswerCorrect = true;
                            }
                            else if (answers[i] == reader["answerOption3"].ToString() && reader["isAnswerOption3Correct"].ToString() == "Correct")
                            {
                                wasAnswerCorrect = true;
                            }
                            else if (answers[i] == reader["answerOption4"].ToString() && reader["isAnswerOption4Correct"].ToString() == "Correct")
                            {
                                wasAnswerCorrect = true;
                            }

                            //If answer was correct add +1 to correctAnswers
                            if(wasAnswerCorrect == true)
                            {
                                correctAnswers += 1; 
                            }

                            totalQuestions++;
                            i++;
                        }
                        reader.Close(); 

                        //Get course assign data
                        MySqlCommand getAssignDataCmd = new MySqlCommand("SELECT * FROM assignedCoursesTable WHERE assignedToID = @username AND courseID = @courseID", conn);
                        getAssignDataCmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                        getAssignDataCmd.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID; 
                        MySqlDataReader assignedCourseDateReader = getAssignDataCmd.ExecuteReader(); 
                        while(assignedCourseDateReader.Read())
                        {
                            assigedCourseDate = DateTime.Parse(assignedCourseDateReader["queryCreationDate"].ToString());
                            assignedBy = assignedCourseDateReader["assignedByID"].ToString(); 
                        }

                         assignedCourseDateReader.Close();

                        //Submit score to DB
                        double score = (correctAnswers / totalQuestions) * 100;
                        totalScore = int.Parse(Math.Round(score).ToString()); 
                        MySqlCommand cmdInsertIntoDB = new MySqlCommand("INSERT INTO testScoringTable (courseName, assignedBy, dateAssigned, grade, assignedTo) VALUES (@courseName, @assignedBy, @dateAssigned, @grade, @assignedTo)", conn);
                        cmdInsertIntoDB.Parameters.Add("@courseName", MySqlDbType.VarChar).Value = courseID;
                        cmdInsertIntoDB.Parameters.Add("@assignedBy", MySqlDbType.VarChar).Value = assignedBy;
                        cmdInsertIntoDB.Parameters.Add("@dateAssigned", MySqlDbType.DateTime).Value = assigedCourseDate;
                        cmdInsertIntoDB.Parameters.Add("@grade", MySqlDbType.VarChar).Value = totalScore;
                        cmdInsertIntoDB.Parameters.Add("@assignedTo", MySqlDbType.VarChar).Value = username;
                        cmdInsertIntoDB.ExecuteNonQuery();

                        //Delete from assigned courses table
                        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM assignedCoursesTable WHERE assignedToID = @assignedToID AND courseID = @courseID", conn);
                        deleteCommand.Parameters.Add("@assignedToID", MySqlDbType.VarChar).Value = username;
                        deleteCommand.Parameters.Add("@courseID", MySqlDbType.VarChar).Value = courseID;
                        deleteCommand.ExecuteNonQuery(); 

                        //Return true
                        return "true";
                }
                else
                {
                    return "Not authorized to take course" + courseID;
                }
            }
            }
            catch (Exception e)
            {
                EmailErrors emailerrors = new EmailErrors();
                emailerrors.autoEmailDeveloperAboutIssue("takeATestFunctions", "gradeTest", e.ToString());
                return "ERROR CATCH"; 
            }
        }






    }
}
