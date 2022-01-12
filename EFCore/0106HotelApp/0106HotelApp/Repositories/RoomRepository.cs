using _0106HotelApp.Data;
using _0106HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Repositories
{
    public class RoomRepository : RepositoryBase<Room>
    {
        public RoomRepository(DataContext context) : base(context)
        {
        }
        public new List<Room> GetAll()
        {
            return _context.Rooms.Include(c => c.Hotel).ThenInclude(h => h.City).ToList();
        }
        public List<Room> GetSome(int Id)
        {
            return _context.Rooms.Include(c => c.Hotel).ThenInclude(h => h.City).
                Include(b=>b.CleanerRooms).ThenInclude(cr=>cr.Cleaner).
                Where(c => c.HotelId == Id).ToList();
        }
        public Room Book(int Id)
        {
            Room currentRoom = GetById(Id);
            currentRoom.Booked = true;
            Update(currentRoom);
            return currentRoom;
        }
        public Room Leave(int Id)
        {
            Room currentRoom = GetById(Id);
            currentRoom.NeedsCleaning = true;
            Update(currentRoom);
            return currentRoom;
        }
        public Room Clean(int Id)
        {
            Room currentRoom = GetById(Id);
            currentRoom.Booked = false;
            currentRoom.NeedsCleaning = false;
            Update(currentRoom);
            return currentRoom;
        }
        public void Assign(int roomId, int cleanerId)
        {
            _context.CleanerRooms.Add(new CleanerRoom
            {
                RoomId = roomId,
                CleanerId = cleanerId,

            });
            _context.SaveChanges();
        }
    }
}
