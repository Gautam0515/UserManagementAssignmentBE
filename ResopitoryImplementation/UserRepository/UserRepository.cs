using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models.DTOS;
using RepositoryInterface.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagementAssignmentBE.Models;

namespace ResopitoryImplementation.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SDirectContext _context;
        public UserRepository(SDirectContext context)
        { 
        _context = context;
        }

        public async Task<IEnumerable<GautamUser>> GetAllUsersRepo()
        {

                return await _context.GautamUsers.ToListAsync();

        }
        public async Task<GautamUser> LoginAuthRepo(string email, string password)
        {
            var result = await _context.Set<GautamUser>().SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            return result;
        }

        public async Task RegisterUserRepo(GautamUser user)
        {
            var result = _context.GautamUsers.Add(user);
           await _context.SaveChangesAsync();
        }

        public async Task<GautamUser> ForgotCredRepo(ForgotCredDTO forgotCredDTO)
        {
            try
            {
                var result = await _context.Set<GautamUser>().SingleAsync(x => x.Email == forgotCredDTO.Email);
                return result;
            }
            catch (Exception ex) {
                throw ex;
                //return Ok(ex.Message);
            }
        }   

        public async Task ResetPassRepo(ResetPassDTO resetPassDTO)
        {
            try
            {
                var verifyeduser = _context.Set<GautamUser>().FirstOrDefault(x => x.Email == resetPassDTO.Email);
                verifyeduser.Password=resetPassDTO.Password;
                _context.Entry(verifyeduser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
