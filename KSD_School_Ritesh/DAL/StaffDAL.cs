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
    public class StaffDAL
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<Staff> staListAll()
        {
            List<Staff> staffList = new List<Staff>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@table", "3");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    staffList.Add(new Staff
                    {

                        Staff_id = Convert.ToInt32(rdr["Staff_id"]),
                        Name = rdr["Name"].ToString(),
                        DOB = rdr["DOB"].ToString(),
                        DO_joining = rdr["DO_joining"].ToString(),
                        DO_relieve = rdr["DO_relieve"].ToString(),
                        Is_retired = rdr["is_retired"].ToString(),
                        Is_teacher = rdr["Is_teacher"].ToString(),
                        Role = rdr["Role"].ToString(),
                        Mobile_no = rdr["Mobile_no"].ToString(),
                        Salary = rdr["Salary"].ToString(),
                        Emergency_Contact = rdr["Emergency_Contact"].ToString(),
                        Department = rdr["Department"].ToString(),

                    });
                }
                return staffList;
            }
        }

        //Method for Adding an Class  
        public int staAdd(Staff subjectDAL)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", subjectDAL.Staff_id);
                com.Parameters.AddWithValue("@feild2", subjectDAL.Name);
                com.Parameters.AddWithValue("@feild4", subjectDAL.DO_joining);
                com.Parameters.AddWithValue("@feild5", subjectDAL.DO_relieve);
                com.Parameters.AddWithValue("@feild3", subjectDAL.DOB);
                com.Parameters.AddWithValue("@feild6", subjectDAL.Is_retired);
                com.Parameters.AddWithValue("@feild7", subjectDAL.Is_teacher);
                com.Parameters.AddWithValue("@feild8", subjectDAL.Role);
                com.Parameters.AddWithValue("@feild9", subjectDAL.Mobile_no);
                com.Parameters.AddWithValue("@feild10", subjectDAL.Salary);
                com.Parameters.AddWithValue("@feild11", subjectDAL.Emergency_Contact);
                com.Parameters.AddWithValue("@feild12", subjectDAL.Department);

                com.Parameters.AddWithValue("@table", "3");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int staUpdate(Staff subjectDAL)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", subjectDAL.Staff_id);
                com.Parameters.AddWithValue("@feild2", subjectDAL.Name);
                com.Parameters.AddWithValue("@feild4", subjectDAL.DO_joining);
                com.Parameters.AddWithValue("@feild5", subjectDAL.DO_relieve);
                com.Parameters.AddWithValue("@feild3", subjectDAL.DOB);
                com.Parameters.AddWithValue("@feild6", subjectDAL.Is_retired);
                com.Parameters.AddWithValue("@feild7", subjectDAL.Is_teacher);
                com.Parameters.AddWithValue("@feild8", subjectDAL.Role);
                com.Parameters.AddWithValue("@feild9", subjectDAL.Mobile_no);
                com.Parameters.AddWithValue("@feild10", subjectDAL.Salary);
                com.Parameters.AddWithValue("@feild11", subjectDAL.Emergency_Contact);
                com.Parameters.AddWithValue("@feild12", subjectDAL.Department);
                com.Parameters.AddWithValue("@table", "3");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Class  
        public int staDelete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", 3);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}