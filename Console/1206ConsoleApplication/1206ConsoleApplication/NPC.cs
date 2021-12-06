using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1206ConsoleApplication
{
    public class NPC
    {
        public string Name { get; set; }
        public int Level { get; set; } = 3; //Default level
        public int Hitpoints { get; set; }
        public int Dexterity { get; set; }

        public void Attack()
        {
            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            if (randomBool)
            {
                Console.WriteLine("You attacked the enemy and won!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You attacked the enemy and lost!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
            }
        }

    }
}
