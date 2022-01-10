using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Room : Entity
    {
        public int Floor { get; set; }
        public int HotelId { get; set; }
        public bool Booked { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
    }
}
