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
    public class MarksDAL
    {

        public int Addmarks(Marks mark)
        {
            string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@student_Id", mark.Student_Id);
                com.Parameters.AddWithValue("@session_Id", mark.Session_Id);
                com.Parameters.AddWithValue("@subject_Id", mark.Subject_Id);
                com.Parameters.AddWithValue("@marks", mark.marks);
                com.Parameters.AddWithValue("@table", "11");


                i = com.ExecuteNonQuery();
            }
            return i;
        }
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Marks> Showmarks()
        {
            List<Marks> lst = new List<Marks>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "11");

                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Marks
                    {

                        id = Convert.ToInt32(rdr["id"]),
                        Subject_Id = rdr["subject_name"].ToString(),
                        Student_Id = rdr["Name"].ToString(),
                        Session_Id = rdr["Session"].ToString(),
                        marks = rdr["marks"].ToString()
                        
                    });
                }

                
            }
            return (lst);
        }
        public List<string> Distinct_session()
        {
            List<Marks> Distinct_Session = Showmarks();
            List<string> DistinctSession = new List<string>();
            foreach (Marks mark in Distinct_Session)
            {
                if (DistinctSession.Contains(mark.Session_Id)) {
                    continue;
                } else
                {
                    DistinctSession.Add(mark.Session_Id);
                }
            }DistinctSession.Sort();
            return (DistinctSession);
        }
        
        public List<string> Distinct_Student()
        {
            List<Marks> Distinct_Student = Showmarks();
            List<string> DistinctStudent = new List<string>();
            foreach (Marks mark in Distinct_Student)
            {
                if (DistinctStudent.Contains(mark.Student_Id)) { continue; } else
                {
                    DistinctStudent.Add(mark.Student_Id);
                }
            }DistinctStudent.Sort();
            return (DistinctStudent);
        }

        public int Updatemarks(Marks mark)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", mark.id);
                com.Parameters.AddWithValue("@marks", mark.marks);
                com.Parameters.AddWithValue("@table", "11");


                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int Deletemarks(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "11");

                com.Parameters.AddWithValue("@id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }



}