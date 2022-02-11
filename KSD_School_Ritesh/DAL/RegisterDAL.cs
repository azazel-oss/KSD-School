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
    public class RegisterDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        public int Register(login loginobj)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_register", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role", loginobj.Role);
                com.Parameters.AddWithValue("@Username", loginobj.Username);
                com.Parameters.AddWithValue("@Password", loginobj.Password);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}