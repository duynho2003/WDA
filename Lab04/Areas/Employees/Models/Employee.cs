using Lab04.Areas.Departments.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04.Areas.Employees.Models
{
    [Table("tbEmployee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        public DateTime JoinDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public int No { get; set; }//FK
        public Department? Department { get; set; }
    }
}
