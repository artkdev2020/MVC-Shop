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
    public class ProductWithImg
    {
        public OnlineShop.Models.Product prod { get; set; }
        public OnlineShop.Models.ProductImage prodImg { get; set; }

        public ProductWithImg() { }

        public ProductWithImg(OnlineShop.Models.Product prod, OnlineShop.Models.ProductImage prodImg)
        {
            this.prod = prod;
            this.prodImg = prodImg;
        }
    }

    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IndexModel wrap = new IndexModel(_context.Categories.ToList(),
                _context.Subcategories.ToList(),
                _context.Products.ToList(),
                _context.ProductImages.ToList());

            //IndexModel wrap = new IndexModel(_context.Categories.ToList(), _context.Subcategories.ToList());
            return View(wrap);
        }

        public async Task<IActionResult> Privacy()
        {
            return View(await _context.Subcategories.ToListAsync());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private void GetProductsForCarousel()
        //{
        //    List<ProductWithImg> listProd = new List<ProductWithImg>();

        //    int count = 0;
        //    foreach(var prod in _context.Products)
        //    {

        //    }
        //}
    }
}
