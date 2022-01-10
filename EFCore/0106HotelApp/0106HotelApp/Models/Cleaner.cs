using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Cleaner : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CityId { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
    }
}
