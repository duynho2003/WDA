using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PretestFinal.Models;

namespace PretestFinal.Controllers
{
    public class TrainController : Controller
    {
        private TrainDbContext _context;
        public TrainController(TrainDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Trainer", Value = "true" },
                new SelectListItem { Text = "Trainee", Value = "false" }
            };

            var sex = new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "true" },
                new SelectListItem { Text = "Female", Value = "false" }
            };

            var viewModel = new ProfileTrainerViewModel
            {
                Roles = roles,
                Sex = sex
            };

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Create(ProfileTrainerViewModel user)
        {
            var newTrainer = new TbTrainer
            {
                Username = user.Trainer.Username,
                Password = user.Trainer.Password,
                Roles = user.Trainer.Roles
            };

            var newProfile = new TbProfile
            {
                Fullname = user.Profile.Fullname,
                Username = user.Trainer.Username,
                Birthday = user.Profile.Birthday,
                Sex = user.Profile.Sex,
                Placeofbirth = user.Profile.Placeofbirth,
                Skills = user.Profile.Skills
            };

            _context.TbTrainers.Add(newTrainer);
            _context.TbProfiles.Add(newProfile);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var username = HttpContext.Session.GetString("username");
            if (username != null)
            {
                var model = _context.TbTrainers
                            .Include(t => t.TbProfiles)
                            .SingleOrDefault(t => t.Username == username);

                return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Admin()
        {
            var model = _context.TbProfiles.ToList();
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.TbTrainers.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                if (user.Roles == true)
                {
                    return RedirectToAction("Profile");
                }
                else
                {
                    return RedirectToAction("Admin");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}