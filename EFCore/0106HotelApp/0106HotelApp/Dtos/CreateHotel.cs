using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Dtos
{
    public class CreateHotel
    {
        public Hotel Hotel { get; set; }
        public List<City> AllCities { get; set; }
    }
}
