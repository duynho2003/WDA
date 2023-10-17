using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PretestFinal.Models;

public partial class TbProfile
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Fullname { get; set; }
    [Required]
    public bool? Sex { get; set; }
    [Required]
    public DateTime? Birthday { get; set; }
    [Required]
    public string? Placeofbirth { get; set; }
    [Required]
    public string? Skills { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public virtual TbTrainer? UsernameNavigation { get; set; }
}
