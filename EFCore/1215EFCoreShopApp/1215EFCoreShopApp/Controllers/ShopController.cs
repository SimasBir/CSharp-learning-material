using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using _1215EFCoreShopApp.Services;
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
        private readonly ShopItemService _shopItemService;

        public ShopController(DataContext context, ShopItemService shopItemService)
        {
            _context = context;
            _shopItemService = shopItemService;
        }

        public IActionResult Index()
        {
            List<ShopItem> items = _shopItemService.ListAll(_context);
            return View(items);
        }
        public IActionResult ElectronicsIndex()
        {
            List<ShopItem> items = _shopItemService.List(1, _context);
            return View(items);
        }
        public IActionResult GroceriesIndex()
        {
            List<ShopItem> items = _shopItemService.List(2, _context);
            return View(items);
        }
    }
}
