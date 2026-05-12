using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int? PointId { get; set; }

    public int? UserId { get; set; }

    public string? Code { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Ordersproduct> Ordersproducts { get; set; } = new List<Ordersproduct>();

    public virtual Deliveypoint? Point { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? User { get; set; }
}
