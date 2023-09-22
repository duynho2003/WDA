using Lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class StudentController : Controller
    {
        private DatabaseContext db;
        public StudentController(DatabaseContext _db) 
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var model =db.Student.ToList();
            var model = from s 
                        in db.Student 
                        select s;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
