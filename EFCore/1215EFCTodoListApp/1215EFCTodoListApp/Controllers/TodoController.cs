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
            //List<Todo> todos3 =
            //    _context.Categories.Include(c => c.Todos) //.Include is required to load child objects
            //    .Where(c => c.Name == "Category1")
            //    .SelectMany(c => c.Todos)
            //    .ToList();
            //List<Todo> todos4 = _context.Todos.Where(t => t.Description != null).ToList();
            //List<Todo> todos2 = _context.Todos.Take(2).ToList();
            List<Todo> todos = _context.Todos.ToList();

            return View(todos);
        }
        public IActionResult Add()
        {
            var todo = new Todo();
            return View(todo);
        }
        [HttpPost]
        public IActionResult Add(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var todo = _context.Todos.Find(Id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var todo = _context.Todos.Find(Id);
            return View(todo);
        }
        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
