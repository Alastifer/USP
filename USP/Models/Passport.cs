using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class Passport
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string IdentNumber { get; set; }
        public string Citizenship { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public Address BirthPlace { get; set; }
    }
}
