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
                Include(b => b.CleanerRooms).ThenInclude(cr => cr.Cleaner).
                Where(c => c.HotelId == Id).ToList();
        }
        public List<Room> GetSomeCity(int Id)
        {
            List<Room> allRooms = _context.Rooms.Where(h => h.Hotel.CityId == Id)
                .Include(c => c.Hotel)
                .Include(b => b.CleanerRooms).ThenInclude(cr => cr.Cleaner)
                .ToList();
            List<Room> dirtyRooms = new List<Room>();
            foreach (Room room in allRooms)
            {
                int assignedRooms = _context.CleanerRooms.Where(a => a.Cleaned == false).Where(b => b.RoomId == room.Id).Count();
                if (assignedRooms == 0)
                {
                    dirtyRooms.Add(room);
                }
            }
            return dirtyRooms;
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
            currentRoom.Booked = false;
            Update(currentRoom);
            return currentRoom;
        }
        public void Assign(int roomId, int cleanerId)
        {
            CleanerRoom cleanerRoom = _context.CleanerRooms.Where(r => r.RoomId == roomId).Where(c => c.CleanerId == cleanerId).FirstOrDefault();
            if (cleanerRoom != null)
            {
                cleanerRoom.Cleaned = false;
                _context.CleanerRooms.Update(cleanerRoom);
            }
            else
            {
                _context.CleanerRooms.Add(new CleanerRoom
                {
                    RoomId = roomId,
                    CleanerId = cleanerId

                });
            }
            _context.SaveChanges();
        }
        public void CleanedRoom(int roomId, int cleanerId)
        {
            try
            {
                _context.CleanerRooms.Update(new CleanerRoom
                {
                    RoomId = roomId,
                    CleanerId = cleanerId,
                    Cleaned = true
                });
            }
            catch
            {
            }
            _context.SaveChanges();
        }
    }
}
