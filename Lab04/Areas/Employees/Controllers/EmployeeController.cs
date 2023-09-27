using Microsoft.AspNetCore.Mvc;

namespace Lab04.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
