using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Staff
    {
        public int Staff_id { get; set; }
        public string Name { get; set; }
        public string DO_joining { get; set; }
        public string DO_relieve { get; set; }
        public string DOB { get; set; }
        public string Role { get; set; }
        public string Mobile_no { get; set; }
        public string Is_teacher { get; set; }
        public string Is_retired { get; set; }
        public string Emergency_Contact { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
    }
}