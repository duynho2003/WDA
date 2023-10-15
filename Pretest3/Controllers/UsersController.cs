using Microsoft.AspNetCore.Mvc;
using Pretest3.Models;
using Pretest3.Repository;

namespace Pretest3.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository _service;
        public UsersController(UsersRepository service) 
        { 
            _service = service;
        } 
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("userId") == null)
            {
                return RedirectToAction("login");
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(TbUser user) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.AddUser(user);
                    return RedirectToAction("Admin");
                }
                else
                { 
                    ViewBag.Msg = string.Empty;
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;   
                throw;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserId, string PassWord) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TbUser user = _service.checkLogin(UserId, PassWord);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("userId", UserId);
                        if (user.IsAdmin == true)
                        {
                            return RedirectToAction("Admin");
                        }
                        else if(user.IsAdmin == false)
                        {
                            return RedirectToAction("Details");
                        }
                    }
                    else
                    {
                        ViewBag.Msg = "Invalid UserId and PassWord";
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fali!");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;

                throw;
            }
        }

        [HttpGet]
        public IActionResult Details(string UserId)
        {
            var model = _service.FindOne(UserId);
            return View(model);
        }
    }
}
