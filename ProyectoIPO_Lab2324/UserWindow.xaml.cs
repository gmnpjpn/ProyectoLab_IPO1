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
    /// Lógica de interacción para UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {

        public UserWindow()
        {
            InitializeComponent();

            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = GlobalData.CurrentDateTime;

            listbox_favorites.ItemsSource = GlobalData.FavoritesList;
            listbox_favorites.DisplayMemberPath = "Name";
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LandingWindowInstance.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
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
            ShoppingCartWindow shoppingCart = new ShoppingCartWindow();
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            shoppingCart.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void StopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnDeleteFavorite_Click(object sender, RoutedEventArgs e)
        {

            Album selectedAlbum = listbox_favorites.SelectedItem as Album;

            if (listbox_favorites.SelectedItem != null)
            {
                // Eliminar el álbum seleccionado de la lista de álbumes
                GlobalData.FavoritesList.Remove(selectedAlbum);

                // Actualizar la lista de álbumes
                listbox_favorites.ItemsSource = null;
                listbox_favorites.ItemsSource = GlobalData.FavoritesList;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un favorito para eliminar.", "Álbum no seleccionado");
            }
        }

    }
}
