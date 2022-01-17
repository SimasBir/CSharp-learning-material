using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Models
{
    public class Room : Entity
    {
        [Range(1,100)]
        public int Number { get; set; }
        [Range(1,5)]
        public int Floor { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public bool Booked { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
        [NotMapped]
        public string NumberHotel { get { return this.Hotel == null ? "" : this.Hotel.Address + " -- " + this.Number.ToString(); } }
    }
}
