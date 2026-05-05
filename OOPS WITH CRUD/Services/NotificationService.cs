using OOPS_WITH_CRUD.Interfaces;
using OOPS_WITH_CRUD.Models;

namespace OOPS_WITH_CRUD.Services
{
    class NotificationService
    {
        public void Send(INotification notification, string message, User user)
        {
            notification.Send(message, user);
        }
    }
}