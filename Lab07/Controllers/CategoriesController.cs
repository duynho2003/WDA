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
    }
}
