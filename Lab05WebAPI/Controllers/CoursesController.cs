using Lab05WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab05WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        static List<Course> courses = new List<Course>() {
            new Course {code ="7023-WDA", name="Web Develophing using ASP.NET MVC", fee=4560000 },
            new Course {code ="7023-ENJS", name="Essentials of NodeJS", fee=2736000 }
        };
        [HttpGet]
        public IActionResult GetCourses() 
        {
            List<Course> lisCourses = courses.ToList();
            return Ok(lisCourses);
        }
    }
}
