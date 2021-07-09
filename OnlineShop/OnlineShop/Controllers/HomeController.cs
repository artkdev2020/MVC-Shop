using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListProduct()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListSubcategories(int id)
        {

            if (id <= 0 || id >= _context.Products.ToArray().Length)
            {
                return Redirect("/Home/Index");

            }

            List<Subcategory> result = new List<Subcategory>();

            foreach (var item in _context.Subcategories.ToList())
            {
                if(item.CategoryFk == id)
                {
                    result.Add(item);
                }
            }

            return View(result);
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
