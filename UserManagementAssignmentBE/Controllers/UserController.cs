using GSF.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.DTOS;
using ServiceInterface.IUserService;
using System.IO;
using UserManagementAssignmentBE.Models;

namespace UserManagementAssignmentBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UserController(IUserService userService, IEmailService emailService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        [HttpGet("All")]
        
        public Task<IEnumerable<GautamUser>> GetAllUsers()
        {
           return _userService.GetAllUsersService();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginAuth(LoginCredDTO credDTO)
        {
            try
            {
                var result = await _userService.LoginAuthService(credDTO);
                if (result == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        [HttpPost("Register")]
        public async Task RegisterUser(AddUserDTO add)
        {
            await _userService.RegisterUserService(add);
        }

        [HttpPost("Forgot")]
        public void ForgotCred(ForgotCredDTO forgotCredDTO)
        {
            try
            {
                _userService.ForgotCredService(forgotCredDTO);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPut("Reset")]
        public void ResetPass(ResetPassDTO resetPassDTO)
        {
            _userService.ResetPassService(resetPassDTO);
            
        }

    }
}
