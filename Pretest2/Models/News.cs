using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pretext2.Models
{
    [Table("TBL_News")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }

        [Required]
        [StringLength(20)]
        public string? HeadLines { get; set; }

        [Required]
        [StringLength(50)]
        public string? ContentOfNews { get; set;}
    }
}
