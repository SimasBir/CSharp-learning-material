using _1215EFCoreShopApp.Data;
using _1215EFCoreShopApp.Models;
using _1215EFCoreShopApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Controllers
{
    public class TagController : Controller
    {
        private DataContext _context;
        private readonly TagService _tagService;

        public TagController(DataContext context, TagService tagService)
        {
            _context = context;
            _tagService = tagService;
        }

        public IActionResult TagIndex()
        {
            List<Tag> tags = _tagService.ListAllTags(_context);
            return View(tags);
        }

        public IActionResult TagAdd()
        {
            Tag tag = new Tag();

            return View(tag);
        }

        [HttpPost]
        public IActionResult TagAdd(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            _tagService.TagAdd(tag, _context);
            return RedirectToAction("TagIndex");
        }

        public IActionResult TagUpdate(int Id)
        {
            Tag tag = _context.Tags.Find(Id);
            return View(tag);
        }

        [HttpPost]
        public IActionResult TagUpdate(Tag tag)
        {
            _tagService.TagUpdate(tag, _context);
            return RedirectToAction("TagIndex");
        }

        public IActionResult TagDelete(int Id)
        {
            _tagService.TagDelete(Id, _context);
            return RedirectToAction("TagIndex");
        }

        public IActionResult TagError()
        {
            return View();
        }

        public IActionResult TagReactivate(int Id)
        {
            _tagService.TagReactivate(Id, _context);
            return RedirectToAction("TagIndex");
        }
    }
}
