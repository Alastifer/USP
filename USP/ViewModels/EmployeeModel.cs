using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.ViewModels
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string IdentNumber { get; set; }
        public string MaritalStatus { get; set; }
        public string Position { get; set; }
        public string SubDivision { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int OrderNumber { get; set; }
    }
}
