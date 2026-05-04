using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services
{
    public class NotificationService
    {
        public void SendNotification(INotification notificationType, string recipient, string message)
        {
            notificationType.Send(recipient, message);
        }
    }
}