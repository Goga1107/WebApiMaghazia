using System.Net.Mail;
using System.Net;

namespace WebApiMaghazia.Repository
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendOTPEmailAsync(string email, string message)
        {
            var username = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];
            var fromEmail = _configuration["EmailSettings:From"];
            var host = _configuration["EmailSettings:Host"]; // Ensure this is set correctly

            using (var client = new SmtpClient(host))
            {
                client.Port = int.Parse(_configuration["EmailSettings:Port"]);
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "Message From Nothing",
                    Body = $"zdarova jigoo {message}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);

                return email;
            }
        }
    }
}
