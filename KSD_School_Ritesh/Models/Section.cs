using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSD_School_Ritesh.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public string StaffId { get; set; }
        public string ClassId { get; set; }
    }
}