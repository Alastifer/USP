using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int AddressIndex { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public int Corps { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
    }
}
