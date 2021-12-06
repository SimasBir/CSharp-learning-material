using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1206ConsoleApplication.Enemies
{
    public class AngryRabbit : NPC
    {

        public string Name { get; set; } = "discontent rabbit";
        public void UltraSonicKick()
        {
            Console.WriteLine("You kick enemy and deal -15 damage");
        }
        //public void Attack()
        //{
        //    Console.WriteLine("You FASTLY attacked an enemy");
        //}
    }
}
