using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1214MechanicsApp.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public string Manifacturer { get; set; }
        public int Year { get; set; }
        public int AssignedId { get; set; }
        public string AssignedName { get; set; }
        public string AssignedSurname { get; set; }
    }
}
