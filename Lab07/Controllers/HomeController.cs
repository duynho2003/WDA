using Lab07.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab07.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext _db;
        public HomeController(DatabaseContext db) 
        { 
            _db = db;
        }

        public IActionResult Index()
        {
            var model = from c in _db.Categories 
                        join p in _db.Products 
                        on c.CategoryID equals p.CategoryID
                        select new CategoriesProducts
                        {
                            Categories = c,
                            Products = p
                        };
            return View(model);
        }

        public IActionResult Privacy()
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