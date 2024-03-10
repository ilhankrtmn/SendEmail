namespace SendEmail.Services.Models
{
    public class SendMailRequestDto
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}