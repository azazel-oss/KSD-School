using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Result
    {
        public int result_id { get; set; }
        public int student_id { get; set; }
        public int exam_id { get; set; }
        public int que_id { get; set; }
        public int ans { get; set; }
        public int is_correct { get; set; }
    }
}