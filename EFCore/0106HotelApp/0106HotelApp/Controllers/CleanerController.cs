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
        private RoomRepository _roomRepository;
        public CleanerController(CleanerRepository cleanerRepository, CityRepository cityRepository,RoomRepository roomRepository)
        {
            _cleanerRepository = cleanerRepository;
            _cityRepository = cityRepository;
            _roomRepository = roomRepository;
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
        public IActionResult AssignRoom(int Id)
        {
            Cleaner cleaner = _cleanerRepository.GetById(Id);
            int cityId = cleaner.CityId;

            AssignRoom assignRoom = new AssignRoom()
            {
                Cleaner = cleaner,
                AllRooms = _roomRepository.GetSomeCity(cityId),
                AssignedRooms = _cleanerRepository.AssignedRooms(cleaner.Id)
            };
            return View(assignRoom);
        }
        [HttpPost]
        public IActionResult AssignRoom(AssignRoom assignRoom)
        {
            _roomRepository.Assign(assignRoom.RoomId, assignRoom.Cleaner.Id);
            return RedirectToAction("SelectIndex", new { Id = assignRoom.Cleaner.CityId });
        }
        public IActionResult CleanedRoom(int RoomId, int CleanerId)
        {
            _roomRepository.CleanedRoom(RoomId, CleanerId);
            Cleaner cleaner = _cleanerRepository.GetById(CleanerId);
            return RedirectToAction("SelectIndex", new { Id = cleaner.CityId });
        }
    }
}
