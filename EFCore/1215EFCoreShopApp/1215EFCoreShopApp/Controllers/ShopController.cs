using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using _1215EFCoreShopApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Controllers
{
    public class ShopController : Controller
    {
        private DataContext _context;
        private readonly ShopService _shopService;

        public ShopController(DataContext context, ShopService shopService)
        {
            _context = context;
            _shopService = shopService;
        }

        public IActionResult ShopIndex()
        {
            List<Shop> shops = _shopService.ListAllShops(_context);
            return View(shops);
        }
        public IActionResult ShopAdd()
        {
            Shop shop = new Shop();
            return View(shop);
        }
        [HttpPost]
        public IActionResult ShopAdd(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            _shopService.ShopAdd(shop, _context);
            return RedirectToAction("ShopIndex");
        }
        public IActionResult ShopUpdate(int Id)
        {
            Shop shop = _context.Shops.Find(Id);
            return View(shop);
        }
        [HttpPost]
        public IActionResult ShopUpdate(Shop shop)
        {
            _shopService.ShopUpdate(shop, _context);
            return RedirectToAction("ShopIndex");
        }
        public IActionResult ShopDelete(int Id)
        {
            try
            {
                _shopService.ShopDelete(Id, _context);
                return RedirectToAction("ShopIndex");
            }
            catch
            {
                return RedirectToAction("ShopError");
            }
        }
        public IActionResult ShopError()
        {
            return View();
        }
        
        public IActionResult ShopReactivate(int Id)
        {
            _shopService.ShopReactivate(Id, _context);
            return RedirectToAction("ShopIndex");
        }
    }
}
