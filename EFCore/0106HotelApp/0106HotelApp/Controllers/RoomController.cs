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
        public RoomController(RoomRepository roomRepository, HotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }
        public IActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }
        public IActionResult SelectIndex(int Id)
        {
            return View(_roomRepository.GetSome(Id));
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
    }
}
