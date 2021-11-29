using C5BookStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C5BookStoreApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var library = new List<Books>();
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Write your commands (add, list, delete, update or exit): ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "add":

                        Console.Write("Enter the title: ");
                        string title = Console.ReadLine();
                        foreach (var book in library)
                        {
                            if (title.ToLower() == book.Title.ToLower())
                            {
                                Console.WriteLine("Such book already exists, try again");
                                goto End;
                            }

                        }

                        Console.Write("Enter the description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter the amount: ");
                        try
                        {
                            int amount = Convert.ToInt32(Console.ReadLine());
                            var book = new Books(title, description, amount);
                            library.Add(book);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Not a number, try again");
                            break;
                        }
                    End: break;

                    case "list":
                        foreach (var Books in library)
                        {
                            Console.WriteLine($"Title: {Books.Title}, Description: {Books.Description}, Amount: {Books.Amount}");
                        }
                        break;

                    case "exit":
                        exit = true;
                        break;

                    case "delete":
                        Console.Write("Enter the title you wish to delete: ");
                        string delete = Console.ReadLine();
                        library = library.Where(t => t.Title.ToLower() != delete.ToLower()).ToList();
                        //library = library.removeAll(x => x.Name == delete)
                        Console.WriteLine("Entry deleted");
                        break;

                    case "update":

                        Console.Write("Enter which title you wish to update: ");
                        try
                        {
                            string update = Console.ReadLine();
                            bool alreadyExist = library.Exists(t => t.Title.ToLower() == update.ToLower());
                            if (alreadyExist)
                            {
                                Console.Write("Enter new description: ");
                                string newDesc = Console.ReadLine();
                                if (newDesc != "")
                                {
                                    library.Where(t => t.Title.ToLower() == update.ToLower()).ToList().ForEach(x => x.Description = newDesc);
                                    Console.WriteLine("Description changed");
                                }
                                Console.Write("Enter new amount: ");
                                int newAm = Convert.ToInt32(Console.ReadLine());
                                library.Where(t => t.Title.ToLower() == update.ToLower()).ToList().ForEach(x => x.Amount = newAm);
                                Console.WriteLine("Amount updated");
                            }
                            else
                            {
                                Console.WriteLine("No such entry");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("New amount must be a number");
                            break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
