using System;
using OOPS_WITH_CRUD.Interfaces;
using OOPS_WITH_CRUD.Models;

namespace OOPS_WITH_CRUD.Services
{
    class SmsNotification : INotification
    {
        public void Send(string message, User user)
        {
            Console.WriteLine($"SMS sent to {user.Phone}: {message}");
        }
    }
}