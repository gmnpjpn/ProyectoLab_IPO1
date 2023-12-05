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

        private string textbox_user_local;
        private string dateTime_local;

        List<Album> albumList;


        public LandingWindow(String textbox_user, String dateTime)
        {
            InitializeComponent();
            textbox_user_local = textbox_user;
            dateTime_local = dateTime;

            textblock_lastTime.Text = "Ultimo Acceso: " + dateTime;
            textblock_username.Text = textbox_user_local;

            // Create album list
            albumList = new List<Album>();
            // Load data
            LoadContentXML();

            // Indicate that the lstAlbumList items origin is albumList
            lstAlbumList.ItemsSource = albumList;

        }

        private void LoadContentXML()
        {
            // Load test data
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

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.LoginWindowInstance != null && !WindowManager.LoginWindowInstance.IsVisible)
            {
                WindowManager.LoginWindowInstance.Show();
            }
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

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            string albumPlusArtist = lblName.Content.ToString() + " - " + lblAuthor.Content.ToString();

            // Verificar si el contenido ya existe en la lista
            if (!lstFavorites.Items.Contains(albumPlusArtist))
            {
                // Agregar el contenido de lblName a la lista lstFavorites
                lstFavorites.Items.Add(albumPlusArtist);
            }
            else
            {
                // Si ya existe, puedes manejar esto como desees (por ejemplo, mostrar un mensaje)
                MessageBox.Show("Este álbum ya está en tus favoritos.", "Error al añadir a favoritos");
            }
        }

        private void btnDeleteFav_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay un elemento seleccionado en lstFavorites
            if (lstFavorites.SelectedItem != null)
            {
                // Eliminar el elemento seleccionado de lstFavorites
                lstFavorites.Items.Remove(lstFavorites.SelectedItem);
            }
            else
            {
                // Manejar el caso en el que no se haya seleccionado ningún elemento para eliminar
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

                ArtistWindow artistWindow = new ArtistWindow(selectedArtistName, selectedArtistBio, textbox_user_local, dateTime_local, selectedArtistImage);
                artistWindow.Show();
                this.Hide();
            }
            else
            {
                // Manejar el caso en el que no se ha seleccionado ningún álbum
                MessageBox.Show("Por favor, selecciona un álbum para ver información del artista.", "Error al acceder a la página del artista");
            }
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow(textbox_user_local, dateTime_local);
            WindowManager.ContactWindowInstance = contactWindow;
            contactWindow.Show();
            this.Hide();
        }
    }
}
