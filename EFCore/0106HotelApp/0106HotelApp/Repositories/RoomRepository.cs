using _0106HotelApp.Data;
using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Repositories
{
    public class RoomRepository : RepositoryBase<Room>
    {
        public RoomRepository(DataContext context) : base(context)
        {

        }
    }
}
