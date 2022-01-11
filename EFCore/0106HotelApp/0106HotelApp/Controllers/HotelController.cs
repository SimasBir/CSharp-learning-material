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
    public class HotelController : Controller
    {
        private HotelRepository _hotelRepository;
        private CityRepository _cityRepository;
        public HotelController(HotelRepository hotelRepository, CityRepository cityRepository)
        {
            _hotelRepository = hotelRepository;
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            return View(_hotelRepository.GetAll());
        }
        public IActionResult SelectIndex(int Id)
        {
            return View(_hotelRepository.GetSome(Id));
        }
        public IActionResult Add()
        {
            CreateHotel createHotel = new CreateHotel()
            {
                Hotel = new Hotel(),
                AllCities = _cityRepository.GetAll()
            };
            return View(createHotel);
        }
        [HttpPost]
        public IActionResult Add(CreateHotel createHotel)
        {
            if (!ModelState.IsValid)
            {
                createHotel.AllCities = _cityRepository.GetAll();
                return View();
            }
            _hotelRepository.Create(createHotel.Hotel);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _hotelRepository.Delete(id);

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            CreateHotel createHotel = new CreateHotel()
            {
                Hotel = _hotelRepository.GetById(id),
                AllCities = _cityRepository.GetAll()
            };
            return View(createHotel);
        }
        [HttpPost]
        public IActionResult Update(CreateHotel createHotel)
        {
            if (!ModelState.IsValid)
            {
                createHotel.AllCities = _cityRepository.GetAll();
                return View(createHotel);
            }
            _hotelRepository.Update(createHotel.Hotel);
            return RedirectToAction("Index");
        }
    }
}
