using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace strah.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Article { get; set; }

    public string? Productname { get; set; }

    public string? Unit { get; set; }

    public decimal? Cost { get; set; }

    public int? SupplierId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? CategoryId { get; set; }

    public int? Discount { get; set; }

    public int? Countinstock { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public Bitmap GetImage
    {
        get
        {
            if (Image != null)
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + Image);
            }
            else
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/Images/picture.png");
            }
        }
    }

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<Ordersproduct> Ordersproducts { get; set; } = new List<Ordersproduct>();

    public virtual Supplier? Supplier { get; set; }
}
