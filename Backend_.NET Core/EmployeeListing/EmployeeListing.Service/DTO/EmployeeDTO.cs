using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service.DTO
{
    public class EmployeeDTO
    {
        public int AutoId { get; set; }
        public int EmpId { get; set; }
        public  string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public string DOB { get; set; }
        public char Gender { get; set; }

    }
}
