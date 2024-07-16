using EmployeeListing.Model.AuthUser;
using EmployeeListing.Service.DTO;
using EmployeeListing.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace EmployeeListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {

       // public static AuthUserpropDTO  user = new AuthUserpropDTO();

        private readonly IAuthUserService _authUserService;

        public AuthUserController(IAuthUserService authUserService)
        {
            _authUserService = authUserService;
        }


        [HttpGet, Authorize]
        public ActionResult<string> GetIn()
        {
            var userName = _authUserService.GetInside();
            return Ok(userName);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthUserenterDTO>> Register(AuthUserenterDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authUserService.CreatePasswordHash(request.Password);

            await _authUserService.AddUser(request);

            byte[] pHash = _authUserService.passwordHashreg;

            return Ok(new { message = "User successfully created", data = pHash  });

            //BitConverter.ToString(pHash)
            return Ok(request);

        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthUserenterDTO>> Login(AuthUserenterDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<AuthUserpropDTO> existUser = await _authUserService.GetbyId(request.UserName);

            if (existUser.Count == 0)
            {
                return BadRequest("User not Found");
            }
             
            if (!_authUserService.verifyPasswordHash(request.Password, existUser[0].PasswordHash, existUser[0].PasswordSalt)) {

                return BadRequest("Wrong Password");
            }

           

            string token = _authUserService.CreateToken(request);

            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);
            return Ok(new { message = "access greanted" + "from th page", data = token });

            //return Ok(token)

    

        }











    }
}
