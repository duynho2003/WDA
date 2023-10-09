using Microsoft.AspNetCore.Mvc;
using PretestWDA.Models;

namespace PretestWDA.Controllers
{
    public class EmployeeController : Controller
    {
        private SaleManagerContext _context;
        public EmployeeController(SaleManagerContext context) {
        _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.TbEmployees.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TbEmployee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TbEmployees.Add(employee);
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

        public IActionResult EditOrDelete(int id)
        {
            var employee = _context.TbEmployees.SingleOrDefault(e=>e.EmpId == id);
            if (employee == null)
            {
                return NoContent();
            }
            else
            {
                return View(employee);
            }
        }
        [HttpPost]
        public IActionResult EditOrDelete(TbEmployee employee, string submits)
        {
            try
            {
                var emp = _context.TbEmployees.SingleOrDefault(e => e.EmpId.Equals(employee.EmpId));
                if (submits.Equals("Update"))
                {
                     if (emp != null)
                     {
                        emp.EmpDob = employee.EmpDob;
                        emp.EmpName = employee.EmpName;
                        emp.EmpAddress = employee.EmpAddress;
                        emp.EmpEmail = employee.EmpEmail;
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
                    var empDel = _context.TbEmployees.SingleOrDefault(e => e.EmpId.Equals(employee.EmpId));
                    if(empDel != null)
                    _context.TbEmployees.Remove(empDel);
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
