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
    /// Lógica de interacción para ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {

        private string usernameLocal;
        private string datetimeLocal;

        public ContactWindow(String username, String datetime)
        {
            InitializeComponent();
            usernameLocal = username;
            datetimeLocal = datetime;
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
            // TODO
        }

        private void btnFaqs_Click(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(usernameLocal, datetimeLocal);
            faqsWindow.Show();
            this.Hide();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCart = new ShoppingCartWindow(usernameLocal, datetimeLocal);
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            shoppingCart.Show();
            this.Hide();

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
            if(tbEmail.Text == "" || tbSuggestion.Text == "")
            {
                MessageBox.Show("Uno de los cammpos está vacío, rellénelo y vuelvalo a intentar", "Error en el envío de la sugerencia");
            }
            else
            {
                tbEmail.Text = "";
                tbSuggestion.Text = "";
                MessageBox.Show("¡Sugerencia enviada!", "Envío de sugerencia");
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
    }
}
