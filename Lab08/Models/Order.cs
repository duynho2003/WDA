using System;
using System.Collections.Generic;

namespace Lab08.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Customer? Customer { get; set; }
}
