using GSF.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using ServiceInterface.IUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.UserService
{
    public class MailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string toUserEmail,string subject,string MailFor, string randpass)
        {
            int port = Convert.ToInt32(_configuration["Smtp:Port"]);

            SmtpClient smtpClient = new SmtpClient(_configuration["Smtp:ServerId"],port);
            smtpClient. EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_configuration["Smtp:MyEmail"], _configuration["Smtp:MyPassword"]);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration["Smtp:MyEmail"]);
            mailMessage.To.Add(toUserEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();

            if (MailFor.ToLower() == "verify user")
            {
                mailBody.AppendFormat("<h1>User Registered</h1>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Your Password for your Email {0} is {1}</p>", toUserEmail, randpass);
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Click on this link to varify your email address <a href=\"http://localhost:4200/reset?Email={0} \">CLICK HERE TO VERIFY</a> </p>", toUserEmail);
            }

            if (MailFor == "forgot password")
            {
                mailBody.AppendFormat("<h1>Reset Password</h1>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Your Email is:- {0}</p>", toUserEmail);
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Click on this link to reset yout password <a href=\"http://localhost:4200/reset?Email={0} \">CLICK HERE TO VERIFY</a> </p>", toUserEmail);
            }
                mailMessage.Body = mailBody.ToString();

            smtpClient.Send(mailMessage);

        }
    }
}
