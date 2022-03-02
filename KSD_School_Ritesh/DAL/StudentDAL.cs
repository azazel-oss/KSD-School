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
    public class StudentDAL
    {

        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Student> ListAll()
        {
            List<Student> lst = new List<Student>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "4");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Student
                    {
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        Name = rdr["Name"].ToString(),
                        Father_name = rdr["Father_name"].ToString(),
                        Father_contact = rdr["Father_contact"].ToString(),
                        Address = rdr["Address"].ToString(),
                        Class_id = rdr["class_name"].ToString(),
                        Emergency_Contact = rdr["Emergency_Contact"].ToString(),
                        section_id = rdr["section_id"].ToString(),
                    });
                }
                return lst;
            }
        }





        //Method for Adding an Student  
        public int Add(Student student)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@feild1", student.Student_id);
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

        //Method for Updating Student record  
        public int Update(Student student)
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

        public Student GetStudentById(int Id)
        {
            Student retrievedStudent = new Student();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP__KSD_GetById_", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "4");
                com.Parameters.AddWithValue("@Id", Id);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {

                    retrievedStudent.Student_id = Convert.ToInt32(rdr["Student_id"]);
                    retrievedStudent.Name = rdr["Name"].ToString();
                    retrievedStudent.Father_name = rdr["Father_name"].ToString();
                    retrievedStudent.Father_contact = rdr["Father_contact"].ToString();
                    retrievedStudent.Address = rdr["Address"].ToString();
                    retrievedStudent.Class_id = rdr["Class_id"].ToString();
                    retrievedStudent.Emergency_Contact = rdr["Emergency_Contact"].ToString();
                    retrievedStudent.section_id = rdr["section_id"].ToString();
                }
                return retrievedStudent;
            }
        }

        //Method for Deleting an Student  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 4);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}