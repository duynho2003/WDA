using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pretest3.Models;

public partial class TbUser
{
    public string UserId { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string? PassWord { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? DateOfBirth { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public bool? IsAdmin { get; set; }
}
