using System;
using System.Collections.Generic;

namespace Pretest1.Models;

public partial class TaskSheet
{
    public int TaskID { get; set; }

    public string EmpID { get; set; } = null!;

    public string TaskName { get; set; } = null!;

    public DateTime? StartTime { get; set; }

    public DateTime? FinishTime { get; set; }
}
