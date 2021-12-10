using _1209ZooApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _1209ZooApp.Controllers
{
    public class ZooController : Controller
    {
        private readonly ZooService _zooService;
        private SqlConnection _sqlConnection;

        public ZooController(ZooService zooService, SqlConnection sqlConnection)
        {
            _zooService = zooService;
            _sqlConnection = sqlConnection;
        }

        public ActionResult Index()
        {
            List<ZooModel> zooList = _zooService.GetAll(_sqlConnection);
            return View(zooList);
        }

        public ActionResult AnimalManagement()
        {
            return View();
        }

        public ActionResult SendSubmit(ZooModel model)
        {
            _zooService.Add(model, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }

        public ActionResult SendDelete(string name)
        {
            _zooService.Delete(name, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }

        public ActionResult SendUpdate(ZooModel model)
        {
            _zooService.Update(model, _sqlConnection);
            return RedirectToAction("AnimalManagement");
        }
    }
}
