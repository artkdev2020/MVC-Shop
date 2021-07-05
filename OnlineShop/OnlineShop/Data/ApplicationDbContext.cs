using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            Categories.Include(s => s.Subcategories).ToList();
            Subcategories.Include(s => s.Products).ToList();
            Products.Include(p => p.Characteristics).ToList();
            Products.Include(p => p.Images).ToList();

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FiscalBill> FiscalBills { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }

        public override int SaveChanges()
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnType("bigint");

            modelBuilder.Entity<Category>().Property(c => c.ImagePath).IsRequired();

            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Category>()
               .HasMany(c => c.Subcategories)
               .WithOne(s => s.Category)
               .HasForeignKey(s => s.CategoryFk)
               .OnDelete(DeleteBehavior.Cascade);

            // Subcategories
            modelBuilder.Entity<Subcategory>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Subcategory>().HasKey(s => s.Id);
            modelBuilder.Entity<Subcategory>().Property(s => s.Id).HasColumnType("bigint");

            modelBuilder.Entity<Subcategory>().Property(c => c.ImagePath).IsRequired();

            modelBuilder.Entity<Subcategory>().Property(s => s.Name).HasMaxLength(50);
            modelBuilder.Entity<Subcategory>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Subcategory>()
               .HasMany(s => s.Products)
               .WithOne(p => p.Subcategory)
               .HasForeignKey(p => p.SubcategoryFk)
               .OnDelete(DeleteBehavior.SetNull);

            // Products
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnType("bigint");

            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(70);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.ShortDescription).HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(p => p.ShortDescription).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("text");
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.MomentAdded).HasColumnType("datetime");
            modelBuilder.Entity<Product>().Property(p => p.MomentAdded).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.MomentEdited).HasColumnType("datetime");
            modelBuilder.Entity<Product>().Property(p => p.MomentEdited).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("smallmoney");
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Product>().Property(p => p.Discount).HasColumnType("float");

            modelBuilder.Entity<Product>().Property(p => p.Rating).HasColumnType("float");

            modelBuilder.Entity<Product>().Property(p => p.Model).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.InArchive).HasColumnType("bit");
            modelBuilder.Entity<Product>().Property(p => p.InArchive).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.InArchive).HasDefaultValue(false);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Characteristics)
               .WithOne(c => c.Product)
               .HasForeignKey(c => c.ProductFk)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Images)
               .WithOne(p => p.Product)
               .HasForeignKey(p => p.ProductFk)
               .OnDelete(DeleteBehavior.Cascade);

            // Characteristics
            modelBuilder.Entity<Characteristic>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Characteristic>().HasKey(c => c.Id);
            modelBuilder.Entity<Characteristic>().Property(c => c.Id).HasColumnType("bigint");

            modelBuilder.Entity<Characteristic>().Property(c => c.Color).HasMaxLength(15);
            modelBuilder.Entity<Characteristic>().Property(c => c.Color).IsRequired();

            modelBuilder.Entity<Characteristic>().Property(c => c.Material).IsRequired();

            modelBuilder.Entity<Characteristic>().Property(c => c.MaterialRatio).IsRequired();

            modelBuilder.Entity<Characteristic>().Property(c => c.ProducingCountry).HasMaxLength(25);
            modelBuilder.Entity<Characteristic>().Property(c => c.ProducingCountry).IsRequired();

            modelBuilder.Entity<Characteristic>().Property(c => c.BrandCountry).HasMaxLength(25);
            modelBuilder.Entity<Characteristic>().Property(c => c.BrandCountry).IsRequired();

            modelBuilder.Entity<Characteristic>()
               .HasMany(c => c.Sizes)
               .WithOne(s => s.Characteristic)
               .HasForeignKey(s => s.CharacteristicFk)
               .OnDelete(DeleteBehavior.Cascade);

            // ProductImages
            modelBuilder.Entity<ProductImage>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductImage>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductImage>().Property(p => p.Id).HasColumnType("bigint");

            modelBuilder.Entity<ProductImage>().Property(p => p.Path).IsRequired();

            // OrderDetails
            modelBuilder.Entity<OrderDetails>().Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderDetails>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderDetails>().Property(o => o.Id).HasColumnType("bigint");

            modelBuilder.Entity<OrderDetails>().Property(o => o.Count).IsRequired();

            // Order
            modelBuilder.Entity<Order>().Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnType("bigint");

            modelBuilder.Entity<Order>().Property(o => o.MomentCreated).HasColumnType("datetime");
            modelBuilder.Entity<Order>().Property(o => o.MomentCreated).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.MomentCreated).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>().Property(o => o.Description).HasColumnType("text");
            modelBuilder.Entity<Order>().Property(o => o.Description).IsRequired();

            modelBuilder.Entity<Order>()
               .HasMany(o => o.OrderDetails)
               .WithOne(o => o.Order)
               .HasForeignKey(o => o.OrderFk)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
               .HasMany(o => o.FiscalBill)
               .WithOne(f => f.Order)
               .HasForeignKey(f => f.OrderFk)
               .OnDelete(DeleteBehavior.Cascade);

            // Customer
            modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnType("bigint");

            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(20);

            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasMaxLength(20);

            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired();

            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired();

            modelBuilder.Entity<Customer>().Property(c => c.Telephone).HasMaxLength(15);

            modelBuilder.Entity<Customer>()
               .HasMany(c => c.Orders)
               .WithOne(o => o.Customer)
               .HasForeignKey(o => o.CustomerFk)
               .OnDelete(DeleteBehavior.Cascade);

            // FiscalBill
            modelBuilder.Entity<FiscalBill>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FiscalBill>().HasKey(f => f.Id);
            modelBuilder.Entity<FiscalBill>().Property(f => f.Id).HasColumnType("bigint");

            modelBuilder.Entity<FiscalBill>().Property(f => f.BillGuid).IsRequired();

            var categories = new Category[]
            {
                new Category{ Id = 1, Name = "men", ImagePath = "e7b0a0f4114740d01bdfafcf94996cd4.jpg" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            var subcategories = new Subcategory[]
            {
                new Subcategory{ Id = 1, CategoryFk = 1, Name = "men footwear", ImagePath = "e046b7ae6d58ddbc287ee64b8a8ef107.jpg" },
                new Subcategory{ Id = 2, CategoryFk = 1, Name = "men pants", ImagePath = "8e4640753851f983fc66043aa9463042.jpg" },
                new Subcategory{ Id = 3, CategoryFk = 1, Name = "men shirts", ImagePath = "3686bf9a01a64d4bbb5c2937056f39da.jpg" },
                new Subcategory{ Id = 4, CategoryFk = 1, Name = "underwear", ImagePath = "7b376124498573ac8a630c0c741b612f.jpg" },
                new Subcategory{ Id = 5, CategoryFk = 1, Name = "work clothes", ImagePath = "57caaf1a7e9e77a2fe5282d149f988f2.jpg" }
            };

            modelBuilder.Entity<Subcategory>().HasData(subcategories);

#if DEBUG
            var products = new Product[]
            {
                new Product{ Id = 1, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Вьетнамочки чёрные", ShortDescription = "Ультра чёткие вьетнамки", Description = "Просто превосходные шлепандецалы, сам хожу даже зимой в них. Но особенно круто то что они не конфликтуют с носочками (а это крайне удивительно)", Price = 13.99m, Discount = 0, Model = 1 },
                new Product{ Id = 2, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Вьетнамочки моднявые", ShortDescription = "Ультра чёткие вьетнамки", Description = "Просто превосходные шлепандецалы, сам хожу даже зимой в них. Но особенно круто то что они не конфликтуют с носочками (а это крайне удивительно)", Price = 13.99m, Discount = 0, Model = 1 },
                new Product{ Id = 3, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Вьетнамочки белые", ShortDescription = "Ультра чёткие вьетнамки", Description = "Просто превосходные шлепандецалы, сам хожу даже зимой в них. Но особенно круто то что они не конфликтуют с носочками (а это крайне удивительно)", Price = 13.99m, Discount = 0, Model = 1 },
                new Product{ Id = 4, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Вьетнамочки супер моднявые", ShortDescription = "Ультра чёткие вьетнамки", Description = "Просто превосходные шлепандецалы, сам хожу даже зимой в них. Но особенно круто то что они не конфликтуют с носочками (а это крайне удивительно)", Price = 13.99m, Discount = 1.5, Model = 1 },
                new Product{ Id = 5, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Сандальдепалы классические", ShortDescription = "То что надо истинному самцу", Description = "невероятно модные сандальчики, которые там и зазывают всех самочек к тебе на хату заняться сам понимаешь чем (особенно в кобинации с нашими улётными носочками)", Price = 24.59m, Discount = 6.5, Model = 2 },
                new Product{ Id = 6, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Сандальдепалы минималистические", ShortDescription = "То что надо истинному самцу", Description = "невероятно модные сандальчики, которые там и зазывают всех самочек к тебе на хату заняться сам понимаешь чем (особенно в кобинации с нашими улётными носочками)", Price = 24.59m, Discount = 4, Model = 2 },
                new Product{ Id = 7, SubcategoryFk = 1, MomentAdded = DateTime.UtcNow, MomentEdited = DateTime.UtcNow, Name = "Сандальдепалы максималистические", ShortDescription = "То что надо истинному самцу", Description = "невероятно модные сандальчики, которые там и зазывают всех самочек к тебе на хату заняться сам понимаешь чем (особенно в кобинации с нашими улётными носочками)", Price = 24.59m, Discount = 21.5, Model = 2 }
            };

            modelBuilder.Entity<Product>().HasData(products);

            var images = new ProductImage[]
            {
                new ProductImage{ Id = 1, ProductFk = 1, Path = "b2cc1086d94515415ddaeb3d9f0ae038.jpg" },
                new ProductImage{ Id = 2, ProductFk = 2, Path = "ee845ecc75d29c963fd839ab76e84980.jpg" },
                new ProductImage{ Id = 3, ProductFk = 3, Path = "f15e265e85585bcbb649b6df8987ed9e.jpg" },
                new ProductImage{ Id = 4, ProductFk = 4, Path = "fc42bc8ff8571a49933be09115564dc1.jpg" },
                new ProductImage{ Id = 5, ProductFk = 5, Path = "8c96505c918782a36d542e36b936caf1.jpg" },
                new ProductImage{ Id = 6, ProductFk = 6, Path = "a878bc1d9999b885442c1b96f6168108.jpg" },
                new ProductImage{ Id = 7, ProductFk = 7, Path = "bd6d7451e04a3480d8d265085f3cb105.jpg" }
            };

            modelBuilder.Entity<ProductImage>().HasData(images);

            var characteristics = new Characteristic[]
            {
                new Characteristic{ Id = 1, ProductFk = 1, Color = "Чёрный", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай", Additional = "Сделано с любовью" },
                new Characteristic{ Id = 2, ProductFk = 2, Color = "Синий", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай", Additional = "Сделано с любовью" },
                new Characteristic{ Id = 3, ProductFk = 3, Color = "Белый", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай" },
                new Characteristic{ Id = 4, ProductFk = 4, Color = "Синий", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай" },
                new Characteristic{ Id = 5, ProductFk = 5, Color = "Синий", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай", Additional = "Сделано с завистью" },
                new Characteristic{ Id = 6, ProductFk = 6, Color = "Синий", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай" },
                new Characteristic{ Id = 7, ProductFk = 7, Color = "Чёрный", Material = "Какой-то материал", MaterialRatio = "100% качества", BrandCountry = "Израиль", ProducingCountry = "Китай", Additional = "Сделано без любви (в понедельник)" }
            };

            modelBuilder.Entity<Characteristic>().HasData(characteristics);

            var sizes = new Size[]
            {
                new Size{ Id = 1, CharacteristicFk = 1, Value = "42", Count = 34 },
                new Size{ Id = 2, CharacteristicFk = 1, Value = "43", Count = 33 },
                new Size{ Id = 3, CharacteristicFk = 1, Value = "44", Count = 35 },
                new Size{ Id = 4, CharacteristicFk = 2, Value = "43", Count = 23 },
                new Size{ Id = 5, CharacteristicFk = 2, Value = "44", Count = 54 },
                new Size{ Id = 6, CharacteristicFk = 3, Value = "43", Count = 51 },
                new Size{ Id = 7, CharacteristicFk = 3, Value = "44", Count = 34 },
                new Size{ Id = 8, CharacteristicFk = 4, Value = "42", Count = 24 },
                new Size{ Id = 9, CharacteristicFk = 4, Value = "43", Count = 13 },
                new Size{ Id = 10, CharacteristicFk = 4, Value = "44", Count = 30 },
                new Size{ Id = 11, CharacteristicFk = 5, Value = "44", Count = 34 },
                new Size{ Id = 12, CharacteristicFk = 5, Value = "45", Count = 36 },
                new Size{ Id = 13, CharacteristicFk = 6, Value = "44", Count = 34 },
                new Size{ Id = 14, CharacteristicFk = 6, Value = "45", Count = 37 },
                new Size{ Id = 15, CharacteristicFk = 7, Value = "44", Count = 34 },
                new Size{ Id = 16, CharacteristicFk = 7, Value = "45", Count = 37 }
            };

            modelBuilder.Entity<Size>().HasData(sizes);
#endif

            base.OnModelCreating(modelBuilder);
        }

    }
}
