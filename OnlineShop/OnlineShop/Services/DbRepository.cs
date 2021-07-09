using OnlineShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services
{
    public class DbRepository
    {
        private ApplicationDbContext _context;

        public DbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OnlineShop.Models.Category> Categories
        {
            get { return _context.Categories.ToList(); }
        }

        public IEnumerable<OnlineShop.Models.Subcategory> Subcategories
        {
            get { return _context.Subcategories.ToList(); }
        }

        public IEnumerable<OnlineShop.Models.Product> Products
        {
            get { return _context.Products.ToList(); }
        }
    }

    //public class DbRepository
    //{
    //    private static ApplicationDbContext _context;

    //    private DbRepository()
    //    {
    //        _context = new ApplicationDbContext();
    //    }

    //    public static ApplicationDbContext GetDb()
    //    {
    //        if(_context == null)
    //        {
    //            _context = new DbRepository();
    //        }
    //        return _context;
    //    }
    //}
}
