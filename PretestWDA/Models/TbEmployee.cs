using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PretestWDA.Models;

public partial class TbEmployee
{
    [Key]
    public int? EmpId { get; set; }
    [Required]
    public DateTime? EmpDob { get; set; }
    [Required]
    public string? EmpName { get; set; }
    [Required]
    public string? EmpAddress { get; set; }
    [Required]
    public string? EmpEmail { get; set; }
}
