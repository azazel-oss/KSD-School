using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Student
    {
        public int Student_id { get; set; }
        public string Name { get; set; }
        public string Father_name { get; set; }
        public string Father_contact { get; set; }
        public string Address { get; set; }
        public int Class_id { get; set; }
        public string Emergency_Contact { get; set; }
        public List<Student> GetStudents { get; set; }
    }
}