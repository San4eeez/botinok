using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Ordersproduct
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductsId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Products { get; set; }
}
