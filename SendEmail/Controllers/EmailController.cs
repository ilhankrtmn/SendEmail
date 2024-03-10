using Microsoft.AspNetCore.Mvc;
using SendEmail.Services.Interfaces;
using SendEmail.Services.Models;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public void SendEmail(SendMailRequestDto sendMailRequestDto)
        {
            _emailService.SendMail(sendMailRequestDto);
        }
    }
}