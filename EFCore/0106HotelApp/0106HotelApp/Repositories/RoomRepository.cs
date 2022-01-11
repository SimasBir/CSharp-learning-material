using _0106HotelApp.Data;
using _0106HotelApp.Models;
using Microsoft.EntityFrameworkCore;
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
        public new List<Room> GetAll()
        {
            return _context.Rooms.Include(c => c.Hotel).ThenInclude(h => h.City).ToList();
        }
        public List<Room> GetSome(int Id)
        {
            return _context.Rooms.Include(c => c.Hotel).Where(c => c.HotelId == Id).ToList();
        }
    }
}
