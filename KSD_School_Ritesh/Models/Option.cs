using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Option
    {
        public int option_id { get; set; }
        public int que_id { get; set;}
        public string option_ { get; set;}
        public bool is_correct { get; set; }
    }
}