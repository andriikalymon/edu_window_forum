using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Forum.Web.Utils
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(
            string fromEmail, string fromPassword, string fromName, string toEmail, string topic, string text )
        {
            MailAddress from = new MailAddress(fromEmail, fromName);
            MailAddress to = new MailAddress(toEmail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = topic;
            message.Body = text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }
    }
}
