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


        private readonly ILogger<ZooController> _logger;
        private readonly ZooService _zooService;
        private SqlConnection _sqlConnection;



        public ZooController(ILogger<ZooController> logger, ZooService zooService, SqlConnection sqlConnection)
        {
            _logger = logger;
            _zooService = zooService;
            _sqlConnection = sqlConnection;

        }
        // GET: ZooController
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



        // GET: ZooController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // POST: ZooController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZooController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZooController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZooController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZooController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
