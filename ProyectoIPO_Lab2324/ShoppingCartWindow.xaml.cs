using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoIPO_Lab2324
{
    /// <summary>
    /// Lógica de interacción para ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        private String usernameLocal;
        private String datetimeLocal;
        public ShoppingCartWindow(String username, String dateTime)
        {
            InitializeComponent();

            usernameLocal = username;
            datetimeLocal = dateTime;
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LandingWindowInstance.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnFaqs_Click(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(usernameLocal, datetimeLocal);
            faqsWindow.Show();
            this.Hide();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void StopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
