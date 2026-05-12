using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string? Manufacturername { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
