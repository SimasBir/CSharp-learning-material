using C5BookStoreApplication.Models;
using System;
using System.Collections.Generic;

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
                Console.WriteLine("Write your commands (add, list or exit): ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        Console.WriteLine("add");
                        Console.WriteLine("Enter the title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the description");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter the amount");
                        try
                        {
                        int amount = Convert.ToInt32(Console.ReadLine());

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Not a number, try again");
                            break;
                        }

                        var book = new Books();
                        library.Add(book);

                        break;

                    case "list":
                        Console.WriteLine("list");

                        Console.WriteLine("Executing list");
                        foreach (var entry in library)
                        {
                            Console.WriteLine($"Title: {entry.Title}, Description: {entry.Description}, Amount: {entry.Amount}");
                        }
                        break;

                    case "exit":
                        Console.WriteLine("exit");
                        exit = true;
                        break;


                }
            }

        }
    }
}
