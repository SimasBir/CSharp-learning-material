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
                Console.WriteLine("Write your commands (add, list, delete or exit): ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "add":

                        Console.WriteLine("Enter the title");
                        string title = Console.ReadLine();
                        foreach(var book in library)
                        {
                            if (title == book.Title)
                            {
                                Console.WriteLine("Such book already exists, try again");
                                goto End;
                            }

                        }
                        
                        Console.WriteLine("Enter the description");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter the amount");
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
                        Console.WriteLine("Enter the title you wish to delete");
                        string delete = Console.ReadLine();
                        library = library.Where(t => t.Title != delete).ToList();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
