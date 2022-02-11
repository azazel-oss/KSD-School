using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Fees
    {
        public int Fee_id { get; set; }
        public int Transaction_id { get; set; }
        public string Duration { get; set; }
        public string Amount_pending { get; set; }
        public string Amount { get; set; }
        public int Student_id { get; set; }
        //Feetype
        //comment
        //sessionid

    }
}