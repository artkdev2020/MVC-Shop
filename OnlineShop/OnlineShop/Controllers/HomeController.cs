﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Models.SubModels;

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
            CategoryModel wrap = new CategoryModel(_context.Categories.ToList(), _context.Subcategories.ToList());
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
    }
}
