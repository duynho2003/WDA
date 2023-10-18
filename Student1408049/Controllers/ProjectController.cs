using Microsoft.AspNetCore.Mvc;
using Student1408049.Models;

namespace Student1408049.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext _context;
        public ProjectController(ProjectDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.TbProjects.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TbProject project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TbProjects.Add(project);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception) 
            {
                throw;
            }
            return View();
        }
        public IActionResult UpdateOrRemove(int id)
        {
            var project = _context.TbProjects.SingleOrDefault(e => e.Id == id);
            if (project == null)
            {
                return NoContent();
            }
            else
            {
                return View(project);
            }
        }
        [HttpPost]
        public IActionResult UpdateOrRemove(TbProject project, string submits) 
        {
            try
            {
                var proj = _context.TbProjects.SingleOrDefault(e => e.Id.Equals(project.Id));
                if (submits.Equals("Update"))
                {
                    if (proj != null)
                    {
                        proj.ClientName = project.ClientName;
                        proj.ProjectName = project.ProjectName;
                        proj.StartDate = project.StartDate;
                        proj.EndDate = project.EndDate;
                        proj.Cost = project.Cost;
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var projDel = _context.TbProjects.SingleOrDefault(e => e.Id.Equals(project.Id));
                    if (projDel != null)
                        _context.TbProjects.Remove(projDel);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
