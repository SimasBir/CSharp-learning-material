using _1228RegistrationApp.Data;
using _1228RegistrationApp.Dtos;
using _1228RegistrationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1228RegistrationApp.Controllers
{
    public class RegistrationController : Controller
    {
        private DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Entry entry = new Entry()
            {
                Prompts = _context.Prompts.Include(i => i.Values).ToList(),
                Values = _context.Values.Include(i => i.Prompts).ToList(),
            };
            return View(entry);
        }
        [HttpPost]
        public IActionResult RegistrationSave(Entry entry, string submit)
        {
            switch (submit)
            {
                case "Saugoti pataisymus":

                    var prompts = _context.Prompts.Include(i => i.Values).ToList();

                    foreach (var prompt in prompts)
                    {
                        prompt.ValueId = entry.Prompts[prompt.Id-1].ValueId;
                        _context.Prompts.Update(prompt);
                    }
                    //_context.Prompts.UpdateRange(entry.Prompts);
                    _context.SaveChanges();
                    break;
                case "Atšaukti pataisymus":
                    break;
            }
            return RedirectToAction("Index");
        }
    }
}
