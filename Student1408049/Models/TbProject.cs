using System;
using System.Collections.Generic;

namespace Student1408049.Models;

public partial class TbProject
{
    public int Id { get; set; }

    public string? ClientName { get; set; }

    public string? ProjectName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Cost { get; set; }
}
