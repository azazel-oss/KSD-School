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
    public class CanteenInventoryDAL
    {
        //declare connection string  
        private readonly string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        //Return list of all Students  
        public List<CanteenInventory> ListAllItems()
        {
            List<CanteenInventory> canteenItemList = new List<CanteenInventory>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_show", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@table", "7");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    canteenItemList.Add(new CanteenInventory
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        ItemName = rdr["ItemName"].ToString(),
                        ItemCode = rdr["ItemCode"].ToString(),
                        Price = Convert.ToInt32(rdr["Price"]),
                        RemainingQuantity = Convert.ToInt32(rdr["RemainingQuantity"]),
                    });
                }
                return canteenItemList;
            }
        }

        //Method for Adding an Class  
        public int AddItem(CanteenInventory Item)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@feild1", Item.Id);
                com.Parameters.AddWithValue("@feild2", Item.ItemName);
                com.Parameters.AddWithValue("@feild3", Item.ItemCode);
                com.Parameters.AddWithValue("@feild4", Item.Price);
                com.Parameters.AddWithValue("@feild5", Item.RemainingQuantity);

                com.Parameters.AddWithValue("@table", "7");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Class record  
        public int UpdateItem(CanteenInventory Item)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ksd_edit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                com.Parameters.AddWithValue("@feild1", Item.Id);
                com.Parameters.AddWithValue("@feild2", Item.ItemName);
                com.Parameters.AddWithValue("@feild3", Item.ItemCode);
                com.Parameters.AddWithValue("@feild4", Item.Price);
                com.Parameters.AddWithValue("@feild5", Item.RemainingQuantity);
                com.Parameters.AddWithValue("@table", "7");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        
        //Method for Deleting an Class  
        public int DeleteItem(int ID)
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
                com.Parameters.AddWithValue("@table", "7");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}