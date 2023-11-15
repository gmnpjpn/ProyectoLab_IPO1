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

namespace IPO_Lab_23_24
{
    /// <summary>
    /// Lógica de interacción para LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage(string userName, string dateTimeFormatted)
        {
            InitializeComponent();
            lblUser.Content = userName;
            lblLastAccess.Content = dateTimeFormatted;
        }

        private void clickLogout(object sender, RoutedEventArgs e)
        {
            MainWindow loginPage = new MainWindow();
            this.Close();
            loginPage.Show();
        }
    }
}
