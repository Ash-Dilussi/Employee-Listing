using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Model.Employee
{
    public class EmpDTO
    {
        public int AutoId { get; set; }
        public int EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NIC { get; set; }
        public DateOnly DOB { get; set; }
        public char Gender { get; set; }


    }
}
