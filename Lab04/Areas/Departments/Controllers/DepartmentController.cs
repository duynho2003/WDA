using Lab04.Areas.Departments.Data;
using Lab04.Areas.Departments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Areas.Departments.Controllers
{
    [Area("Departments")]
    public class DepartmentController : Controller
    {
        private DatabaseContext _db;
        public DepartmentController(DatabaseContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model=_db.Department.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    _db.Department.Add(department);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Msg = "Fail";
                }
            }
            catch (Exception ex) 
            {
                ViewBag.Msg= ex.Message;
            }
            return View();
        }
    }
}
