using System;
using NotificationApp.Services;
using NotificationApp.Interfaces;
using NotificationApp.Implementations;
using NotificationApp.Models;
using NotificationApp.Exceptions;

namespace NotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Notification System ===\n");

            Console.Write("Enter your name: ");
            string systemUserName = Console.ReadLine() ?? string.Empty;
            var systemUser = new User(systemUserName, string.Empty, string.Empty);

            var service = new NotificationService();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1) Send Email");
                Console.WriteLine("2) Send SMS");
                Console.WriteLine("3) Exit");
                Console.Write("Choose option: ");
                var choice = Console.ReadLine() ?? string.Empty;

                if (choice == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                INotification notification = null;
                string prompt = "Recipient (email or phone): ";

                switch (choice)
                {
                    case "1":
                        notification = new EmailNotification();
                        prompt = "Enter recipient Email: ";
                        break;
                    case "2":
                        notification = new SmsNotification();
                        prompt = "Enter recipient Phone (Eg +911234567890): ";
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        continue;
                }

                Console.Write(prompt);
                var recipient = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter message: ");
                var message = Console.ReadLine() ?? string.Empty;

                try
                {
                    bool ok = service.SendNotification(notification, recipient, message);
                    if (ok)
                    {
                        Console.WriteLine("Notification processed successfully.");
                    }
                }
                catch (ValidationException vex)
                {
                    Console.WriteLine("Validation error: " + vex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}