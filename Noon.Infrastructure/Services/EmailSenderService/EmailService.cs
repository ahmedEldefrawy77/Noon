using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Noon.Domain.IServices.IEmailSenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Services.EmailSenderService
{
    public class EmailService : IEmailService

    {
        public Task SendEmailAsync(string email, string Subject, string body)
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse("DevSupTeamN@gmail.com"));
            mail.To.Add(MailboxAddress.Parse(email));
            mail.Subject = Subject;
            mail.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("DevSupTeamN@gmail.com", "juoterwmqnkaggft");
            smtp.Send(mail);
            smtp.Disconnect(true);
            return Task.CompletedTask;
        }
    }
}
