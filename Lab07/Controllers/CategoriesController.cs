using Lab07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
    public class CategoriesController : Controller
    {
        private Repository.CategoriesRepository _service;
        public CategoriesController(Repository.CategoriesRepository service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetCategories());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories newCategories)
        {
            try
            {
                if(ModelState.IsValid){
                    _service.AddCategory(newCategories);
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
