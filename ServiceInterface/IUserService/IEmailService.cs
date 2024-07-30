using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface.IUserService
{
    public interface IEmailService
    {
        void SendEmail(string toUserEmail,string subject, string MailFor, string randpass);
    }
}
