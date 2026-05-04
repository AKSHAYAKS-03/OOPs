using System;
using NotificationApp.Services;
using NotificationApp.Interfaces;
using NotificationApp.Implementations;

namespace NotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Notification System ===\n");

            Console.Write("Enter Your Name (System User): ");
            string systemUser = Console.ReadLine() ?? "";

            NotificationService service = new NotificationService();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Email");
                Console.WriteLine("2. SMS");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");
                Console.WriteLine();

                string choice = Console.ReadLine() ?? "";

                if (choice == "3")
                {
                    Console.WriteLine("Exiting...\n");
                    break;
                }

                string recipient = "";

                if (choice == "1")
                {
                    Console.Write("Enter recipient Email: ");
                    recipient = Console.ReadLine() ?? "";
                }
                else if (choice == "2")
                {
                    Console.Write("Enter recipient Phone (+91...): ");
                    recipient = Console.ReadLine() ?? "";
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                Console.Write("Enter Message: ");
                string message = Console.ReadLine() ?? "";

                INotification notification = null;

                switch (choice)
                {
                    case "1":
                        notification = new EmailNotification();
                        break;

                    case "2":
                        notification = new SmsNotification();
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        continue;
                }

                if (notification == null)
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                service.SendNotification(notification, recipient, message);
            }
        }
    }
}