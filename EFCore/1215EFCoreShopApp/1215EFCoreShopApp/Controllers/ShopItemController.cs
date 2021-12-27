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

        public IActionResult DeletedIndex()
        {
            List<ShopItem> items = _shopItemService.ListAllDeleted(_context);
            return View(items);
        }

        public IActionResult ShopItemAdd()
        {
            CreateShopItem item = _shopItemService.ShopItemEmpty(_context);
            return View(item);
        }

        [HttpPost]
        public IActionResult ShopItemAdd(CreateShopItem createShopItem)
        {
            if (!ModelState.IsValid)
            {
                CreateShopItem item = _shopItemService.ShopItemEmpty(_context);
                return View(item);
            }

            _shopItemService.ShopItemAdd(createShopItem, _context);
            return RedirectToAction("Index");
        }

        public IActionResult ShopItemUpdate(int Id)
        {
            CreateShopItem item = _shopItemService.ShopItemFind(Id, _context);
            return View(item);
        }

        [HttpPost]
        public IActionResult ShopItemUpdate(CreateShopItem createShopItem)
        {
            if (!ModelState.IsValid)
            {
                CreateShopItem item = _shopItemService.ShopItemFind(createShopItem.ShopItem.Id, _context);
                return View(item);
            }
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

        public IActionResult ShopItemReactivate(int Id)
        {
            _shopItemService.ShopItemReactivate(Id, _context);
            return RedirectToAction("DeletedIndex");
        }
    }
}
