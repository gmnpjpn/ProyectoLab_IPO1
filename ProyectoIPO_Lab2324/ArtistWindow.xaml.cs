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
    /// Lógica de interacción para ArtistWindow.xaml
    /// </summary>
    public partial class ArtistWindow : Window
    {
        private string usernameLocal;
        private string datetimeLocal;

        public ArtistWindow(String selectedAartistName, String selectedArtistBio, String username, String datetime, Uri selectedArtistImage)
        {
            InitializeComponent();
            usernameLocal = username;
            datetimeLocal = datetime;

            lblArtistName.Content = selectedAartistName;
            tbBio.Text = selectedArtistBio;
            imgArtist.Source = new BitmapImage(selectedArtistImage);
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Hide();
        }

        private void clickFaqs(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(usernameLocal, datetimeLocal);
            faqsWindow.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            if (WindowManager.LandingWindowInstance != null && !WindowManager.LandingWindowInstance.IsVisible)
            {
                WindowManager.LandingWindowInstance.Show();
            }
            this.Hide();
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userwindow = new UserWindow(usernameLocal, datetimeLocal);
            WindowManager.UserWindowInstance = userwindow;
            userwindow.Show();
            this.Hide();

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCart = new ShoppingCartWindow(usernameLocal, datetimeLocal);
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            shoppingCart.Show();
            this.Hide();

        }

        private void btnFaqs_Click(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(usernameLocal, datetimeLocal);
            WindowManager.FaqsWindowInstance = faqsWindow;
            faqsWindow.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow(usernameLocal, datetimeLocal);
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
            this.Hide();
        }
    }
}
