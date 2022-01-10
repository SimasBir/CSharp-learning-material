using _0106HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0106HotelApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CleanerRoom> CleanerRooms { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleanerRoom>().HasKey(bc => new { bc.CleanerId, bc.RoomId });

            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Vilnius"
                },
                new City()
                {
                    Id = 2,
                    Name = "Kaunas"
                },
                new City()
                {
                    Id = 3,
                    Name = "Klaipėda"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    CityId = 1,
                    Address = "Centro 10"
                }, 
                new Hotel()
                {
                    Id = 2,
                    CityId = 3,
                    Address = "Senamiesčio 10"
                }, 
                new Hotel()
                {
                    Id = 3,
                    CityId = 2,
                    Address = "Valančiaus 1"
                }, 
                new Hotel()
                {
                    Id = 4,
                    CityId = 1,
                    Address = "Naujininkų 15"
                }, 
                new Hotel()
                {
                    Id = 5,
                    CityId = 2,
                    Address = "Aušros 1515"
                }, 
                new Hotel()
                {
                    Id = 6,
                    CityId = 1,
                    Address = "Šnipiškių 3000"
                }, 
                new Hotel()
                {
                    Id = 7,
                    CityId = 3,
                    Address = "Jūros vidurys"
                }, 
                new Hotel()
                {
                    Id = 8,
                    CityId = 2,
                    Address = "Donelaičio 110"
                }, 
                new Hotel()
                {
                    Id = 9,
                    CityId = 1,
                    Address = "Naujamiesčio 18 "
                }
            );
            modelBuilder.Entity<Cleaner>().HasData(
                new Cleaner()
                {
                    Id = 1,
                    Name = "Audronė",
                    Surname = "Audronytė",
                    CityId = 1
                }, 
                new Cleaner()
                {
                    Id = 2,
                    Name = "Jonius",
                    Surname = "Joniauskas",
                    CityId = 2
                }, 
                new Cleaner()
                {
                    Id = 3,
                    Name = "Žilas",
                    Surname = "Žilauskas",
                    CityId = 2
                }, 
                new Cleaner()
                {
                    Id = 4,
                    Name = "Valė",
                    Surname = "Valėtoja",
                    CityId = 3
                }, 
                new Cleaner()
                {
                    Id = 5,
                    Name = "Ramunė",
                    Surname = "Ramunytė",
                    CityId = 1
                }, 
                new Cleaner()
                {
                    Id = 6,
                    Name = "Gintaras",
                    Surname = "Už puse kainos",
                    CityId = 3
                }, 
                new Cleaner()
                {
                    Id = 7,
                    Name = "Valerija",
                    Surname = "Valerijytė",
                    CityId = 1
                });
        }
    }
}
