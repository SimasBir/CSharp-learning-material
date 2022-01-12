using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Dtos
{
    public class CreateHotelRoom
    {
        public List<Room> Rooms { get; set; }
        public int SelectedHotel { get; set; }
        public List<CleanerRoom> AssignedRooms { get; set; }
    }
}
