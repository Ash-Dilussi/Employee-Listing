using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service.DTO
{
    public class EmpNICDTO
    {
        public int EmpId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
    }
}
