using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Dtos
{
    public class AssignCleaner
    {
        public Room Room { get; set; }
        //public int RoomId { get; set; }
        public int CleanerId { get; set; }
        public List<Cleaner> AllCleaners { get; set; }
        //public List<CleanerRoom> AssignedRooms { get; set; }
    }
}
