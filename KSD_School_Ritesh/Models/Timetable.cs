using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string ClassId { get; set; }
        public string SubjectId { get; set; }
        public string StaffId { get; set; }
        public int Period { get; set; }
    }
}