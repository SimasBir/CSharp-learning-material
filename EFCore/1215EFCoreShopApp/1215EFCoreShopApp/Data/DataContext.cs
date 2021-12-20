using _1215EFCoreShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shop>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Shop>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<ShopItem>().Property<bool>("IsDeleted");
            modelBuilder.Entity<ShopItem>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

        }
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

    }

}
