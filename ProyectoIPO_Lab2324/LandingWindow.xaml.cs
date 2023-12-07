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
using System.Xml;

namespace ProyectoIPO_Lab2324
{
    /// <summary>
    /// Lógica de interacción para LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {

        private string userNameLocal;
        private string dateTimeLocal;
        List<Album> albumList;

        public LandingWindow(String userName, String dateTime)
        {
            InitializeComponent();
            userNameLocal = userName;
            dateTimeLocal = dateTime;

            textblock_lastTime.Text = "Ultimo Acceso: " + dateTime;
            textblock_username.Text = userNameLocal;

            // Create album list
            albumList = new List<Album>();
            // Load data
            LoadContentXML();

            // Indicate that the lstAlbumList items origin is albumList
            lstAlbumList.ItemsSource = albumList;
        }

        private void LoadContentXML()
        {
            XmlDocument doc = new XmlDocument();
            var file = Application.GetResourceStream(new Uri("/Resources/Data/Albums.xml", UriKind.Relative));
            doc.Load(file.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var newAlbum = new Album();

                newAlbum.Name = node.Attributes["Name"].Value;
                newAlbum.Author = node.Attributes["Author"].Value;
                newAlbum.Cover = new Uri(node.Attributes["Cover"].Value, UriKind.Relative);
                newAlbum.Genre = node.Attributes["Genre"].Value;
                newAlbum.LaunchYear = node.Attributes["LaunchYear"].Value;
                newAlbum.RecordLabel = node.Attributes["RecordLabel"].Value;
                newAlbum.Format = node.Attributes["Format"].Value;
                newAlbum.Country = node.Attributes["Country"].Value;
                newAlbum.Likes = node.Attributes["Likes"].Value;
                newAlbum.Puntuation = node.Attributes["Puntuation"].Value;
                newAlbum.Pvp = node.Attributes["Pvp"].Value;
                newAlbum.Stock = node.Attributes["Stock"].Value;
                newAlbum.ArtistBio = node.Attributes["ArtistBio"].Value;
                newAlbum.ArtistImage = new Uri(node.Attributes["ArtistImage"].Value, UriKind.Relative);

                // Obtener la lista de canciones
                foreach (XmlNode songNode in node.SelectNodes("SongList/Song"))
                {
                    newAlbum.Songs.Add(songNode.InnerText);
                }
                albumList.Add(newAlbum);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            //TODO (Some bugs encountered)
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userwindow = new UserWindow(userNameLocal, dateTimeLocal);
            WindowManager.UserWindowInstance = userwindow;
            userwindow.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow(userNameLocal, dateTimeLocal);
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
            this.Hide();
        }

        private void btnFaqs_Click(object sender, RoutedEventArgs e)
        {
            FaqsWindow faqsWindow = new FaqsWindow(userNameLocal, dateTimeLocal);
            WindowManager.FaqsWindowInstance = faqsWindow;
            faqsWindow.Show();
            this.Hide();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCart = new ShoppingCartWindow(userNameLocal, dateTimeLocal);
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            shoppingCart.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void btnFav_Click(object sender, RoutedEventArgs e)
        {
            string albumPlusArtist = lblName.Content.ToString() + " - " + lblAuthor.Content.ToString();

            // Verify if it exists on the favs list
            if (!lstFavorites.Items.Contains(albumPlusArtist))
            {
                lstFavorites.Items.Add(albumPlusArtist);
            }
            else
            {
                MessageBox.Show("Este álbum ya está en tus favoritos.", "Error al añadir a favoritos");
            }
        }

        private void btnDeleteFav_Click(object sender, RoutedEventArgs e)
        {
            // Check if the selected item is in the favs list
            if (lstFavorites.SelectedItem != null)
            {
                lstFavorites.Items.Remove(lstFavorites.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un elemento de la lista para eliminarlo.", "Error al eliminar un favorito");
            }
        }

        private void btnArtistPage_Click(object sender, RoutedEventArgs e)
        {
            Album selectedAlbum = lstAlbumList.SelectedItem as Album;

            if (selectedAlbum != null)
            {
                string selectedArtistName = selectedAlbum.Author;
                string selectedArtistBio = selectedAlbum.ArtistBio;
                Uri selectedArtistImage = selectedAlbum.ArtistImage;

                ArtistWindow artistWindow = new ArtistWindow(selectedArtistName, selectedArtistBio, userNameLocal, dateTimeLocal, selectedArtistImage);
                WindowManager.ArtistWindowInstance = artistWindow;
                artistWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un álbum para ver información del artista.", "Error al acceder a la página del artista");
            }
        }

        ////////// ALBUM LIST MANAGEMENT //////////
        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            Album selectedAlbum = lstAlbumList.SelectedItem as Album;

            if (selectedAlbum != null)
            {
                albumList.Remove(selectedAlbum);

                lstAlbumList.ItemsSource = null;
                lstAlbumList.ItemsSource = albumList;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un álbum para eliminar.", "Álbum no seleccionado");
            }
        }

        private void btnEditAlbum_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnBuyAlbum_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
