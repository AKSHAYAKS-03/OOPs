using System;
using OOPS_WITH_CRUD.Interfaces;
using OOPS_WITH_CRUD.Models;
using OOPS_WITH_CRUD.Utilities;
using OOPS_WITH_CRUD.Services;
using OOPS_WITH_CRUD.Repositories;

namespace OOPS_WITH_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            NotificationService notificationService = new NotificationService();

            while (true)
            {
                Console.WriteLine("\n1.Add 2.View 3.Update 4.Delete 5.Send Notification 6.Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                if(choice == 0)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                    continue;
                }

                switch(choice)
                {
                    case 1:
                        var user = new User();

                        Console.Write("\nEnter Name: ");
                        user.Name = Console.ReadLine() ?? "";
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine() ?? "";
                        if(!Validator.IsValidEmail(email))
                        {
                            Console.WriteLine("Invalid email format!");
                            break;
                        }
                        user.Email = email;
                        Console.Write("Enter Phone: ");
                        string phone = Console.ReadLine() ?? "";
                        if(!Validator.IsValidPhone(phone))
                        {
                            Console.WriteLine("Invalid phone format!");
                            break;
                        }
                        user.Phone = phone;
                      
                        userRepository.Create(user);
                        Console.WriteLine("User added successfully!");
                        break;
                    case 2:

                        var users = userRepository.GetAll();
                        if(users.Count == 0)
                        {
                            Console.WriteLine("No users found!");
                            break;
                        }
                        Console.WriteLine("\nUsers:");
                        foreach(var u in users)
                        {
                            Console.WriteLine(u);
                        }
                        break;

                    case 3:
                        Console.Write("\nEnter Id: ");
                        string uid = Console.ReadLine() ?? "";
                        var existingUser = userRepository.Get(uid);
                        if(existingUser == null) 
                        {
                            Console.WriteLine("User not found!");
                            break;
                        
                        }
                        var updated = new User();
                        Console.Write("Enter Name: ");
                        updated.Name = Console.ReadLine() ?? "";

                        Console.Write("Enter Email: ");
                        string email2 = Console.ReadLine() ?? "";
                        if(!Validator.IsValidEmail(email2))
                        {
                            Console.WriteLine("Invalid email format!");
                            break;
                        }
                        updated.Email = email2;
                        Console.Write("Enter Phone: ");
                        string phone2 = Console.ReadLine() ?? "";
                        if(!Validator.IsValidPhone(phone2))
                        {
                            Console.WriteLine("Invalid phone format!");
                            break;
                        }
                        updated.Phone = phone2;  
                        userRepository.Update(uid,updated);
                        Console.WriteLine("Updated Successfully!");
                        break;
                    
                    case 4:
                        Console.Write("\nEnter Id: ");
                        string uid2 = Console.ReadLine() ?? "";
                        var deletedUser = userRepository.Delete(uid2);
                        if(deletedUser == null)     
                        {
                            Console.WriteLine("User not found!");
                            break;
                        }
                        Console.WriteLine("Deleted Successfully!");
                        break;
                    
                    case 5:
                        Console.Write("\nEnter User Id to send notification: ");
                        string uid3 = Console.ReadLine() ?? "";
                        var userToNotify = userRepository.Get(uid3);
                        if(userToNotify == null)                        
                        {
                            Console.WriteLine("User not found!");
                            break;
                        }

                        Console.Write("\nEnter Message: ");
                        string message = Console.ReadLine() ?? "";

                        if(!Validator.IsValidMessage(message))
                        {
                            Console.WriteLine("Invalid message!");
                            break;
                        }
                        
                        Console.WriteLine("\nChoose Notification Type: 1.Email 2.SMS");
                        string notifChoice = Console.ReadLine() ?? "";

                        if(notifChoice == "1")
                        {
                            notificationService.Send(new EmailNotification(), message, userToNotify);
                            break;
                        }
                        else
                        {
                            notificationService.Send(new SmsNotification(), message, userToNotify);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;
                        
                }
                

            }
        }
    }
}
