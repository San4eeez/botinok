using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
