using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pretext2.Models
{
    [Table("TBL_Info")]
    public class Infos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string? Password { get; set; }
    }
}
