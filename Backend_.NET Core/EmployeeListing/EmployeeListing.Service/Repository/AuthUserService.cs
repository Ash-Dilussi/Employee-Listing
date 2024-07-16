using EmployeeListing.DataAccess;
using EmployeeListing.Model.AuthUser;
using EmployeeListing.Model.Employee;
using EmployeeListing.Service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service.Repository
{
    public class AuthUserService : IAuthUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        private IConfiguration _configuration;

        public byte[] passwordHashreg { get; set; }
        private byte[] passwardSaltreg;

        public AuthUserService(DataContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetInside()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
               // result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;

        }

        public async Task<List<AuthUserpropDTO>> GetbyId(string id)
        {

            var us = await _context.TBL_UserAuthentication
                                 .Where(u => u.UserName == id)
                                 .Select(u => new AuthUserpropDTO
                                 {
                                    UserName = u.UserName,
                                    PasswordSalt = u.PasswordSalt,
                                    PasswordHash= u.PasswordHash,


                                 })
                                .ToListAsync();
            return us;

        }

        public async Task AddUser(AuthUserenterDTO nuser)
        {

                AuthUserpropDTO newRcord = new AuthUserpropDTO
                {
                   UserName= nuser.UserName,
                   PasswordHash= passwordHashreg,
                   PasswordSalt= passwardSaltreg,
                    
                };


                _context.TBL_UserAuthentication.Add(newRcord);
                await _context.SaveChangesAsync();

        }

        public void CreatePasswordHash(string password)
        {
            
            using (var hmac = new HMACSHA512())
            {
                passwardSaltreg = hmac.Key;
                passwordHashreg = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        public bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

        }


        public string CreateToken(AuthUserenterDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
           //     new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



    }
}
