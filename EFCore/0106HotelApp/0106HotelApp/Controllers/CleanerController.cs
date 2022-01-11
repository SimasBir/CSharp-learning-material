using _0106HotelApp.Dtos;
using _0106HotelApp.Models;
using _0106HotelApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Controllers
{
    public class CleanerController : Controller
    {
        private CleanerRepository _cleanerRepository;
        private CityRepository _cityRepository;
        public CleanerController(CleanerRepository cleanerRepository, CityRepository cityRepository)
        {
            _cleanerRepository = cleanerRepository;
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            return View(_cleanerRepository.GetAll());
        }
        public IActionResult SelectIndex(int Id)
        {
            return View(_cleanerRepository.GetSome(Id));
        }
        public IActionResult Add()
        {
            CreateCleaner createCleaner = new CreateCleaner()
            {
                Cleaner = new Cleaner(),
                AllCities = _cityRepository.GetAll()
            };
            return View(createCleaner);
        }
        [HttpPost]
        public IActionResult Add(CreateCleaner createCleaner)
        {
            if (!ModelState.IsValid)
            {
                createCleaner.AllCities = _cityRepository.GetAll();
                return View();
            }
            _cleanerRepository.Create(createCleaner.Cleaner);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _cleanerRepository.Delete(id);

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            CreateCleaner createCleaner = new CreateCleaner()
            {
                Cleaner = _cleanerRepository.GetById(id),
                AllCities = _cityRepository.GetAll()
            };
            return View(createCleaner);
        }
        [HttpPost]
        public IActionResult Update(CreateCleaner createCleaner)
        {
            if (!ModelState.IsValid)
            {
                createCleaner.AllCities = _cityRepository.GetAll();
                return View(createCleaner);
            }
            _cleanerRepository.Update(createCleaner.Cleaner);
            return RedirectToAction("Index");
        }
    }
}
