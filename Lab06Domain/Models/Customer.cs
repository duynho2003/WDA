using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06Domain.Models
{
    [Table("tbCustomer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Code is required...")]
        public string? code { get; set; }
        [Required(ErrorMessage ="Name is required...")]
        [StringLength(60, MinimumLength = 1,ErrorMessage = "Name from 1 to 60 characters")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Password is required...")]
        [DataType(DataType.Password)]
        public string? password { get; set; }
        [Required(ErrorMessage = "Address is required...")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Address from 3 to 150 characters")]
        [DataType(DataType.MultilineText)]
        public string? address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
        [Required(ErrorMessage ="Balance is required")]
        [Range(2,500000)]
        [DataType(DataType.Currency)]
        public decimal balance { get; set; }
        public bool role { get; set; }
    }
}