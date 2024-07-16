using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Model.AuthUser
{
    public class AuthUserpropDTO
    {
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public string RefreshToken { get; set; } = string.Empty;
        //public DateTime TokenCreated { get; set; }
        //public DateTime TokenExpires { get; set; }

    }
}
