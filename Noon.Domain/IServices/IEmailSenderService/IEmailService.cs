using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.IServices.IEmailSenderService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string Subject, string body);
    }
}
