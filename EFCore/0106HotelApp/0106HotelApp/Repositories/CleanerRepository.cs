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
            List<Cleaner> allCityCleaners = _context.Cleaners.Include(c => c.City).Where(c => c.CityId == Id).
                Include(b => b.CleanerRooms).ThenInclude(cr => cr.Room).
                ToList();
            return allCityCleaners;
        }
        public List<Cleaner> GetSomeFiltered(int Id)
        {
            var allCityCleaners = GetSome(Id);
            List<Cleaner> freeCleaners = new List<Cleaner>();
            foreach (Cleaner cleaner in allCityCleaners)
            {
                int assignedRooms = _context.CleanerRooms.Where(a => a.Cleaned == false).Where(b => b.CleanerId == cleaner.Id).Count();
                if (assignedRooms < 5)
                {
                    freeCleaners.Add(cleaner);
                }
            }
            return freeCleaners;
        }
        public List<CleanerRoom> AssignedRooms(int Id)
        {
            return _context.CleanerRooms.Where(c => c.CleanerId == Id).Where(b=>b.Cleaned==false).Include(r => r.Room).ThenInclude(rr => rr.Hotel).ToList();
        }
    }
}
