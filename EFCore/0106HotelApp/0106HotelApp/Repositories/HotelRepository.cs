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
    public class HotelRepository : RepositoryBase<Hotel>
    {
        public HotelRepository(DataContext context) : base(context)
        {

        }
        public new List<Hotel> GetAll()
        {
            return _context.Hotels.Include(c => c.City).ToList();
        }
        public List<Hotel> GetSome(int Id)
        {
            return _context.Hotels.Include(c => c.City).Where(c => c.CityId==Id).ToList();
        }
    }
}
