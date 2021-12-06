using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1206ConsoleApplication.Enemies
{
    public class Alligator : NPC
    {
        public string Name { get; set; } = "content aligator";
        public void sinkEnemy()
        {
            Console.WriteLine("You drag enemy under water dealing - 20 damage");
        }
    }
}
