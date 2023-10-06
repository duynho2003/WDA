using Lab08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab08.Controllers
{
    public class HomeController : Controller
    {
        private readonly SaleDbContext _context;

        public HomeController(SaleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = from c in _context.Customers
                        join o in _context.Orders
                        on c.CustomerId equals o.CustomerId
                        select new 
                        { 
                          Customer=c,
                          Order=o
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