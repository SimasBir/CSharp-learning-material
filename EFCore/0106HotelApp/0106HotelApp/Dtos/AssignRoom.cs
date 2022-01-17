using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Dtos
{
    public class AssignRoom
    {
        public Cleaner Cleaner { get; set; }
        public int RoomId { get; set; }
        public List<Room> AllRooms { get; set; }
        public List<CleanerRoom> AssignedRooms { get; set; }
    }
}
