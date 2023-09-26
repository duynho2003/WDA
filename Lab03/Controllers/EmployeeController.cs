using Lab03.Models;
using Lab03.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lab03.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeServices _service;
        public EmployeeController(EmployeeServices service) {
            _service = service;
        }

        [HttpGet]

        public IActionResult Index(string ename)
        {
            var model = _service.GetEmployees();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreateEmployee(Employee employee) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.saveEmployee(employee);
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var model = _service.GetEmployeeById(id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.updateEmployee(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
    }
}
