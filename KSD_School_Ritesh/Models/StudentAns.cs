using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class StudentAns
    {

        public int que_id { get; set; }
        public int student_id { get; set; }
        public string selected_ans { get; set; }
        public int exam_id { get; set; }
    }
}