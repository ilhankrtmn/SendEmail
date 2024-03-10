using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using SendEmail.Services.Interfaces;
using SendEmail.Services.Configuraions;
using SendEmail.Services.Models;

namespace SendEmail.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void SendMail(SendMailRequestDto sendMailRequestDto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailConfiguration.From));
            email.To.Add(MailboxAddress.Parse(sendMailRequestDto.MailTo));
            email.Subject = sendMailRequestDto.Subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = sendMailRequestDto.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
