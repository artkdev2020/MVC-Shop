using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.SubModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IndexModel _header { get; }

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _header = _header = new IndexModel(context.Categories.ToList(), context.Subcategories.ToList());

        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            ViewData["Header"] = _header;
            return View(await _context.Products.ToListAsync());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {







            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
