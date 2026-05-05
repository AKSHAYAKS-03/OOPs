using System;
using OOPS.Interfaces;

namespace OOPS.Implementations
{
    public class SmsNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine("\n--- SMS Notification ---");
            Console.WriteLine($"To: {recipient}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Sent At: {DateTime.Now}");
        }
    }
}