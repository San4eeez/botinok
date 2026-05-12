using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? Suppliername { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
