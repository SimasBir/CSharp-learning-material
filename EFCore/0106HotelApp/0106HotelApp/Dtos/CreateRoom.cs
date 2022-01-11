using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Dtos
{
    public class CreateRoom
    {
        public Room Room { get; set; }
        public List<Hotel> AllHotels { get; set; }

        //public List<CleanerRoom> AssignedRooms { get; set; }
    }
}
