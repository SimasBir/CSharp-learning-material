using _1215EFCoreShopApp.Controllers;
using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Services
{
    public class ShopService
    {
        public List<Shop> ListAllShops(DataContext dataContext)
        {
            List<Shop> shops = dataContext.Shops.IgnoreQueryFilters().ToList();
            return shops;
        }
        public void ShopAdd(Shop shop, DataContext dataContext)
        {
            dataContext.Shops.Add(shop);
            dataContext.SaveChanges();
        }
        public void ShopUpdate(Shop shop, DataContext dataContext)
        {
            dataContext.Shops.Update(shop);
            dataContext.SaveChanges();
        }
        public void ShopDelete(int Id, DataContext dataContext)
        {
            Shop shop = dataContext.Shops.Find(Id);
            dataContext.Shops.Remove(shop);
            dataContext.SaveChanges();
        }
        public void ShopReactivate(int Id, DataContext dataContext)
        {
            Shop shop = dataContext.Shops.IgnoreQueryFilters().Single(x => x.Id == Id);
            shop.IsDeleted = false;
            //dataContext.Shops.Update(shop);
            dataContext.SaveChanges();
        }
    }
}
