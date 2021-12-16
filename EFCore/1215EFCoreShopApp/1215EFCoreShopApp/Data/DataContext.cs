using _1215EFCoreShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1215EFCoreShopApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = 1,
                    Name = "Electronics"
                },
                new Shop()
                {
                    Id = 2,
                    Name = "Groceries"
                }
            );
            modelBuilder.Entity<ShopItem>().HasData(
                new ShopItem()
                {
                    Id = 1,
                    Name = "Phone",
                    ShopId = 1
                }
                , new ShopItem()
                {
                    Id = 2,
                    Name = "Bread",
                    ShopId = 2
                }, new ShopItem()
                {
                    Id = 3,
                    Name = "TV",
                    ShopId = 1
                }, new ShopItem()
                {
                    Id = 4,
                    Name = "Milk",
                    ShopId = 2
                }, new ShopItem()
                {
                    Id = 5,
                    Name = "Beef",
                    ShopId = 2
                }
                );
        }
    }
}
