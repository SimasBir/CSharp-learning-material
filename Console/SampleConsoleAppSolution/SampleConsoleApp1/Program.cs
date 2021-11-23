// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// var randomNumber = "5" + true;

using SampleConsoleApp1;
using System;


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var dog1 = new Dog();
            var dog2 = new Dog();

            dog1.Bark();
            dog2.Bark();

            Dog.StaticBark();
                        
            //var randomNumber = "5";
            var randomNumber = GetNumber();
            PrintInfo(randomNumber);
        }

        public static void PrintInfo(int info) /*Arba string*/
        {
            Console.WriteLine(info);
        }

        public static int GetNumber()
        {
            return 5*2;
        }
    }
}
            