using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string? Fullname { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
