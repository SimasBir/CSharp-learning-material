using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class City : Entity
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Cleaner> Cleaners { get; set; }
    }
}
