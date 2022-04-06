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

    public class RegisterDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        public int Addstudent(Student student)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", student.Student_id);
                com.Parameters.AddWithValue("@feild2", student.Name);
                com.Parameters.AddWithValue("@feild3", student.Father_name);
                com.Parameters.AddWithValue("@feild4", student.Father_contact);
                com.Parameters.AddWithValue("@feild5", student.Address);
                com.Parameters.AddWithValue("@feild6", student.Class_id);
                com.Parameters.AddWithValue("@feild7", student.section_id);
                com.Parameters.AddWithValue("@feild8", student.Emergency_Contact);
                com.Parameters.AddWithValue("@table", "4");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
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