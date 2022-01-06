using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1228RegistrationApp.Models
{
    public class Value : Entity
    {
        [Required]
        public string Description { get; set; }
        public int ValueGroup { get; set; }
        public List<Prompt> Prompts { get; set; }
    }
}
