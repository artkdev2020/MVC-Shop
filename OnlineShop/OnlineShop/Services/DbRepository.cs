using OnlineShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services
{
    public class DbRepository
    {
        readonly private ApplicationDbContext _context;

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

        public string GetCategoryImg(int idCategory)
        {
            foreach(var item in _context.Categories.ToList())
            {
                if(item.Id == idCategory)
                {
                    return item.ImagePath;
                }
            }

            return null;
        }
    }
}
