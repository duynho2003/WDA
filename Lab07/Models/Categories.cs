using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(25)]

        public string? CategoryName { get; set; }
        
        [Required]
        [StringLength(255)]
        public string? Description { get; set; }

        public ICollection<Products>? Products { get; set; }
    }
}
