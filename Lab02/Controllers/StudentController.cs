using Lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
    public class StudentController : Controller
    {
        private DatabaseContext db;
        public StudentController(DatabaseContext _db) 
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var model =db.Student.ToList();
            var model = from s 
                        in db.Student 
                        select s;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            try
            {
                var student = db.Student.SingleOrDefault(
                  s => s.code.Equals(newStudent.code));
                if(ModelState.IsValid) 
                {
                    if (student == null)
                    {
                        db.Student.Add(newStudent);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Msg = "Has existed...";
                    }
                }
                else 
                {
                    ViewBag.Msg = "Fail...";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            }
            return View();
        }

        public IActionResult Delete(string code)
        {
            try
            {
                var student = db.Student.SingleOrDefault(s => s.code.Equals(code));
                if (student != null)
                {
                    db.Student.Remove(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}