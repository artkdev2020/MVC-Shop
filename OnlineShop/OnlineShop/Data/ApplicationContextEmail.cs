using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Models.NewEmailModel;

namespace OnlineShop.Data
{
    public class ApplicationContextEmail : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public ApplicationContextEmail(DbContextOptions<ApplicationContextEmail> options)
            : base(options)
        {
            // Если такая БД уже есть, то удаляем ее
            if (Database.CanConnect())
                Database.EnsureDeleted();

            // Создаем БД
            Database.EnsureCreated();
        }

        //public ApplicationContextEmail()
        //{
        //    // Если такая БД уже есть, то удаляем ее
        //    if (Database.CanConnect())
        //        Database.EnsureDeleted();

        //    // Создаем БД
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=postDb;Trusted_Connection=True;");
        }
    }
}
