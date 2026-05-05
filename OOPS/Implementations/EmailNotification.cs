using System;
using System.Net;
using System.Net.Mail;
using NotificationApp.Interfaces;

namespace NotificationApp.Implementations
{
    public class EmailNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            try
            {
                string fromEmail = "busbook96@gmail.com";
                string appPassword = Environment.GetEnvironmentVariable("EMAIL_APP_PASSWORD") ?? string.Empty;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(recipient);
                mail.Subject = "Notification";
                mail.Body = message;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true
                };

                smtp.Send(mail);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email failed: " + ex.Message);
            }
        }
    }
}