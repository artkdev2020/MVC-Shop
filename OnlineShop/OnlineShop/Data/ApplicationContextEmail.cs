using Microsoft.EntityFrameworkCore;
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
            if (!Database.CanConnect())
            {
                Database.EnsureCreated();
                DesserializedCities cities = DesserializedCities.DesserializeCollection("F:/Repositories/artKDev/MVC-Shop/OnlineShop/OnlineShop/ServicesFiles/cities.json");
                DesserializedWarehouses warehouses = DesserializedWarehouses.DesserializeCollection("F:/Repositories/artKDev/MVC-Shop/OnlineShop/OnlineShop/ServicesFiles/warehouses.json");

                if (cities != null && warehouses != null)
                {
                    foreach (var item in cities.data)
                    {
                        this.Add(item);
                    }

                    foreach (var item in warehouses.data)
                    {
                        this.Add(item);
                    }

                    this.SaveChanges();
                }
            }

            //Database.EnsureDeleted();

            // Создаем БД
            //Database.EnsureCreated();
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
