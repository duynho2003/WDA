using Lab07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab07.Controllers
{
    public class ProductController : Controller
    {
        private Repository.ProductRepository _service;
        private Repository.CategoriesRepository _pservice;
        public ProductController(Repository.ProductRepository service, Repository.CategoriesRepository pservice)
        {
            _service = service;
            _pservice = pservice;
        }
        public IActionResult Index()
        {
            return View(_service.findAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.cate = new SelectList(_pservice.GetCategories(), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products newProducts)
        {
            try
            {
                ViewBag.cate = new SelectList(_pservice.GetCategories(), "CategoryID", "CategoryName");
                if (ModelState.IsValid)
                {
                    _service.save(newProducts);
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
