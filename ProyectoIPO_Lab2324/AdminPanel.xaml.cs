using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoIPO_Lab2324
{
    /// <summary>
    /// Lógica de interacción para AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public string RutaSeleccionada { get; set; }

        public AdminPanel()
        {
            InitializeComponent();

            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = GlobalData.CurrentDateTime;

            DataContext = this; // Establece el DataContext para el enlace de datos

        }

        private void SeleccionarArchivo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmarEnvio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LandingWindowInstance.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
            this.Hide();
        }

        private void btnFaqs_Click(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow();
            faqsWindow.Show();
            this.Hide();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCart = new ShoppingCartWindow();
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            shoppingCart.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
