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
    public class SessionDAL
    {//declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Session> ListAllSession()
        {
            List<Session> lst = new List<Session>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "6");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Session
                    {
                        SessionId = Convert.ToInt32(rdr["SessionId"]),
                        SessionName = rdr["Session"].ToString(),
                        StartDate = rdr["StartDate"].ToString()
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Session  
        public int AddSession (Session Session)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild2", Session.SessionName);
                com.Parameters.AddWithValue("@feild3", Session.StartDate);

                com.Parameters.AddWithValue("@table", "6");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Session record  
        public int UpdateSession(Session Session)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", Session.SessionName);
                com.Parameters.AddWithValue("@feild2", Session.StartDate);

                com.Parameters.AddWithValue("@table", "1");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Session  
        public int DeleteSession(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 1);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}