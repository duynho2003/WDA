using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PretestWDA.Models;

public partial class TbEmployee
{
    [Key]
    public int? EmpId { get; set; }

    public DateTime? EmpDob { get; set; }

    public string? EmpName { get; set; }

    public string? EmpAddress { get; set; }

    public string? EmpEmail { get; set; }
}
