using _1228RegistrationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1228RegistrationApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Value>().HasData(
                new Value()
                {
                    Id = 1,
                    Description = "Taip",
                    ValueGroup = 1,

                },
                new Value()
                {
                    Id = 2,
                    Description = "Ne",
                    ValueGroup = 1,
                },
                new Value()
                {
                    Id = 3,
                    Description = "Metinis rangovas",
                    ValueGroup = 2,
                },
                new Value()
                {
                    Id = 4,
                    Description = "Operatorius",
                    ValueGroup = 2,
                },
                new Value()
                {
                    Id = 5,
                    Description = "Automatinis",
                    ValueGroup = 3,
                },
                new Value()
                {
                    Id = 6,
                    Description = "Manualus",
                    ValueGroup = 3,
                }
            );
            modelBuilder.Entity<Prompt>().HasData(
                new Prompt()
                {
                    Id = 1,
                    Description = "Reikia atlikti rangos darbus",
                    ValueGroupId = 1,
                },
                new Prompt()
                {
                    Id = 2,
                    Description = "Rangos Darbus atliks",
                    ValueGroupId = 2,
                },
                new Prompt()
                {
                    Id = 3,
                    Description = "Verslo klientas",
                    ValueGroupId = 1,
                },
                new Prompt()
                {
                    Id = 4,
                    Description = "Skaičiavimo metodas",
                    ValueGroupId = 3,
                },
                new Prompt()
                {
                    Id = 5,
                    Description = "Svarbus klientas",
                    ValueGroupId = 1,
                }
    );        }

    }
}
