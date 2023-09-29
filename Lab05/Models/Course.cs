using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab05.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? code { get; set; }
        [Required(ErrorMessage = "Name is required...")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Name from 2 to 100")]
        public string? name { get; set; }
        public string? duration { get; set; }
        public decimal fee { get; set; }
        public string? photo { get; set; }
    }
}
