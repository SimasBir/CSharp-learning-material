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
    public class CityController : Controller
    {
        private CityRepository _cityRepository;
        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            return View(_cityRepository.GetAll());
        }
        public IActionResult IndexAdmin()
        {
            return View(_cityRepository.GetAll());
        }
        public IActionResult Add()
        {
            City city = new City();
            return View(city);
        }
        [HttpPost]
        public IActionResult Add(City city)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _cityRepository.Create(city);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        { 
            City city = _cityRepository.GetById(Id);
            return View(city);
        }
        [HttpPost]
        public IActionResult Update(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            _cityRepository.Update(city);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _cityRepository.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
