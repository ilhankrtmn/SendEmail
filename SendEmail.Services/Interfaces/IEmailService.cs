using SendEmail.Services.Models;

namespace SendEmail.Services.Interfaces
{
	public interface IEmailService
	{
		void SendMail(SendMailRequestDto sendMailRequestDto);
	}
}