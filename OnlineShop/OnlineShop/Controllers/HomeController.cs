using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models.SubModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context { get; }
        public IndexModel _header { get; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _header = new IndexModel(context.Categories.ToList(), context.Subcategories.ToList());
        }

        public IActionResult Index()
        {
            //IndexModel header = new IndexModel(context.Categories.ToList(),
            //    context.Subcategories.ToList());
            ProductWithImage carouselProducts = new ProductWithImage(_context.Products.ToList(),
                _context.ProductImages.ToList());

            ViewData["Header"] = _header;
            ViewData["CarouselProducts"] = carouselProducts;
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            ViewData["Header"] = _header;
            return View(await _context.Subcategories.ToListAsync());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
