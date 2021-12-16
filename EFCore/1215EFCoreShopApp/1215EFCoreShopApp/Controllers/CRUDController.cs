using _1215EFCoreShopApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Controllers
{
    public class CRUDController : Controller
    {
        private DataContext _context;

        public CRUDController(DataContext context)
        {
            _context = context;
        }
        public IActionResult ShopItemAdmin()
        {
            return View();
        }
        public IActionResult ShopAdmin()
        {
            return View();
        }

    }
}
