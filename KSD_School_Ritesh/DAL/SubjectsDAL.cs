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
    public class SubjectsDAL
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Subjects> subListAll()
        {
            List<Subjects> lst = new List<Subjects>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "5");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Subjects
                    {
                        Subject_id = Convert.ToInt32(rdr["Subject_id"]),
                        Subject_name = rdr["Subject_name"].ToString(),

                    });
                }
                return lst;
            }
        }

        //Method for Adding an Class  
        public int subAdd(Subjects sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Subject_id);
                com.Parameters.AddWithValue("@feild2", sub.Subject_name);

                com.Parameters.AddWithValue("@table", "5");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int subUpdate(Subjects sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Subject_id);
                com.Parameters.AddWithValue("@feild2", sub.Subject_name);

                com.Parameters.AddWithValue("@table", "5");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Class  
        public int subDelete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 5);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}