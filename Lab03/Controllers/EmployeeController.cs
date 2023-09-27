using Lab03.Models;
using Lab03.Repository;
using Lab03.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lab03.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeServices _service;
        public EmployeeController(EmployeeServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index(string ename)
        {
            if (ename.IsNullOrEmpty())
            {
                var model = _service.GetEmployees();
                ViewBag.data = model;
                //TempData.data = model;
                return View(model);
            }
            else
            {
                var model = _service.GetEmployees(ename);
                ViewBag.data = model;
                return View(model);

            }
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
        public IActionResult Edit(int id)
        {
            var model = _service.GetEmployeeById(id);
            return View(model);
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

        //delete 
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _service.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }
    }
}
