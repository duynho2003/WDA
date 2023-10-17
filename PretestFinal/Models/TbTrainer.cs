using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PretestFinal.Models;

public partial class TbTrainer
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    public bool? Roles { get; set; }
    [Required]
    public virtual ICollection<TbProfile> TbProfiles { get; set; } = new List<TbProfile>();
}
