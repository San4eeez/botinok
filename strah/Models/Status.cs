using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Statusname { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
