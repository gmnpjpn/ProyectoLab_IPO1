using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public LandingWindow()
        {
            InitializeComponent();

            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = "Ultimo Acceso: " + GlobalData.CurrentDateTime;

            // Load data
            LoadContentXML();

            // Indicate that the lstAlbumList items origin is albumList
            lstAlbumList.ItemsSource = GlobalData.AlbumList;

            var artistNames = GlobalData.AlbumList.Select(album => album.Author).Distinct().ToList();
            lstArtists.ItemsSource = artistNames;

            if (GlobalData.Username != "admin")
            {
                spAlbumEdition.Visibility = Visibility.Collapsed;
            }
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
                GlobalData.AlbumList.Add(newAlbum);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            //TODO (Some bugs encountered)
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userwindow = new UserWindow();
            WindowManager.UserWindowInstance = userwindow;
            userwindow.Show();
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
            WindowManager.FaqsWindowInstance = faqsWindow;
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

        private void btnFav_Click(object sender, RoutedEventArgs e)
        {
            if (lstAlbumList.SelectedItem != null && lstAlbumList.SelectedItem is Album selectedAlbum)
            {
                bool existsInFavorites = GlobalData.FavoritesList.Any(a =>
                    a.Name == selectedAlbum.Name &&
                    a.Author == selectedAlbum.Author
                );

                if (!existsInFavorites)
                {
                    GlobalData.FavoritesList.Add(selectedAlbum);
                    MessageBox.Show("Añadido correctamente a la lista de favoritos.", "Añadido a favoritos");
                    // Realizar otras acciones necesarias (actualizar interfaz, etc.)
                }
                else
                {
                    MessageBox.Show("El álbum ya está en la lista de favoritos.", "Error al añadir a favoritos");
                }
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

                ArtistWindow artistWindow = new ArtistWindow(selectedArtistName, selectedArtistBio, selectedArtistImage);
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
                // Eliminar el álbum seleccionado
                GlobalData.AlbumList.Remove(selectedAlbum);

                // Actualizar lstAlbumList con la nueva lista de álbumes
                lstAlbumList.ItemsSource = null;
                lstAlbumList.ItemsSource = GlobalData.AlbumList;

                // Recalcular la lista de artistas después de eliminar el álbum
                var artistNames = GlobalData.AlbumList.Select(album => album.Author).Distinct().ToList();

                // Actualizar lstArtists con la lista de autores actualizada
                lstArtists.ItemsSource = null;
                lstArtists.ItemsSource = artistNames;
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
