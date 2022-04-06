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
    public class LoginDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        public string LoginCheck(login loginobj)
        {
            
            string role = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                
                SqlCommand com = new SqlCommand("checklogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@username", loginobj.Username);
                com.Parameters.AddWithValue("@password", loginobj.Password);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    role = rdr["Role"].ToString();
                }
                



            }

            return role;
            
        }

        //Method for Updating Class record  
        //public int LoginUpdate(login loginobj)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("ksd_edit", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@username", loginobj.Username);
        //        com.Parameters.AddWithValue("@password", loginobj.Password);
        //        com.Parameters.AddWithValue("@role", loginobj.Password);


        //        com.Parameters.AddWithValue("@table", "1");
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        
    }
}