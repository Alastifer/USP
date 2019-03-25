using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public bool TradeUnion { get; set; }
        public Passport Passport { get; set; }
        public List<Education> Educations { get; set; }
        public Address Registration { get; set; }
        public Address Residence { get; set; }
        public Insurance Insurance { get; set; }
        public Purpose Purpose { get; set; }
    }
}
