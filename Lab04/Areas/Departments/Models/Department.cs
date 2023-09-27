using Lab04.Areas.Employees.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04.Areas.Departments.Models
{
    [Table("tbDepartment")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<Employee>? Employee { get; set; }
    }
}