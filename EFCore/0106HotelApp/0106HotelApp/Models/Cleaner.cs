using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Cleaner : Entity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
        public City City { get; set; }
        [Required]
        public int CityId { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
    }
}
