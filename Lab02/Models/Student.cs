using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02.Models
{
    [Table("tbStudent")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string code { get; set; }
        [Required(ErrorMessage ="Student code is required...")]
        [StringLength(50)]
        public string? name { get; set; }
        [Required(ErrorMessage = "Student name is required...")]
        [StringLength(50)]
        [DataType(DataType.MultilineText)]
        public string? address { get; set; }
        public string? phone { get; set; }
    }
}
