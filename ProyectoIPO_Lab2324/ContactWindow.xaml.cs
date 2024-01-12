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
    public partial class ContactWindow : Window
    {
        public ContactWindow()
        {
            InitializeComponent();

            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = GlobalData.CurrentDateTime;

            changeView_UserAdmin();
        }

        private void changeView_UserAdmin()
        {
            if (GlobalData.Username != "admin")
            {
                pin.Visibility = Visibility.Collapsed;
                textbox_email.IsEnabled = false;
                textbox_phoneNumber.IsEnabled = false;
                img_sq_cr.Visibility = Visibility.Collapsed;
                img_sq_cu.Visibility = Visibility.Collapsed;
                img_sq_to.Source = new BitmapImage(new Uri("/Resources/Contact/pin.png", UriKind.Relative));
                label_add_pin.Visibility = Visibility.Collapsed;
            }
            else
            {
                pin.Visibility = Visibility.Visible;
                textbox_email.IsEnabled = true;
                textbox_phoneNumber.IsEnabled = true;
                img_sq_cr.Visibility = Visibility.Visible;
                img_sq_cu.Visibility = Visibility.Visible;
                label_add_pin.Visibility = Visibility.Visible;
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            if (WindowManager.LandingWindowInstance != null && !WindowManager.LandingWindowInstance.IsVisible)
            {
                WindowManager.LandingWindowInstance.Show();
            }
            this.Hide();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
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

            if (GlobalData.Username == "admin")
            {
                MessageBox.Show("Función no disponible en modo administración", "Función no disponible");
            }
            else
            {
                ShoppingCartWindow shoppingCart = new ShoppingCartWindow();
                WindowManager.ShoppingCartWindowInstance = shoppingCart;
                shoppingCart.Show();
                this.Hide();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.LoginWindowInstance != null && !WindowManager.LoginWindowInstance.IsVisible)
            {
                WindowManager.LoginWindowInstance.Show();
            }
            this.Hide();

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)combobox_language.SelectedItem; string selectedText = cbi.Content.ToString();
            if (tbEmail.Text == "" || tbSuggestion.Text == "")
            {
                if (selectedText.Equals("ES") || selectedText.Equals("SP"))
                {
                    MessageBox.Show("Uno de los campos está vacío, rellénelo y vuelvalo a intentar", "Error en el envío de la sugerencia");
                }
                else
                {
                    MessageBox.Show("One of the fields is empty, fill it in and try again", "Error sending suggestion");
                }
            }
            else
            {
                tbEmail.Text = "";
                tbSuggestion.Text = "";

                if (selectedText.Equals("ES") || selectedText.Equals("SP"))
                {
                    MessageBox.Show("¡Sugerencia enviada!", "Envío de sugerencia");
                }
                else
                {
                    MessageBox.Show("Suggestion sent succesfully!", "Sending message");
                }

            }
        }

        private void StartDrag(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject((Image)sender);
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void AddObject(object sender, DragEventArgs e)
        {
            Image imgDragged = (Image)e.Data.GetData(typeof(Image));
            Image imgToUpdate = (Image)e.OriginalSource;
            imgToUpdate.Source = imgDragged.Source;
        }

        private void StopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void combobox_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)combobox_language.SelectedItem; string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP")) && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));
            }
            else if (selectedText.Equals("EN")
            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                Resources.MergedDictionaries.Add(App.SelectCulture("en-US"));
            }
        }
    }
}