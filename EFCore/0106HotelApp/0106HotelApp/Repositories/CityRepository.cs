using _0106HotelApp.Data;
using _0106HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Repositories
{
    public class CityRepository : RepositoryBase<City>
    {
        public CityRepository(DataContext context) : base(context)
        {

        }

        //public void Create(City city)
        //{
        //    base.Create(city);
        //    //_context.SaveChanges();
        //}
    }
}
