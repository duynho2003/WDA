using Lab04.Areas.Departments.Data;
using Lab04.Areas.Employees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        private DatabaseContext _db;
        public EmployeeController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? no)
        {
            ViewBag.no = new SelectList(_db.Department.ToList(), "No", "Name");
            if (no == null)
            {
                var emp = _db.Employee.Include(d => d.Department).ToList();
                return View(emp);
            }
            else
            {
                var emp = _db.Employee.Where(d => d.Department!.No.Equals(no)).ToList();
                return View(emp);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.no = new SelectList(_db.Department.ToList(), "No", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ViewBag.no = new SelectList(_db.Department.ToList(), "No", "Name");
            try 
            {
                if (ModelState.IsValid)
                {
                    var emp = _db.Employee.Where(e => e.Id!.Equals(employee.Id)).SingleOrDefault();
                    if (emp == null)
                    {
                        emp = employee;
                        _db.Employee.Add(employee);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Msg"] = "Has existed...";
                    }
                }
                else
                {
                    TempData["Msg"] = "Fail";
                }
            }
            catch (Exception e) 
            {
                TempData["Msg"] = e.Message;
            }
            return View();
        }
    }
}