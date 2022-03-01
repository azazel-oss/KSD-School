using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Exam
    {
        public int exam_id { get; set; }
        public int session_id { get; set; }
        public int subj_id { get; set; }
        public int class_id { get; set; }
        public int section_id { get; set; }
    }
}