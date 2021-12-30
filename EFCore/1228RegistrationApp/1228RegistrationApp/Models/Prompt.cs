using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1228RegistrationApp.Models
{
    public class Prompt : Entity
    {
        [Required]
        public string Description { get; set; }
        public int? ValueId { get; set; }
        public int ValueGroupId { get; set; }
        public Value Values { get; set; }
    }
}
