using System;

namespace NotificationApp.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public DateTime SentDate { get; set; }

        public Notification(string message)
        {
            Message = message;
            SentDate = DateTime.Now;
        }
    }
}