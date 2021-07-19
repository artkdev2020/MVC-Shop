using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        

        public HomeController(ApplicationDbContext context, ApplicationContextEmail emailContext)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListSubcategories(int id)
        {

            //if (id < 0 || id > _context.Products.ToArray().Length)
            //{
            //    return Redirect("/Home/Index");

            //}

            List<Subcategory> result = new List<Subcategory>();

            foreach (var item in _context.Subcategories.ToList())
            {
                if (item.CategoryFk == id)
                {
                    result.Add(item);
                }
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult ListProducts(int id)
        {
            //if (id < 0 || id > _context.Products.ToArray().Length)
            //{
            //    return Redirect("/Home/Index");

            //}

            List<ProductWithImg> result = new List<ProductWithImg>();

            foreach (var prodItem in _context.Products.ToList())
            {
                if (prodItem.SubcategoryFk == id)
                {
                    foreach(var prodImg in _context.ProductImages.ToList())
                    {
                        if(prodImg.ProductFk == prodItem.Id)
                        {
                            result.Add(new ProductWithImg(prodItem, prodImg));
                        }
                    }
                }
            }

            return View(result);
        }

        public IActionResult Product(int id)
        {
            if (id < 0 || id > _context.Products.ToArray().Length)
            {
                return Redirect("/Home/Index");
            }

             //result = new List<ProductWithImg>();

            foreach (var prodItem in _context.Products.ToList())
            {
                if (prodItem.Id == id)
                {
                    foreach (var prodImg in _context.ProductImages.ToList())
                    {
                        if (prodImg.ProductFk == prodItem.Id)
                        {
                            return View(new ProductWithImg(prodItem, prodImg));
                        }
                    }
                }
            }

            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
