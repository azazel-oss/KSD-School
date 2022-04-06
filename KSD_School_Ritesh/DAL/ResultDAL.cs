using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using KSD_School_Ritesh.Models;


namespace KSD_School_Ritesh.DAL
{
    public class ResultDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        public int resultAdd(Result result)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("result", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@studentid", result.student_id);
                com.Parameters.AddWithValue("@examid", result.exam_id);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public List<Result> resultDisplay()
        {
            List<Result> lst = new List<Result>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "1");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Result
                    {
                        result_id = Convert.ToInt32(rdr["result_id"]),
                        student_id = Convert.ToInt32(rdr["student_id"]),
                        exam_id = Convert.ToInt32(rdr["exam_id"]),
                        marks = Convert.ToInt32(rdr["marks"]),

                    });
                }
                return lst;
            }
        }

    }
}