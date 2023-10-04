using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
    public class ProductController : Controller
    {
        private Repository.ProductRepository _service;
        public ProductController(Repository.ProductRepository service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.findAll());
        }
    }
}
