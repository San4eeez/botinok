using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using strah.Context;
using System.Linq;

namespace strah
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           CruzakContext context = new CruzakContext();

            if (LoginBox.Text != null && PasswordBox.Text != null)
            {
                var user = context.Users.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text);

                if (user != null)
                {
                    SaveUser._user = user;

                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                }
            }
        }
    }
}