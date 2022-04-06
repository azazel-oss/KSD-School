using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class QuestionDisplay
    {
        public Question Question { get; set; }
        public Option CorrectOption { get; set; }
        public List<Option> IncorrectOptions { get; set; }
    }
}