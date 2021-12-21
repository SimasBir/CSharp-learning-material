using _1215EFCTodoListApp.Data;
using _1215EFCTodoListApp.Dtos;
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
            //List<Todo> todos = _context.Todos.ToList();

            List<Todo> todos = _context.Todos.Include(t => t.TodoTags).ThenInclude(t=> t.Tag).ToList(); //many to many
            return View(todos);
        }
        public IActionResult Add()
        {
            var createTodo = new CreateTodo()
            {
                Todo = new Todo(),
                AllCategories = _context.Categories.ToList(),
                Tags = _context.Tags.ToList(),
            };
            return View(createTodo);
        }
        [HttpPost]
        public IActionResult Add(CreateTodo createTodo)
        {
            if (!ModelState.IsValid)
            {
                createTodo.AllCategories = _context.Categories.ToList();
                return View(createTodo);
            }
            _context.Todos.Add(createTodo.Todo);

            _context.SaveChanges();

            // Inserting Tags

            foreach (var tagId in createTodo.SelectedTagIds)
            {
                _context.TodoTags.Add(new TodoTag()
                {
                    TagId = tagId,
                    TodoId = createTodo.Todo.Id
                });
            }
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
