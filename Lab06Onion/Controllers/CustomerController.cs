using Microsoft.AspNetCore.Mvc;
using Lab06Infrastructure.Repository;
using Lab06Domain.Models;

namespace Lab06Onion.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _service;
        public CustomerController(CustomerRepository service) 
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.code=HttpContext.Session.GetString("cuscode");
            if (HttpContext.Session.GetString("cuscode")==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var model = _service.findAll();
                return View(model);
            }
        }
        public IActionResult Profile(Customer customer)
        {
            ViewBag.code = HttpContext.Session.GetString("cuscode");
            if (HttpContext.Session.GetString("cuscode") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(customer);
            }
        }
        public IActionResult Details(string code)
        {
            var model = _service.findOne(code);
            return View(model);
        }
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string code, string pass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  Customer customer = _service.checkLogin(code, pass);
                    if (customer != null)
                    {
                        HttpContext.Session.SetString("cuscode", code);
                        if (customer.role == true)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Profile", customer);
                        }
                    }
                    else
                    {
                        ViewBag.Msg="Invalid code and password";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
            }
            return View();
        }

        public IActionResult Logout()
        {
            var session = HttpContext.Session.GetString("cuscode");
            if (session != null)
            {
                //HttpContext.Session.Remove(session);
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
