using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Deliveypoint
{
    public int PointId { get; set; }

    public string? Pointname { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
