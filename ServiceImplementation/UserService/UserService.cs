using GSF.Security.Cryptography;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Models.Models.DTOS;
using RepositoryInterface.IUserRepository;
using ServiceInterface.IUserService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementAssignmentBE.Models;
using Shared.Encryption;

namespace ServiceImplementation.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly IEmailService _emailService;
        Encryptor e = new Encryptor();


        GautamUser _users = new();
        public UserService(IEmailService emailService,IUserRepository userRepository, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _emailService = emailService;
            _configuration = configuration;
            _userRepository = userRepository;
            _environment = environment;
        }
        public Task<IEnumerable<GautamUser>> GetAllUsersService()
        {
          return _userRepository.GetAllUsersRepo();
        }

        public async Task<ActionResult<string>> LoginAuthService(LoginCredDTO credDTO)
        {
            var LoginUser = await _userRepository.LoginAuthRepo(credDTO.Email,credDTO.Password);
            if (LoginUser == null) {
                return string.Empty;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,  LoginUser.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        public async Task RegisterUserService(AddUserDTO add)
        {

            var passGenerator = new PasswordGenerator();
            var randPass = passGenerator.GeneratePassword();



            if (add.PicBytes == null || add.PicBytes.Length == 0)
            {
                throw new ArgumentException("No Image Found");
            }
            var memoryStream = new MemoryStream();
            await add.PicBytes.CopyToAsync(memoryStream);
            byte[] convertedPic = memoryStream.ToArray();

            string encryptedPass = e.Encrypt(randPass, _configuration["Cypher:PrivateKey"], _configuration["Cypher:PrivateKey"]);
            string encryptedEmail = e.Encrypt(add.Email, _configuration["Cypher:PrivateKey"], _configuration["Cypher:PrivateKey"]);

            var user = new GautamUser
            {
                FirstName = add.FirstName,
                MiddleName = add.MiddleName,
                LastName = add.LastName,
                Gender = add.Gender,
                DateOfJoining = add.DateOfJoining,
                Dob = add.Dob,
                Phone = add.Phone,
                AlternatePhone = add.AlternatePhone,
                Email = encryptedEmail,
                Password = encryptedPass,
                Country = add.Country,
                City = add.City,
                State = add.State,
                ZipCode = add.ZipCode,
                PicBytes = convertedPic,
                TempAddressId = add.TempAddress.Id,
                TempAddress = add.TempAddress,
                UpdatedDate = DateTime.Now,
                IsActive = add.IsActive,
            };

            await _userRepository.RegisterUserRepo(user);
            string decryptedEmail = e.Decrypt(user.Email, _configuration["Cypher:PrivateKey"], _configuration["Cypher:PrivateKey"]);
            string decryptedPass = e.Decrypt(user.Password, _configuration["Cypher:PrivateKey"], _configuration["Cypher:PrivateKey"]);
            _emailService.SendEmail(decryptedEmail, "Verify your Email", "verify user", decryptedPass);
        }

        //var userObj = Newtonsoft.Json.JsonConvert.DeserializeObject<AddUserDTO>(formData.user);

        //if (userObj != null)
        //{
        //    return userObj;
        //}
        //if (formData.image != null && formData.image.Length > 0)
        //{
        //    var fileName = Path.GetFileName(formData.image.FileName);
        //    var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

        //    // Ensure the directory exists
        //    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //    userObj.PicUrl = $"/images/{fileName}";

        //    // Save the file to disk
        //    return filePath;
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await formData.image.CopyToAsync(stream);
        //    }

        //}


        public void ForgotCredService(ForgotCredDTO forgotCredDTO)
        {
            try
            {
                var user = _userRepository.ForgotCredRepo(forgotCredDTO);
                _emailService.SendEmail(forgotCredDTO.Email, "Reset Password", "forgot password", "");
            }
            catch (Exception ex) {
                throw ex;
            }
            

        }

        public void ResetPassService(ResetPassDTO resetPassDTO)
        {
            var user = _userRepository.ResetPassRepo(resetPassDTO);
        }
        



    }
}

