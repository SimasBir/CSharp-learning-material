using _1214MechanicsApp.Models;
using _1214MechanicsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _1214MechanicsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarService _carService;
        private readonly MechanicService _mechanicService;
        private SqlConnection _sqlConnection;



        public HomeController(CarService carService, MechanicService mechanicService, SqlConnection sqlConnection)
        {
            _carService = carService;
            _mechanicService = mechanicService;
            _sqlConnection = sqlConnection;
        }

        public IActionResult Index()
        {
            List<CarModel> carModels = _carService.GetAll(_sqlConnection);
            return View(carModels);
        }

        public IActionResult CarAdmin()
        {
            return View();
        }


        public ActionResult CarSendSubmit(CarModel model)
        {
            try
            {
                _carService.Add(model, _sqlConnection);
                return RedirectToAction("CarAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult CarSendDelete(string Id)
        {
            try
            {
                _carService.Delete(Id, _sqlConnection);
                return RedirectToAction("CarAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult CarSendUpdate(CarModel model)
        {
            try
            {
                _carService.Update(model, _sqlConnection);
                return RedirectToAction("CarAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult MechanicAdmin()
        {
            return View();
        }
        public IActionResult MechanicList()
        {
            List<MechanicModel> mechanicList = _mechanicService.GetAll(_sqlConnection);
            return View(mechanicList);
        }

        public ActionResult MechanicSendSubmit(MechanicModel model)
        {
            try
            {
                _mechanicService.Add(model, _sqlConnection);
                return RedirectToAction("MechanicAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult MechanicSendDelete(string Id)
        {
            try
            {
                _mechanicService.Delete(Id, _sqlConnection);
                return RedirectToAction("MechanicAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult MechanicSendUpdate(MechanicModel model)
        {
            try
            {
                _mechanicService.Update(model, _sqlConnection);
                return RedirectToAction("MechanicAdmin");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
