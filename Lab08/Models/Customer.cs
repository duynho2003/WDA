using System;
using System.Collections.Generic;

namespace Lab08.Models;

public partial class Customer
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
