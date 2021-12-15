using _1215EFCTodoListApp.Data;
using _1215EFCTodoListApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCTodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Todo> todos3 =
                _context.Categories.Include(c => c.Todos) //This is required to load child objects
                .Where(c => c.Name == "Category1")
                .SelectMany(c => c.Todos)
                .ToList();
            List<Todo> todos = _context.Todos.Where(t => t.Description != null).ToList();
            //List<Todo> todos2 = _context.Todos.Take(2).ToList();
            return View(todos);
        }
    }
}
