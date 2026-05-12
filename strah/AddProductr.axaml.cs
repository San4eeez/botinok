using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using strah.Context;
using strah.Models;
using strah.Context;
using System.Linq;

namespace strah;

public partial class AddProductr : Window
{
    public AddProductr()
    {
        InitializeComponent();
        DataContext = new Product();
    }

    public AddProductr(Product product)
    {
        InitializeComponent();
        DataContext = product;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CruzakContext cruzak = new CruzakContext();

        var product = DataContext as Product;

        cruzak.Products.Add(product);
        cruzak.SaveChanges();

        
        Window1 window1 = new Window1();
        window1.Show();
        this.Close();
    }

    private void Button_Click1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        try
        {
            CruzakContext cruzak = new CruzakContext();

            var product = DataContext as Product;

            var redactionproduct = cruzak.Products.Include(x => x.Ordersproducts).FirstOrDefault(x => x.ProductId == product.ProductId);

            redactionproduct.Productname = product.Productname;

            cruzak.Products.Update(redactionproduct);

            cruzak.SaveChanges();

            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        catch
        {

        }

       

    }
}