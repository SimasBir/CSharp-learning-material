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
    public class RoomController : Controller
    {
        private RoomRepository _roomRepository;
        private HotelRepository _hotelRepository;
        private CleanerRepository _cleanerRepository;
        public RoomController(RoomRepository roomRepository, HotelRepository hotelRepository, CleanerRepository cleanerRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _cleanerRepository = cleanerRepository;
        }
        public IActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }
        public IActionResult SelectIndex(int Id)
        {
            CreateHotelRoom createHotelRoom = new CreateHotelRoom()
            {
                Rooms = _roomRepository.GetSome(Id),
                SelectedHotel = Id,
            };
            return View(createHotelRoom);
        }
        public IActionResult Add()
        {
            CreateRoom createRoom = new CreateRoom()
            {
                Room = new Room(),
                AllHotels = _hotelRepository.GetAll()
            };
            return View(createRoom);
        }
        [HttpPost]
        public IActionResult Add(CreateRoom createRoom)
        {
            if (!ModelState.IsValid)
            {
                createRoom.AllHotels = _hotelRepository.GetAll();
                return View();
            }
            _roomRepository.Create(createRoom.Room);
            return RedirectToAction("Index");
        }
        public IActionResult AddSpecific(int hotelId)
        {
            Room room = new Room()
            {
                HotelId = hotelId,
            };
            return View(room);
        }
        [HttpPost]
        public IActionResult AddSpecific(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _roomRepository.Create(room);
            return RedirectToAction("SelectIndex", new { Id = room.HotelId });
        }
        public IActionResult Delete(int id)
        {
            _roomRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            CreateRoom createRoom = new CreateRoom()
            {
                Room = _roomRepository.GetById(id),
                AllHotels = _hotelRepository.GetAll()
            };
            return View(createRoom);
        }
        [HttpPost]
        public IActionResult Update(CreateRoom createRoom)
        {
            if (!ModelState.IsValid)
            {
                createRoom.AllHotels = _hotelRepository.GetAll();
                return View(createRoom);
            }
            _roomRepository.Update(createRoom.Room);
            return RedirectToAction("Index");
        }
        public IActionResult Book(int Id)
        {
            Room currentRoom = _roomRepository.Book(Id);
            return RedirectToAction("SelectIndex", new { Id = currentRoom.HotelId });
        }
        public IActionResult Leave(int Id)
        {
            Room currentRoom = _roomRepository.Leave(Id);
            return RedirectToAction("SelectIndex", new { Id = currentRoom.HotelId });
        }
        public IActionResult AssignCleaner(int Id)
        {
            Room room = _roomRepository.GetById(Id);
            int cityId = _hotelRepository.GetById(room.HotelId).CityId;
            AssignCleaner assignCleaner = new AssignCleaner()
            {
                Room = room,
                AllCleaners = _cleanerRepository.GetSomeFiltered(cityId)
            };
            return View(assignCleaner);
        }
        [HttpPost]
        public IActionResult AssignCleaner(AssignCleaner assignCleaner)
        {
            _roomRepository.Assign(assignCleaner.Room.Id, assignCleaner.CleanerId);
            return RedirectToAction("SelectIndex", new { Id = assignCleaner.Room.HotelId });
        }
    }
}
