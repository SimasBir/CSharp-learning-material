using _1206ConsoleApplication.Enemies;
using System;

namespace _1206ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Alligator al1 = new Alligator()
            {
                Name = "Ally the gator",
                Level = 1,
                Hitpoints = 10,
            };
            AngryRabbit rab1 = new AngryRabbit()
            {
                Name = "Rabi the rabbit",
                Hitpoints = 5,
            };
            Boar bor1 = new Boar()
            {
                Name = "Josh",
                Hitpoints = 15,
            };
            Random random = new Random();
            bool alive = true;
            while (alive)
            {
                int number = random.Next(1, 4);
                Console.Write("You are attacked by a ");
                string answer = "";

                switch (number)
                {
                    case 1:
                        Console.WriteLine(al1.Name);
                        Console.WriteLine("Do you wish to attack the " + al1.Name + "?");
                        answer = Console.ReadLine();
                        if (answer.ToLower() == "yes")
                        {
                            al1.Attack();
                        }
                        else
                        {
                            Dead();
                            alive = false;
                        }
                        break;
                    case 2:
                        Console.WriteLine(rab1.Name);
                        Console.WriteLine("Do you wish to attack the " + rab1.Name + "?");
                        answer = Console.ReadLine();
                        if (answer.ToLower() == "yes")
                        {
                            rab1.Attack();

                        }
                        else
                        {
                            Dead();
                            alive = false;
                        }
                        break;
                    case 3:
                        Console.WriteLine(bor1.Name);
                        Console.WriteLine("Do you wish to attack the " + bor1.Name + "?");
                        answer = Console.ReadLine();
                        if (answer.ToLower() == "yes")
                        {
                            bor1.Attack();
                        }
                        else
                        {
                            Dead();
                            alive = false;
                        }
                        break;
                }
            }
        }

        static void Dead()
        {

            Console.WriteLine("You died");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
        }
    }
}
