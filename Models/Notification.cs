using System;

namespace NotificationApp.Models
{
    public class Notification
    {
        public string Message { get; private set; }
        public DateTime SentDate { get; private set; }

        public Notification(string message)
        {
            Message = message?.Trim() ?? string.Empty;

            // if mess is not null then trim it = '?'
            SentDate = DateTime.Now;
        }
    }
}