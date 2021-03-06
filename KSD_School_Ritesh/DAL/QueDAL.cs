using KSD_School_Ritesh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSD_School_Ritesh.DAL
{
    public class QueDAL

    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        public int Addans(StudentAns que)
        {

            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", que.que_id);
                com.Parameters.AddWithValue("@feild2", que.student_id);
                com.Parameters.AddWithValue("@feild3", que.selected_ans);
                com.Parameters.AddWithValue("@feild4", que.exam_id);
                
                com.Parameters.AddWithValue("@table", "15");
                i = com.ExecuteNonQuery();
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
        public int Updateque(Question que)
        {

            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild2", que.que_no);
                com.Parameters.AddWithValue("@feild3", que.que_text);
                com.Parameters.AddWithValue("@feild3", que.exam_id);
                com.Parameters.AddWithValue("@table", "4");
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
                com.Parameters.AddWithValue("@table", 4);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


    }
}