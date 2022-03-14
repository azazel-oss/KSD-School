using KSD_School_Ritesh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.DAL
{
    public class QuestionDAL
    {//declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        public int AddQuestion(Question question, List<Option> options)
        {

            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", question.que_id);
                com.Parameters.AddWithValue("@feild2", question.que_no);
                com.Parameters.AddWithValue("@feild3", question.que_text);
                com.Parameters.AddWithValue("@feild4", question.exam_id);
                com.Parameters.AddWithValue("@table", "12");
                SqlParameter returnValue = new SqlParameter("@que_id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                com.Parameters.Add(returnValue);
                com.ExecuteNonQuery();
                i = (int)com.Parameters["@que_id"].Value;

                foreach (var option in options)
                {
                    com = new SqlCommand("ksd_edit", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@feild1", option.option_id);
                    com.Parameters.AddWithValue("@feild2", i);
                    com.Parameters.AddWithValue("@feild3", option.option_);
                    com.Parameters.AddWithValue("@feild4", option.is_correct);
                    com.Parameters.AddWithValue("@table", "13");
                    com.ExecuteNonQuery();
                }


            }
            return i;
        }
        public List<Question> Listque()
        {
            
            List<Question> lst = new List<Question>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "12");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Question
                    {
                        que_id = Convert.ToInt32(rdr["que_id"]),
                        que_no = Convert.ToInt32(rdr["que_no"]),
                        exam_id = Convert.ToInt32(rdr["exam_id"]),
                        que_text = rdr["que_text"].ToString(),
                        Option = rdr["options"].ToString(),

                    });
                }
                return lst;
            }
        }
        //public List<string> Quedisplay()
        //{
        //    List<Question> que = Listque();
        //    var list = que.Cast<string>().ToList();
        //    list[list.Count - 1].Split(',');

        //    List<string> data = new List<string>();
        //    foreach( Question question in Listque())
        //    {
                
        //        var option = question.Option;
        //        string[] values = option.Split(',');
        //        string option1 = values[0];
        //        string option2 = values[1];
        //        string option3 = values[2];
        //        string option4 = values[3];
        //    }
        //    que.AddRange(values);
           
        //}
        public int Addque(Question que)
        {

            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild2", que.que_no);
                com.Parameters.AddWithValue("@feild3", que.que_text);
                com.Parameters.AddWithValue("@feild4", que.exam_id);
                com.Parameters.AddWithValue("@table", "12");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int Deleteque(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 12);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public List<QuestionDisplay> GetQuestionsFromExamId(int examId)
        {
            List<QuestionDisplay> questionDisplays = new List<QuestionDisplay>();
            List<Question> questionList = new List<Question>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP__KSD_GetQuestionByExamID_", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@exam_id", examId);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    questionList.Add(new Question
                    {
                        que_id = Convert.ToInt32(rdr["que_id"]),
                        que_no = Convert.ToInt32(rdr["que_no"]),
                        exam_id = Convert.ToInt32(rdr["exam_id"]),
                        que_text = rdr["que_text"].ToString()
                    });
                }
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                
                foreach (Question question in questionList)
                {
                    con.Open();
                    QuestionDisplay questionDisplay = new QuestionDisplay();
                    SqlCommand com = new SqlCommand("SP__KSD_GetOptionsFromQId_", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@qid", question.que_id);
                    SqlDataReader rdr = com.ExecuteReader();
                    List<Option> incorrectOptions = new List<Option>();
                    Option correctOption = new Option();
                    while (rdr.Read())
                    {
                        Option currentOption = new Option
                        {
                            option_id = Convert.ToInt32(rdr["option_id"]),
                            que_id = Convert.ToInt32(rdr["que_id"]),
                            option_ = rdr["option_"].ToString(),
                            is_correct = Convert.ToBoolean(rdr["is_correct"])
                        };
                        if (currentOption.is_correct)
                        {
                            correctOption = currentOption;
                        }
                        else
                        {
                            incorrectOptions.Add(currentOption);
                        }
                        
                    }
                    //questionDisplay.question = question;
                    //questionDisplay.correctOption = correctOption;
                    //questionDisplay.incorrectOptions = incorrectOptions;
                    questionDisplays.Add(new QuestionDisplay {
                        Question = question,
                        CorrectOption = correctOption,
                        IncorrectOptions = incorrectOptions
                    });
                    con.Close();
                }
            }
            return questionDisplays;
        }
        public int GetExamIdFromData(ExamData exam)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP__KSD_GetExamId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@class_id", exam.class_id);
                com.Parameters.AddWithValue("@subject_id", exam.subject_id);
                com.Parameters.AddWithValue("@session_id", exam.session_id);
                SqlParameter returnValue = new SqlParameter("@exam_id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                com.Parameters.Add(returnValue);
                com.ExecuteNonQuery();
                i = (int)com.Parameters["@exam_id"].Value;
                //i = com.ExecuteNonQuery();
                //SqlDataReader rdr = com.ExecuteReader();
                //while (rdr.Read())
                //{
                //    i = Convert.ToInt32(rdr["exam_id"]);
                //    section = Convert.ToInt32(rdr["section_id"]);
                //}
            }
            return i;
        }
    }
}