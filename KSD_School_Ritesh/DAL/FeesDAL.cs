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
    public class FeesDAL
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Fees> feListAll()
        {
            List<Fees> lst = new List<Fees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "2");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Fees
                    {
                        Fee_id = Convert.ToInt32(rdr["Fee_id"]),
                        FeeType = rdr["FeeType"].ToString(),
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        SessionId = Convert.ToInt32(rdr["Student_id"]),
                        Amount = rdr["Amount"].ToString(),
                        Duration = rdr["Duration"].ToString(),
                        comments = rdr["Amount_pending"].ToString(),
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Class  
        public int FeeAdd(Fees sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Fee_id);
                com.Parameters.AddWithValue("@feild2", sub.FeeType);
                com.Parameters.AddWithValue("@feild3", sub.Duration);
                com.Parameters.AddWithValue("@feild4", sub.Student_id);
                com.Parameters.AddWithValue("@feild5", sub.Amount);
                com.Parameters.AddWithValue("@feild6", sub.comments);
                com.Parameters.AddWithValue("@feild7", sub.SessionId);

                com.Parameters.AddWithValue("@table", "2");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int feUpdate(Fees sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Fee_id);
                com.Parameters.AddWithValue("@feild2", sub.FeeType);
                com.Parameters.AddWithValue("@feild3", sub.Duration);
                com.Parameters.AddWithValue("@feild4", sub.Student_id);
                com.Parameters.AddWithValue("@feild5", sub.Amount);
                com.Parameters.AddWithValue("@feild6", sub.comments);
                com.Parameters.AddWithValue("@feild7", sub.SessionId);
                com.Parameters.AddWithValue("@table", "2");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public List<Fees> GetFeesFromStudentId(int Id)
        {
            List<Fees> FeeList = new List<Fees>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP__KSD_GetFeesFromStudentId_", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@StudentId", Id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    FeeList.Add(new Fees
                    {
                        Fee_id = Convert.ToInt32(rdr["Fee_id"]),
                        FeeType = rdr["FeeType"].ToString(),
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        SessionId = Convert.ToInt32(rdr["SessionId"]),
                        Amount = rdr["FeeAmount"].ToString(),
                        Duration = rdr["Duration"].ToString(),
                        comments = rdr["comments"].ToString(),
                    });
                }
                return FeeList;
            }
        }

        //Method for Deleting an Class  
        public int feDelete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", "2");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}