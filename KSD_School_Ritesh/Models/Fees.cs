using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Fees
    {
        public int Fee_id { get; set; }
        public string FeeType { get; set; }
        public string Duration { get; set; }
        public string comments { get; set; }
        public string FeeAmount { get; set; }
        public int Student_id { get; set; }
        public int SessionId { get; set; }

    }
}