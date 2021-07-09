using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _appEnvironment;
        public SubcategoryController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        // GET: SubcategoryController
        public ActionResult Index()
        {
            return View(_context.Subcategories.ToList());
        }

        // GET: SubcategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubcategoryController/Create
        public ActionResult Create()
        {
            List<Category> categories = new List<Category>();
            foreach (var item in _context.Categories)
            {
                categories.Add(item);
            }
            ViewBag.Categoties = categories;


            return View(_context);
        }

        // POST: SubcategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            if (collection.Files[0] != null)
            {
                // путь к папке Files
                string path = "/files/subcategory/" + collection.Files[0].FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await collection.Files[0].CopyToAsync(fileStream);
                }

                var category = _context.Categories
                    .AsNoTracking()
                    .FirstOrDefault(s => s.Id.ToString() == collection["Categories"].ToString());

                Subcategory sub = new Subcategory { Name = collection["name"], CategoryFk = category.Id, ImagePath = path };
                _context.Subcategories.Add(sub);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: SubcategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Edit/5
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

        // GET: SubcategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Delete/5
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
