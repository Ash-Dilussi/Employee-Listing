using EmployeeListing.Model.AuthUser;
using EmployeeListing.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service.Repository
{
    public interface IAuthUserService
    {

        byte[] passwordHashreg { get; set; }
        //  string GetMyName();
        void CreatePasswordHash(string password);
        bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        Task AddUser(AuthUserenterDTO nuser);
        Task<List<AuthUserpropDTO>> GetbyId(string id);
        string CreateToken(AuthUserenterDTO user);
        string GetInside();


    }
}

