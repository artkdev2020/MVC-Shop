using OnlineShop.Data;
using OnlineShop.Models.NewEmailModel;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services
{
    public class DbRepository
    {
        readonly private ApplicationDbContext _context;
        readonly private ApplicationContextEmail _contextEmail;

        public DbRepository(ApplicationDbContext context, ApplicationContextEmail emailContext)
        {
            _context = context;
            _contextEmail = emailContext;
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

        public IEnumerable<OnlineShop.Models.NewEmailModel.City> Cities
        {
            get
            {
                //List<City> tmp = _contextEmail.Cities.ToList();



                return _contextEmail.Cities.ToList();
            }
            //get { return  _contextEmail.Cities.ToList();  }
        }

        public string GetCategoryImg(int idCategory)
        {
            foreach (var item in _context.Categories.ToList())
            {
                if (item.Id == idCategory)
                {
                    return item.ImagePath;
                }
            }

            return null;
        }
    }
}
