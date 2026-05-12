using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using strah.Context;
using strah.Models;
using strah.Context;
using System.Linq;

namespace strah;

public partial class Window1 : Window
{
    public Window1()
    {
        InitializeComponent();
        GetInfo();
    }



    public void GetInfo()
    {
        CruzakContext context = new CruzakContext();

        var listProduct = context.Products.Include(x => x.Ordersproducts)
            .Include(x => x.Category)
            .Include(x => x.Manufacturer)
            .Include(x => x.Supplier)
            .ToList();

        if (SearchBox.Text != null)
        {
            listProduct = listProduct.Where(x => x.Productname.Contains(SearchBox.Text)).ToList();
        }

        switch (SortBox.SelectedIndex)
        {
            case 0:
                listProduct = listProduct.OrderBy(x => x.Cost).ToList();
                break;
            case 1:
                listProduct = listProduct.OrderByDescending(x => x.Cost).ToList();
                break;
           
        }

        Listproduct.ItemsSource = listProduct;
    }

    private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        GetInfo();
    }

    private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        GetInfo();
    }

    private void Listproduct_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        GetInfo();
    }
}