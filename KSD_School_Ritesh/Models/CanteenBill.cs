using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class CanteenBill
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public int Student_id { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public string BillingDate { get; set; }
    }
}