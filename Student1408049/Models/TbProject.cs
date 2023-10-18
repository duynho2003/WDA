using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student1408049.Models;

public partial class TbProject
{
    public int Id { get; set; }
    [Required]
    public string? ClientName { get; set; }
    [Required]
    public string? ProjectName { get; set; }
    [Required]
    public DateTime? StartDate { get; set; }
    [Required]
    public DateTime? EndDate { get; set; }
    [Required]
    [Range(999, 100000, ErrorMessage = "Cost must be greater than $1000")]
    public decimal? Cost { get; set; }
}
