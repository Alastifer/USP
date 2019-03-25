using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Qualification { get; set; }
        public string EducationType { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
    }
}
