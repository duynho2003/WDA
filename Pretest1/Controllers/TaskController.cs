using Microsoft.AspNetCore.Mvc;
using Pretest1.Models;
using Pretest1.Repository;

namespace Pretest1.Controllers
{
    public class TaskController : Controller
    {
        private TaskRepository _service;
        public TaskController(TaskRepository service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString("empName");
            if (HttpContext.Session.GetString("empID") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var model = _service.FindAll();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EmpID = HttpContext.Session.GetString("empID");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskSheet task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.AddTask(task);
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
                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string empID, string empPass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = _service.CheckLogin(empID, empPass);
                    if (employee != null)
                    {
                        HttpContext.Session.SetString("empID", empID);
                        HttpContext.Session.SetString("empName", employee.EmpName!);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "ID and Pass invalid.";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg += ex.Message;
                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            var session = HttpContext.Session.GetString("empID");
            if (session != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
