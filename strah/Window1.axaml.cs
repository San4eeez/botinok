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

        if (SaveUser._user.RoleId == 3)
        {
            SearchBox.IsVisible = false;
            SortBox.IsVisible = false;
            AddProd.IsVisible = false;
        }
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
            listProduct = listProduct.Where(x => x.Productname.Contains(SearchBox.Text)
            || x.Category.Categoryname.Contains(SearchBox.Text)
            || x.Manufacturer.Manufacturername.Contains(SearchBox.Text)
            || x.Supplier.Suppliername.Contains(SearchBox.Text)


            ).ToList();
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
        var product = Listproduct.SelectedItem as Product;
        AddProductr addProductr = new AddProductr(product);
        addProductr.Show();
        this.Close();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int id = (int)(sender as Button)!.Tag!;

        CruzakContext cruzik = new CruzakContext();

        var product = cruzik.Products.Include(x => x.Ordersproducts).FirstOrDefault(x => x.ProductId == id);

        if (product != null && product.Ordersproducts.Count == 0)
        {
            cruzik.Products.Remove(product);
            cruzik.SaveChanges();
            GetInfo();
        }
    }

    private void AddProd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddProductr addProductr = new AddProductr();
        addProductr.Show();
        this.Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}