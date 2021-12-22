using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Dtos;
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
    public class ShopItemController : Controller
    {
        private DataContext _context;
        private readonly ShopItemService _shopItemService;

        public ShopItemController(DataContext context, ShopItemService shopItemService)
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
            int shopId = 1;
            List<ShopItem> items = _shopItemService.List(shopId, _context);
            return View(items);
        }
        public IActionResult GroceriesIndex()
        {
            int shopId = 2;
            List<ShopItem> items = _shopItemService.List(shopId, _context);
            return View(items);
        }

        public IActionResult ShopItemAdd()
        {
            //ShopItem shopItem = new ShopItem();
            CreateShopItem createShopItem = new CreateShopItem()
            {
                ShopItem = new ShopItem(),
                ShopList = _context.Shops.ToList(),
            };
            return View(createShopItem);
        }
        [HttpPost]
        public IActionResult ShopItemAdd(CreateShopItem createShopItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createShopItem);
                }

                _shopItemService.ShopItemAdd(createShopItem, _context);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ShopItemError");
            }
        }
        public IActionResult ShopItemUpdate(int Id)
        {
            try
            {
                CreateShopItem createShopItem = new CreateShopItem()
                {
                    ShopItem = _context.ShopItems.Find(Id),
                    ShopList = _context.Shops.ToList(),
                };
                return View(createShopItem);
            }
            catch
            {
                return View("ShopItemError");
            }
        }
        [HttpPost]
        public IActionResult ShopItemUpdate(CreateShopItem createShopItem)
        {
            _shopItemService.ShopItemUpdate(createShopItem, _context);
            return RedirectToAction("Index");
        }
        public IActionResult ShopItemDelete(int Id)
        {
            _shopItemService.ShopItemDelete(Id, _context);
            return RedirectToAction("Index");
        }
        public IActionResult ShopItemError()
        {
            return View();
        }
    }
}
