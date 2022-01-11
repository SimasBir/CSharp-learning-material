using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Hotel : Entity
    {
        public City City { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [MinLength(2)]
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
