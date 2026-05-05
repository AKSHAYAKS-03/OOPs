using System;
using OOPS_WITH_CRUD.Interfaces;
using OOPS_WITH_CRUD.Models;

namespace OOPS_WITH_CRUD.Services
{
    class EmailNotification : INotification
    {
        public void Send(string message, User user)
        {
            // Simulate sending an email notification
            Console.WriteLine($"Email sent to {user.Email}: {message}");
        }
    }
}