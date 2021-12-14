using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1214MechanicsApp.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Manifacturer { get; set; }
        public int Year { get; set; }
        public int AssignedId { get; set; }
        public int AssignedName { get; set; }
        public int AssignedSurname { get; set; }
    }
}
