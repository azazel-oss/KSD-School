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

        public List<Question> Listque()
        {
            List<Question> lst = new List<Question>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "4");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Question
                    {
                        que_id = Convert.ToInt32(rdr["Que_id"]),
                        que_no = Convert.ToInt32(rdr["que_no"]),
                        exam_id = Convert.ToInt32(rdr["exam_id"]),
                        que_text = rdr["que_text"].ToString()

                    });
                }
                return lst;
            }
        }
        public int GetExamIdFromData(ExamData exam)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@class_id", exam.class_id);
                com.Parameters.AddWithValue("@subject_id", exam.subject_id);
                com.Parameters.AddWithValue("@session_id", exam.session_id);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}