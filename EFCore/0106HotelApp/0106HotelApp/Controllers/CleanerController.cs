using _0106HotelApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Controllers
{
    public class CleanerController : Controller
    {
        private CleanerRepository _cleanerRepository;
        public CleanerController(CleanerRepository cleanerRepository)
        {
            _cleanerRepository = cleanerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CleanerController cleaner)
        {
            return RedirectToAction("Add");
        }
    }
}
