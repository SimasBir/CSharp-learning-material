using _1207ToDoListWebApp.Models;
using _1207ToDoListWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _1207ToDoListWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataService _dataService;
        private readonly TxtServiceW _txtService;

        public HomeController(ILogger<HomeController> logger, DataService dataService, TxtServiceW txtService)
        {
            _logger = logger;
            _dataService = dataService;
            _txtService = txtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddNewTodo()
        {
            var emptyModel = new TaskModel()
            {
                Name = "",
                Description = ""
            };
            return View(emptyModel);
        }
        public IActionResult SendSubmitData(TaskModel model)
        {
            _dataService.Add(model);
            return RedirectToAction("AddNewTodo");

        }

        public IActionResult DisplayTodoList()
        {
            var tasks = _dataService.GetAll();
            var taskList = new TaskListModel()
            {
                Tasks = tasks
            };
            return View(taskList);
        }

        public IActionResult ToTextFile()
        {
            var emptyModel = new TaskModel()
            {
                Name = "",
                Description = ""
            };
            return View(emptyModel);
        }

        public IActionResult SendSubmitText(TaskModel model)
        {
            _txtService.Add(model);
            return RedirectToAction("ToTextFile");
        }
        public IActionResult SendDeleteText(TaskModel model)
        {
            _txtService.Delete(model);
            return RedirectToAction("ToTextFile");
        }

        public IActionResult TextFile()
        {

            var tasks = _txtService.GetAll();
            var taskList = new TaskListModel()
            {
                Tasks = tasks
            };
            return View(taskList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
