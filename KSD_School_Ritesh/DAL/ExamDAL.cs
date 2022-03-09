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
    public class ExamDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        public int AddExamTerm(Exam exam)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", exam.exam_id);
                com.Parameters.AddWithValue("@feild2", exam.session_id);
                com.Parameters.AddWithValue("@feild3", exam.subj_id);
                com.Parameters.AddWithValue("@feild4", exam.class_id);
                com.Parameters.AddWithValue("@table", "14");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}