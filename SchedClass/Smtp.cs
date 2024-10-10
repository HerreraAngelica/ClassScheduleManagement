using System;
using System.Net;
using System.Net.Mail;


namespace Mailtrap

{
    public class smtp
    {
        private readonly SmtpClient _smtpClient;

        public smtp()
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
	
