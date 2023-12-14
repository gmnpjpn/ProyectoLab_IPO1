
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            label_warning.Content = "";
            textbox_user.Text = "";
            passBox.Password = "";
        }

        private void click_login(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textbox_user.Text)) && (!string.IsNullOrWhiteSpace(passBox.Password)))
            {
                // Save the actual time and date
                DateTime dateTimeNow = DateTime.Now;
                TextBox dateTime = new TextBox();
                dateTime.Text = dateTimeNow.ToString();

                LandingWindow landingWindow = new LandingWindow(textbox_user.Text, dateTime.Text);
                WindowManager.LandingWindowInstance = landingWindow;

                textbox_user.Text = "";
                passBox.Password = "";

                landingWindow.Show();
                this.Hide();
            }
            else
            {
                label_warning.Content = "Credenciales Incorrectas";
                label_warning.Visibility = Visibility.Visible;
            }
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void combobox_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbIdiomas.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if (selectedText.Equals("Español")
            && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            }
            else if (selectedText.Equals("English")
            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("en-US"));
            }
        }
    }
}







