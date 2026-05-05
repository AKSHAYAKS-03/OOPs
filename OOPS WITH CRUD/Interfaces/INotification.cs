using OOPS_WITH_CRUD.Models;

namespace OOPS_WITH_CRUD.Interfaces
{
    interface INotification
    {
        void Send(string message, User user);
    }
}