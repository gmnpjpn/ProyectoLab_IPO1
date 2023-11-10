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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {

            DateTime actualDateTime = DateTime.Now;
            string dateTimeFormatted = actualDateTime.ToString("dd-MM-yyyy HH:mm");

            string userName = txtBoxUser.Text.ToString();
            string userPass = PassBoxPass.Password.ToString();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                lblWarning.Content = "Nombre de usuario y/o contraseña no válidos";
            }
            else
            {
                lblWarning.Content = "";
                if (userName == "admin" && userPass == "admin")
                {
                    LandingPage landingPage_Admin = new LandingPage(userName, dateTimeFormatted);
                    this.Close();
                    landingPage_Admin.Show();

                }
                else
                {
                    LandingPage landingPage_User = new LandingPage(userName, dateTimeFormatted);
                    this.Close();
                    landingPage_User.Show();
                }

            }
        }
    }
}
