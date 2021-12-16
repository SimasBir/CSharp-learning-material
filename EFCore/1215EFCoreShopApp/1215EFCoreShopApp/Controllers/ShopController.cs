using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Controllers
{
    public class ShopController : Controller
    {
        private DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ShopItem> items = _context.ShopItems.Include(i => i.Shops).ToList();
            return View(items);
        }
        public IActionResult ElectronicsIndex()
        {
            
            List<ShopItem> items = _context.Shops.Include(i => i.ShopItems).Where(s => s.Id == 1).SelectMany(i => i.ShopItems).ToList();
            return View(items);
        }
        public IActionResult GroceriesIndex()
        {
            List<ShopItem> items = _context.Shops.Include(i => i.ShopItems).Where(s => s.Id == 2).SelectMany(i => i.ShopItems).ToList();
            return View(items);
        }
    }
}
