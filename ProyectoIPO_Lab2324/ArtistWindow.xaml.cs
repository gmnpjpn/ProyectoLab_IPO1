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
        private string textbox_user_local;
        private string dateTime_local;

        public ArtistWindow(String selectedAartistName, String selectedArtistBio, String textbox_user, String dateTime, Uri selectedArtistImage)
        {
            InitializeComponent();
            textbox_user_local = textbox_user;
            dateTime_local = dateTime;

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
            FaqsWindow faqsWindow = new FaqsWindow(textbox_user_local, dateTime_local);
            faqsWindow.Show();
            this.Hide();
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
