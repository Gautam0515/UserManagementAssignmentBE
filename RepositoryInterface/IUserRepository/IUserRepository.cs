using Microsoft.AspNetCore.Mvc;
using Models.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAssignmentBE.Models;

namespace RepositoryInterface.IUserRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<GautamUser>> GetAllUsersRepo();
        public Task<GautamUser> LoginAuthRepo(string email, string password);
        public Task RegisterUserRepo(GautamUser user);
        public Task<GautamUser> ForgotCredRepo(ForgotCredDTO forgotCredDTO);
        public Task ResetPassRepo(ResetPassDTO resetPassDTO);

    }
}
