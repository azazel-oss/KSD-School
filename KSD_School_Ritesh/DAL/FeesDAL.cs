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
                        Transaction_id = Convert.ToInt32(rdr["Transaction_id"]),
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        Amount = rdr["Amount"].ToString(),
                        Duration = rdr["Duration"].ToString(),
                        Amount_pending = rdr["Amount_pending"].ToString(),

                    });
                }
                return lst;
            }
        }

        //Method for Adding an Class  
        public int feAdd(Fees subjectDAL)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", subjectDAL.Fee_id);
                com.Parameters.AddWithValue("@feild2", subjectDAL.Transaction_id);
                com.Parameters.AddWithValue("@feild4", subjectDAL.Student_id);
                com.Parameters.AddWithValue("@feild5", subjectDAL.Amount);
                com.Parameters.AddWithValue("@feild3", subjectDAL.Duration);
                com.Parameters.AddWithValue("@feild6", subjectDAL.Amount_pending);

                com.Parameters.AddWithValue("@table", "2");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int feUpdate(Fees subjectDAL)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", subjectDAL.Fee_id);
                com.Parameters.AddWithValue("@feild2", subjectDAL.Transaction_id);
                com.Parameters.AddWithValue("@feild4", subjectDAL.Student_id);
                com.Parameters.AddWithValue("@feild5", subjectDAL.Amount);
                com.Parameters.AddWithValue("@feild3", subjectDAL.Duration);
                com.Parameters.AddWithValue("@feild6", subjectDAL.Amount_pending);
                com.Parameters.AddWithValue("@table", "2");
                i = com.ExecuteNonQuery();
            }
            return i;
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