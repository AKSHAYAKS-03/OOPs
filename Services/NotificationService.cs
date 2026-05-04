using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Utilities;
using NotificationApp.Exceptions;

namespace NotificationApp.Services
{
    public class NotificationService
    {
        public bool SendNotification(INotification notificationType, string recipient, string message)
        {
            if (notificationType == null) throw new ValidationException("Notification type is required.");

            if (!Validator.IsValidMessage(message))
                throw new ValidationException("Message is not valid.");

            bool recipientIsEmail = Validator.IsValidEmail(recipient);
            bool recipientIsPhone = Validator.IsValidPhone(recipient);

            if (!recipientIsEmail && !recipientIsPhone)
                throw new ValidationException("Recipient must be a valid email or phone number.");

            // send
            notificationType.Send(recipient, message);
            return true;
        }
    }
}