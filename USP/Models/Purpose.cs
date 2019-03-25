using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class Purpose
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string SubDivision { get; set; }
        public DateTime AppointmentDate { get; set; }
        public double Bets { get; set; }
        public double Salary { get; set; }
        public int OrderNumber { get; set; }
    }
}
