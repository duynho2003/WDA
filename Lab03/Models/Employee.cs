using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab03.Models
{
    [Table("tbEmployee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee name is required...")]
        [StringLength(60,MinimumLength =2,
            ErrorMessage ="Name from 2 to 60 characters")]
        public string? Name { get; set; }
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [Range(300,30000,ErrorMessage ="Salary from $300 to $30000")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Department is required...")]
        public string? Department { get; set; }

    }
}
