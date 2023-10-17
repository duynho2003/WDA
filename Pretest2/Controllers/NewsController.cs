using Microsoft.AspNetCore.Mvc;
using Pretext2.Models;
using Pretext2.Repository;

namespace Pretext2.Controllers
{
    public class NewsController : Controller
    {
        private NewsRepository _service;
        public NewsController(NewsRepository service)
        { 
            _service = service;
        }
        [HttpGet]
        public IActionResult ShowAllNews()
        {
            var model = _service.FindAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("uname") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            if (id != null)
            {
                _service.Delete(id);
            }   
            var model = _service.FindAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNews() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(News addnew)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.AddNew(addnew);
                    return RedirectToAction("ShowAllNews");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Fail!");
                }
            }
            catch (Exception ex)
            {
                    ModelState.AddModelError(String.Empty, ex.Message);
                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    Infos info = _service.checkLogin(username, password);
                    if (info != null)
                    {
                        HttpContext.Session.SetString("uname", username);
                        return RedirectToAction("Admin");
                    }
                    else
                    {
                        ViewBag.Msg = "Invalid username and password";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }
        public IActionResult Logout()
        {
            var session = HttpContext.Session.GetString("uname");
            if (session != null) 
            {
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
