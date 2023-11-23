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
    /// Lógica de interacción para LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {

        private string textbox_user_local;
        private string dateTime_local;

        public LandingWindow(String textbox_user, String dateTime)
        {
            InitializeComponent();
            textbox_user_local = textbox_user;
            dateTime_local = dateTime;

            textblock_lastTime.Text = "Ultimo Acceso: " + dateTime;
            textblock_username.Text = textbox_user_local;
        }

        // It makes program to shutdown when clicked (main window is hide and not closed to preserve execution running)
        private void closingButton_event(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            LandingWindow landingWindow = new LandingWindow(textbox_user_local, dateTime_local);
            landingWindow.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
