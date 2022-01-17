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
    public class CleanerRepository : RepositoryBase<Cleaner>
    {
        public CleanerRepository(DataContext context) : base(context)
        {

        }
        public new List<Cleaner> GetAll()
        {
            return _context.Cleaners.Include(c => c.City).ToList();
        }
        public List<Cleaner> GetSome(int Id)
        {
            return _context.Cleaners.Include(c => c.City).Where(c => c.CityId == Id).
                Include(b=>b.CleanerRooms).ThenInclude(cr=>cr.Room).
                ToList();
        }
        public List<CleanerRoom> AssignedRooms(int Id)
        {
            return _context.CleanerRooms.Where(c => c.CleanerId == Id).Where(b=>b.Cleaned==false).Include(r => r.Room).ThenInclude(rr => rr.Hotel).ToList();
        }
    }
}
