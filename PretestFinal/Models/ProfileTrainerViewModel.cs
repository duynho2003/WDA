using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PretestFinal.Models
{
    public class ProfileTrainerViewModel
    {
        [Required]
        public TbProfile? Profile { get; set; }
        [Required]
        public TbTrainer? Trainer { get; set; }
        [Required]
        public List<SelectListItem> Roles { get; set; }
        [Required]
        public List<SelectListItem> Sex { get; set; }
    }
}
