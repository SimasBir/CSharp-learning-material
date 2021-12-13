using _1213ZooApp2.Models;
using _1213ZooApp2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _1213ZooApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZooService2 _zooService2;
        private readonly SponsorService _sponsorService;
        private SqlConnection _sqlConnection;

        public HomeController(ZooService2 zooService, SponsorService sponsorService, SqlConnection sqlConnection)
        {
            _zooService2 = zooService;
            _sponsorService = sponsorService;
            _sqlConnection = sqlConnection;
        }
        public IActionResult Index()
        {
            List<ZooModel2> zooList = _zooService2.GetAll(_sqlConnection);
            return View(zooList);
        }
        public ActionResult AnimalManagement()
        {
            return View();
        }
        public ActionResult ZooSendSubmit(ZooModel2 model)
        {
            _zooService2.Add(model, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }

        public ActionResult ZooSendDelete(string Id)
        {
            _zooService2.Delete(Id, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }

        public ActionResult ZooSendUpdate(ZooModel2 model)
        {
            _zooService2.Update(model, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }
        public ActionResult ZooClearReset(ZooModel2 model)
        {
            _zooService2.ClearTable(_sqlConnection);
            return RedirectToAction("Index");
        }


        public IActionResult SponsorsList()
        {
            List<SponsorModel> sponsorList = _sponsorService.GetAll(_sqlConnection);
            return View(sponsorList);
        }
        public IActionResult Sponsors()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
