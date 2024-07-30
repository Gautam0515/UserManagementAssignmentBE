using Microsoft.AspNetCore.Mvc;
using Models.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAssignmentBE.Models;

namespace ServiceInterface.IUserService
{
    public interface IUserService
    {
        public Task<IEnumerable<GautamUser>> GetAllUsersService();
        public Task<ActionResult<string>> LoginAuthService(LoginCredDTO credDTO);
        public Task RegisterUserService(AddUserDTO add);
        public void ForgotCredService(ForgotCredDTO forgotCredDTO);
        public void ResetPassService(ResetPassDTO resetPassDTO);
    }
}
