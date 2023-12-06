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

        private String userNameLocal;
        private String dateTimeLocal;
        public ShoppingCartWindow(String userName, String dateTime)
        {
            InitializeComponent();

            userNameLocal = userName;
            dateTimeLocal = dateTime;
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow(userNameLocal, dateTimeLocal);
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
            this.Hide();
        }

        private void clickFaqs(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(userNameLocal, dateTimeLocal);
            faqsWindow.Show();
            this.Hide();
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.LoginWindowInstance != null && !WindowManager.LoginWindowInstance.IsVisible)
            {
                WindowManager.LoginWindowInstance.Show();
            }
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
    }
}
