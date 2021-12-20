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
    public class ShopItemService
    {
        public List<ShopItem> ListAll(DataContext dataContext)
        {
            List<ShopItem> items = dataContext.ShopItems.Include(i => i.Shops).ToList();
            return items;
        }
        public List<ShopItem> List(int shopId, DataContext dataContext)
        {
            List<ShopItem> items = dataContext.Shops.Include(i => i.ShopItems).Where(s => s.Id == shopId).SelectMany(i => i.ShopItems).ToList();
            return items;
        }
        public void ShopItemAdd(ShopItem shopitem, DataContext dataContext)
        {
            dataContext.ShopItems.Add(shopitem);
            dataContext.SaveChanges();
        }
        public void ShopItemUpdate(ShopItem shopitem, DataContext dataContext)
        {
            dataContext.ShopItems.Update(shopitem);
            dataContext.SaveChanges();
        }
        public void ShopItemDelete(int Id, DataContext dataContext)
        {
            ShopItem shopItem = dataContext.ShopItems.Find(Id);
            dataContext.ShopItems.Remove(shopItem);
            dataContext.SaveChanges();
        }
    }
}
