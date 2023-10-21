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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPO_Lab_23_24
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {

            string userName = txtBoxUser.Text.ToString();
            string userPass = PassBoxPass.Password.ToString();

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                lblWarning.Content = "Nombre de usuario y/o contraseña no válidos";
            }
            else
            {
                lblWarning.Content = "";
                if (userName == "admin" && userPass == "admin")
                {
                    LandingPage_Admin landingPage_Admin = new LandingPage_Admin(userName);
                    this.Close();
                    landingPage_Admin.Show();

                }
                else
                {
                    LandingPage_User landingPage_User = new LandingPage_User(userName);
                    this.Close();
                    landingPage_User.Show();
                }

            }
        }
    }
}
