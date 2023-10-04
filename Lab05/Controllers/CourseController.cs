using Lab05.Models;
using Lab05.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lab05.Controllers
{
    public class CourseController : Controller
    {

        private CourseRepository _service;
        public CourseController(CourseRepository service) 
        { 
            _service = service;
        }
        [HttpGet]
        public IActionResult Index(decimal? min, decimal? max)
        {
            var model = _service.FindAll(min, max);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course,IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string path = Path.Combine("wwwroot/Images", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);

                    course.photo="Images/" + file.FileName;

                    _service.saveCourse(course);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(string? code) 
        { 
            var model = _service.FindOne(code!);
            return View(model);
        }
    }
}
