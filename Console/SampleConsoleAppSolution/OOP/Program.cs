using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Ramunas");
            names.Add("Vaidas");
            names.Add("Tautvydas");
            names.Add("Kitas Ramunas");

            List<string> first = new List<string>() { "first", "second", "third"};
            List<string> second = new List<string>() { "fourth", "fifth" };

            names.AddRange(first);
            names.AddRange(second);

            foreach ( string vardas in names)
            {
                Console.WriteLine(vardas);
            }
            Console.WriteLine("");

            names.Remove("first");
            names.RemoveAt(0);
            names.ForEach(elementas => { Console.WriteLine(elementas); });
            Console.WriteLine(names.Count);

            
        }
    }
}
