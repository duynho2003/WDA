using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Lab05WebApp.Models;
using System.Net.Http;

namespace Lab05WebApp.Controllers
{
    public class CourseController : Controller
    {
        private HttpClient client=new HttpClient();
        private string url="http://localhost:5247/api/Courses/";
        public IActionResult Index()
        {
            var model=JsonConvert.DeserializeObject<IEnumerable<Course>>(
                                            client.GetStringAsync(url).Result);
            return View(model);
        }
    }
}
