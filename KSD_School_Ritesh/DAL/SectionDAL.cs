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
    public class SectionDAL
    {//declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Section> ListAllSection()
        {
            List<Section> lst = new List<Section>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "9");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Section
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        ClassId = rdr["class_name"].ToString(),
                        StaffId = rdr["Name"].ToString(),
                        Room = rdr["Room"].ToString()
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Section  
        public int AddSection(Section Section)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild2", Section.Room);
                com.Parameters.AddWithValue("@feild3", Section.StaffId);
                com.Parameters.AddWithValue("@feild4", Section.ClassId);

                com.Parameters.AddWithValue("@table", "9");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Section record  
        public int UpdateSection(Section Section)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", Section.Id);
                com.Parameters.AddWithValue("@feild2", Section.Room);
                com.Parameters.AddWithValue("@feild3", Section.StaffId);
                com.Parameters.AddWithValue("@feild4", Section.ClassId);

                com.Parameters.AddWithValue("@table", "9");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Section  
        public int DeleteSection(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 9);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}