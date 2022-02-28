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
    public class CanteenBillDAL
    {
        //declare connection string  
        private readonly string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<CanteenBill> ListAllBills()
        {
            List<CanteenBill> billList = new List<CanteenBill>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@table", "6");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    billList.Add(new CanteenBill
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        ItemCode = rdr["ItemCode"].ToString(),
                        Student_id = Convert.ToInt32(rdr["Student_id"]),
                        Quantity = Convert.ToInt32(rdr["Quantity"]),
                        Amount = Convert.ToInt32(rdr["Amount"]),
                        BillingDate = Convert.ToDateTime(rdr["DateOfBilling"]).ToShortDateString(),
                    });
                }
                return billList;
            }
        }

        //Method for Adding an Class  
        public int AddBill(CanteenBill bill)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@feild1", bill.Id);
                com.Parameters.AddWithValue("@feild2", bill.ItemCode);
                com.Parameters.AddWithValue("@feild3", bill.Student_id);
                com.Parameters.AddWithValue("@feild4", bill.Quantity);
                com.Parameters.AddWithValue("@feild5", bill.Amount);
                com.Parameters.AddWithValue("@feild6", bill.BillingDate);
                com.Parameters.AddWithValue("@table", "6");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int UpdateBill(CanteenBill bill)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@feild1", bill.Id);
                com.Parameters.AddWithValue("@feild2", bill.ItemCode);
                com.Parameters.AddWithValue("@feild3", bill.Student_id);
                com.Parameters.AddWithValue("@feild4", bill.Quantity);
                com.Parameters.AddWithValue("@feild5", bill.Amount);
                com.Parameters.AddWithValue("@feild6", bill.BillingDate);
                com.Parameters.AddWithValue("@table", "6");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        
        //Method for Deleting an Class  
        public int DeleteBill(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_del", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@feild1", ID);
                com.Parameters.AddWithValue("@table", "6");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}