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
            return _context.Cleaners.Include(c => c.City).Where(c => c.CityId == Id).ToList();
        }
        //Todos.Include(i => i.Category).Include(i => i.TodoTags).ThenInclude(tt => tt.Tag).ToList();
    }
}
