using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        public int CategoryID { get; set; } //FK
        
        [StringLength(25)]
        public string? Unit { get; set; }
        public decimal Price { get; set; }

        public Categories? Categories { get; set; }
    }
}
