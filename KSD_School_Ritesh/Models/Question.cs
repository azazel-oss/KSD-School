using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Question
    {
        public int que_id { get; set; }
        public int que_no { get; set; }
        public string que_text { get; set; }
        public int exam_id { get; set; }
        public string[] Option { get; set; }
    }
}