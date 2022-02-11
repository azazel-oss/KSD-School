using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Marks
    {
        public int id { get; set; }
        public string Student_Id { get; set; }
        public string Session_Id { get; set; }
        public string Subject_Id { get; set; }
        public string marks { get; set; }
    }
}