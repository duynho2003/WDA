using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pretest1.Models;

public partial class Employee
{
    [Required]
    public string EmpID { get; set; } = null!;

    public string EmpName { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string EmpPass { get; set; } = null!;
}
