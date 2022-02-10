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
        public List<Staff> StaffListAll()
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
        public int StaffAdd(Staff sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Staff_id);
                com.Parameters.AddWithValue("@feild2", sub.Name);
                com.Parameters.AddWithValue("@feild4", sub.DO_joining);
                com.Parameters.AddWithValue("@feild5", sub.DO_relieve);
                com.Parameters.AddWithValue("@feild3", sub.DOB);
                com.Parameters.AddWithValue("@feild6", sub.Is_retired);
                com.Parameters.AddWithValue("@feild7", sub.Is_teacher);
                com.Parameters.AddWithValue("@feild8", sub.Role);
                com.Parameters.AddWithValue("@feild9", sub.Mobile_no);
                com.Parameters.AddWithValue("@feild10", sub.Salary);
                com.Parameters.AddWithValue("@feild11", sub.Emergency_Contact);
                com.Parameters.AddWithValue("@feild12", sub.Department);

                com.Parameters.AddWithValue("@table", "3");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int StaffUpdate(Staff sub)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@feild1", sub.Staff_id);
                com.Parameters.AddWithValue("@feild2", sub.Name);
                com.Parameters.AddWithValue("@feild4", sub.DO_joining);
                com.Parameters.AddWithValue("@feild5", sub.DO_relieve);
                com.Parameters.AddWithValue("@feild3", sub.DOB);
                com.Parameters.AddWithValue("@feild6", sub.Is_retired);
                com.Parameters.AddWithValue("@feild7", sub.Is_teacher);
                com.Parameters.AddWithValue("@feild8", sub.Role);
                com.Parameters.AddWithValue("@feild9", sub.Mobile_no);
                com.Parameters.AddWithValue("@feild10", sub.Salary);
                com.Parameters.AddWithValue("@feild11", sub.Emergency_Contact);
                com.Parameters.AddWithValue("@feild12", sub.Department);
                com.Parameters.AddWithValue("@table", "3");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Class  
        public int StaffDelete(int ID)
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