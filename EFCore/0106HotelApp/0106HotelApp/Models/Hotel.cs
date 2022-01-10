using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Hotel : Entity
    {
        public int CityId { get; set; }
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
