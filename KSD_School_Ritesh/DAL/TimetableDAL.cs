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
    public class TimetableDAL
    {//declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Timetable> ListTimetable()
        {
            List<Timetable> lst = new List<Timetable>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "10");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Timetable
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        SectionId = Convert.ToInt32(rdr["SectionId"].ToString()),
                        ClassId = rdr["class_name"].ToString(),
                        SubjectId = rdr["subject_name"].ToString(),
                        StaffId = rdr["Name"].ToString(),
                        Period = Convert.ToInt32(rdr["Period"].ToString()),
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Timetable  
        public int AddTimetable(Timetable timetable)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild2", timetable.SectionId);
                com.Parameters.AddWithValue("@feild3", timetable.ClassId);
                com.Parameters.AddWithValue("@feild4", timetable.SubjectId);
                com.Parameters.AddWithValue("@feild5", timetable.StaffId);
                com.Parameters.AddWithValue("@feild6", timetable.Period);

                com.Parameters.AddWithValue("@table", "10");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Timetable record  
        public int UpdateTimetable(Timetable Timetable)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", Timetable.Id);
                com.Parameters.AddWithValue("@feild2", Timetable.SectionId);
                com.Parameters.AddWithValue("@feild3", Timetable.ClassId);
                com.Parameters.AddWithValue("@feild4", Timetable.SubjectId);
                com.Parameters.AddWithValue("@feild5", Timetable.StaffId);
                com.Parameters.AddWithValue("@feild6", Timetable.Period);

                com.Parameters.AddWithValue("@table", "10");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Timetable  
        public int DeleteTimetable(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 10);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}