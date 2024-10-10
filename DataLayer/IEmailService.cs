using System;
using System.Net;
using System.Net.Mail;

namespace Model // Ensure this is the correct namespace
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("1b842df6eba628", "dfbced13c4921e"),
                EnableSsl = true
            };
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var mailMessage = new MailMessage("angelicalherrera02@gmail.com", toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            _smtpClient.Send(mailMessage);
            Console.WriteLine("Email sent to: " + toEmail);
        }
    }
}
