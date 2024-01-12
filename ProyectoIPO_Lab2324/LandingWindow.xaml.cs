using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ProyectoIPO_Lab2324
{
    public partial class LandingWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public LandingWindow()
        {
            InitializeComponent();
            setUsername_LastDate();
            setAlbumInitialContent();
            setArtistInitialContent();
            changeView_UserAdmin();
        }

        private void setUsername_LastDate()
        {
            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = GlobalData.CurrentDateTime;
        }

        private void setAlbumInitialContent()
        {
            if (GlobalData.counterLanding == 1)
            {
                LoadContentAlbumXML();
            }

            lstAlbumList.ItemsSource = GlobalData.AlbumList;
        }

        private void setArtistInitialContent()
        {
            LoadContentArtistXML();
            lstArtistList.ItemsSource = GlobalData.ArtistList;
        }


        private void changeView_UserAdmin()
        {
            if (GlobalData.Username != "admin")
            {
                tbAlbumName.IsEnabled = false;
                tbAuthor.IsEnabled = false;
                spAlbumEdition.Visibility = Visibility.Collapsed;
                tbFormat.IsEnabled = false;
                tbGenre.IsEnabled = false;
                tbLaunchYear.IsEnabled = false;
                tbLikes.IsEnabled = false;
                tbPais.IsEnabled = false;
                tbPuntuacion.IsEnabled = false;
                tbPvp.IsEnabled = false;
                tbRecordLabel.IsEnabled = false;
                tbStock.IsEnabled = false;
                btnApplyChangesAlbum.Visibility = Visibility.Collapsed;
                btnChangeCover.Visibility = Visibility.Collapsed;

                tbDescription.IsEnabled = false;
                tbBirthday.IsEnabled = false;
                tbArtistGenre.IsEnabled = false;
                tbInstagram.IsEnabled = false;
                tbX_Twitter.IsEnabled = false;
                btnChangeArtistImage.Visibility = Visibility.Collapsed;
                btnApplyChangesArtist.Visibility = Visibility.Collapsed;
                btnAddArtist.Visibility = Visibility.Collapsed;
                btnDeleteArtist.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbAlbumName.IsEnabled = true;
                tbAuthor.IsEnabled = true;
                spAlbumEdition.Visibility = Visibility.Visible;
                tbFormat.IsEnabled = true;
                tbGenre.IsEnabled = true;
                tbLaunchYear.IsEnabled = true;
                tbLikes.IsEnabled = true;
                tbPais.IsEnabled = true;
                tbPuntuacion.IsEnabled = true;
                tbPvp.IsEnabled = true;
                tbRecordLabel.IsEnabled = true;
                tbStock.IsEnabled = true;
                btnApplyChangesAlbum.Visibility = Visibility.Visible;
                btnChangeCover.Visibility = Visibility.Visible;
                btnShoppingCart.Visibility = Visibility.Collapsed;
                btnChangeArtistImage.Visibility = Visibility.Visible;
                btnApplyChangesArtist.Visibility = Visibility.Visible;
                btnAddArtist.Visibility = Visibility.Visible;
                btnDeleteArtist.Visibility = Visibility.Visible;
            }
        }


        private void LoadContentAlbumXML()
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
                newAlbum.previewPath = node.Attributes["previewPath"].Value;

                // Obtener la lista de canciones
                foreach (XmlNode songNode in node.SelectNodes("SongsA/Song"))
                {
                    newAlbum.SongsA.Add(songNode.InnerText);
                }

                // Obtener la lista de canciones
                foreach (XmlNode songNode in node.SelectNodes("SongsB/Song"))
                {
                    newAlbum.SongsB.Add(songNode.InnerText);
                }
                GlobalData.AlbumList.Add(newAlbum);
            }
        }

        private void LoadContentArtistXML()
        {
            XmlDocument doc = new XmlDocument();
            var file = Application.GetResourceStream(new Uri("/Resources/Data/Artists.xml", UriKind.Relative));
            doc.Load(file.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var newArtist = new Artist();

                newArtist.ArtisticName = node.Attributes["ArtisticName"].Value;
                newArtist.RealName = node.Attributes["RealName"].Value;
                newArtist.Birthday = node.Attributes["Birthday"].Value;
                newArtist.Description = node.Attributes["Description"].Value;
                newArtist.Genre = node.Attributes["Genre"].Value;
                newArtist.Instagram = node.Attributes["Instagram"].Value;
                newArtist.X_Twitter = node.Attributes["X_Twitter"].Value;
                newArtist.Likes = node.Attributes["Likes"].Value;
                newArtist.ArtistImage = new Uri(node.Attributes["ArtistImage"].Value, UriKind.Relative);

                // Obtener la lista de albumes
                foreach (XmlNode albumNode in node.SelectNodes("AlbumList/Album"))
                {
                    newArtist.AlbumList.Add(albumNode.InnerText);
                }

                // Obtener la lista de componentes de un grupo
                foreach (XmlNode groupComponentNode in node.SelectNodes("GroupComponents/GroupComponent"))
                {
                    newArtist.GroupComponents.Add(groupComponentNode.InnerText);
                }

                GlobalData.ArtistList.Add(newArtist);
            }
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
                bool existsInFavorites = GlobalData.FavoritesList.Any(a => a.Name == selectedAlbum.Name && a.Author == selectedAlbum.Author);

                if (!existsInFavorites)
                {
                    GlobalData.FavoritesList.Add(selectedAlbum);
                    MessageBox.Show("Añadido correctamente a la lista de favoritos.", "Añadido a favoritos");
                }
                else
                {
                    MessageBox.Show("El álbum ya está en la lista de favoritos.", "Error al añadir a favoritos");
                }
            }
        }


        private void imgCover_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Album selectedAlbum = lstAlbumList.SelectedItem as Album;

            if (selectedAlbum != null)
            {
                // Cambiar a la pestaña "Artistas"
                // Supongamos que tu control TabControl se llama "tabControl"
                tcLanding.SelectedIndex = 1; // Cambiar al índice correspondiente a la pestaña "Artistas"

                // Obtener el artista que coincide con el Author del álbum seleccionado
                var matchingArtist = lstArtistList.Items.OfType<Artist>().FirstOrDefault(artist => artist.ArtisticName == selectedAlbum.Author);

                if (matchingArtist != null)
                {
                    // Seleccionar el artista correspondiente en lstArtistList
                    lstArtistList.SelectedItem = matchingArtist;
                }
                else
                {
                    MessageBox.Show("No se encontró el artista correspondiente al álbum seleccionado.", "Artista no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un álbum para ver información del artista.", "Error al acceder a la página del artista");
            }
        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            Album selectedAlbum = lstAlbumList.SelectedItem as Album;

            if (selectedAlbum != null)
            {
                // Eliminar el álbum seleccionado de la lista de álbumes
                GlobalData.AlbumList.Remove(selectedAlbum);

                // Actualizar la lista de álbumes
                lstAlbumList.ItemsSource = null;
                lstAlbumList.ItemsSource = GlobalData.AlbumList;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un álbum para eliminar.", "Álbum no seleccionado");
            }
        }

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana para agregar un álbum
            AddAlbumWindow addAlbumWindow = new AddAlbumWindow();

            // Mostrar la ventana como un diálogo modal
            bool? result = addAlbumWindow.ShowDialog();

            if (result == true)
            {
                // Obtener los datos ingresados por el usuario desde la ventana AddAlbumWindow
                string albumName = addAlbumWindow.AlbumName;
                string artistName = addAlbumWindow.Author;
                string launchYear = addAlbumWindow.LaunchYear;
                string genre = addAlbumWindow.Genre;
                string recordLabel = addAlbumWindow.RecordLabel;
                string format = addAlbumWindow.Format;
                string country = addAlbumWindow.Country;
                string likes = addAlbumWindow.Likes;
                string puntuation = addAlbumWindow.Puntuation;
                string pvp = addAlbumWindow.Pvp;
                string stock = addAlbumWindow.Stock;
                Uri cover = addAlbumWindow.Cover;

                // Aquí puedes crear un nuevo objeto de álbum con los datos obtenidos
                Album newAlbum = new Album
                {
                    Name = albumName,
                    Author = artistName,
                    LaunchYear = launchYear,
                    Genre = genre,
                    RecordLabel = recordLabel,
                    Format = format,
                    Country = country,
                    Likes = likes,
                    Puntuation = puntuation,
                    Pvp = pvp,
                    Stock = stock,
                    Cover = cover
                };

                // Agregar el nuevo álbum a la lista global lstAlbumList
                if (lstAlbumList != null) // Verificar si la lista no es nula
                {
                    GlobalData.AlbumList.Add(newAlbum);
                    lstAlbumList.Items.Refresh();
                }
            }
        }


        private void btnBuyAlbum_Click(object sender, RoutedEventArgs e)
        {

            if (lstAlbumList.SelectedItem != null && lstAlbumList.SelectedItem is Album selectedAlbum)
            {

                bool existsInShoppingCart = GlobalData.ShoppingCartList.Any(a =>
                    a.Name == selectedAlbum.Name &&
                    a.Author == selectedAlbum.Author
                );

                if (!existsInShoppingCart)
                {
                    GlobalData.ShoppingCartList.Add(selectedAlbum);
                    MessageBox.Show("Añadido correctamente al carrito de compra.", "Añadido al carrito");

                }
                else
                {
                    MessageBox.Show("El álbum ya había sido añadido al carrito.", "Accion no posible");
                }
            }
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnApplyChangesAlbum_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lstAlbumList.SelectedItem as Album;

            if (selectedItem != null)
            {
                // Actualizar cada propiedad del ítem seleccionado con los valores de los TextBox
                selectedItem.Name = tbAlbumName.Text;
                selectedItem.Author = tbAuthor.Text;
                selectedItem.Pvp = tbPvp.Text;
                selectedItem.LaunchYear = tbLaunchYear.Text;
                selectedItem.Puntuation = tbPuntuacion.Text;
                selectedItem.Genre = tbGenre.Text;
                selectedItem.RecordLabel = tbRecordLabel.Text;
                selectedItem.Format = tbFormat.Text;
                selectedItem.Country = tbPais.Text;
                selectedItem.Likes = tbLikes.Text;
                selectedItem.Stock = tbStock.Text;


                // Actualizar la vista de la lista para reflejar los cambios
                lstAlbumList.Items.Refresh();

                // Mostrar un mensaje indicando que los cambios se han aplicado correctamente
                MessageBox.Show("Los cambios se han aplicado correctamente.", "Cambios Aplicados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnApplyChangesArtist_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lstArtistList.SelectedItem as Artist;

            if (selectedItem != null)
            {
                // Actualizar cada propiedad del ítem seleccionado con los valores de los TextBox
                selectedItem.ArtisticName = tbArtisticName.Text;
                selectedItem.RealName = tbRealName.Text;
                selectedItem.Birthday = tbBirthday.Text;
                selectedItem.Description = tbDescription.Text;
                selectedItem.Genre = tbArtistGenre.Text;
                selectedItem.Instagram = tbInstagram.Text;
                selectedItem.X_Twitter = tbX_Twitter.Text;
                selectedItem.Likes = tbLikes.Text;

                // Actualizar la vista de la lista para reflejar los cambios
                lstArtistList.Items.Refresh();

                // Mostrar un mensaje indicando que los cambios se han aplicado correctamente
                MessageBox.Show("Los cambios se han aplicado correctamente.", "Cambios Aplicados", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void btnChangeCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtener la ruta del archivo seleccionado
                string imagePath = openFileDialog.FileName;

                // Convertir la cadena de la ruta a un objeto Uri
                Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                // Actualizar la carátula del objeto Album
                var selectedAlbum = lstAlbumList.SelectedItem as Album;
                if (selectedAlbum != null)
                {
                    selectedAlbum.Cover = imageUri;
                    lstAlbumList.Items.Refresh();
                }

            }
        }



        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Album selectedAlbum = (Album)lstAlbumList.SelectedItem;

            if (selectedAlbum != null)
            {
                if (!string.IsNullOrEmpty(selectedAlbum.previewPath))
                {
                    Uri uri = new Uri(selectedAlbum.previewPath, UriKind.Relative);
                    mediaPlayer.Open(uri);
                    mediaPlayer.Play();
                }
                else
                {
                    MessageBox.Show("La canción de vista previa no está disponible para este álbum.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un álbum primero.");
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Close();
        }

        private void btnChangeArtistImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtener la ruta del archivo seleccionado
                string imagePath = openFileDialog.FileName;

                // Convertir la cadena de la ruta a un objeto Uri
                Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);


                // Actualizar la carátula del objeto Album
                var selectedArtist = lstArtistList.SelectedItem as Artist;
                if (selectedArtist != null)
                {
                    selectedArtist.ArtistImage = imageUri;
                    lstArtistList.Items.Refresh();
                }
            }
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

        private void btnAddArtist_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana para agregar un álbum
            AddArtistWindow addArtistWindow = new AddArtistWindow();

            // Mostrar la ventana como un diálogo modal
            bool? result = addArtistWindow.ShowDialog();

            if (result == true)
            {
                // Obtener los datos ingresados por el usuario desde la ventana AddAlbumWindow
                string artisticName = addArtistWindow.ArtisticName;
                string realName = addArtistWindow.RealName;
                string birthday = addArtistWindow.Birthday;
                string description = addArtistWindow.Description;
                string genre = addArtistWindow.Genre;
                string artistInstagram = addArtistWindow.ArtistInstagram;
                string artistX_Twitter = addArtistWindow.ArtistX_Twitter;
                string likes = addArtistWindow.Likes;
                Uri image = addArtistWindow.Image;

                // Aquí puedes crear un nuevo objeto de álbum con los datos obtenidos
                Artist newArtist = new Artist
                {
                    ArtisticName = artisticName,
                    RealName = realName,
                    Birthday = birthday,
                    Description = description,
                    Genre = genre,
                    ArtistImage = image,
                    Instagram = artistInstagram,
                    X_Twitter = artistX_Twitter,
                    Likes = likes
                };

                // Agregar el nuevo álbum a la lista global lstAlbumList
                if (lstAlbumList != null) // Verificar si la lista no es nula
                {
                    GlobalData.ArtistList.Add(newArtist);
                    lstArtistList.Items.Refresh();
                }
            }
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e)
        {
            Artist selectedArtist = lstArtistList.SelectedItem as Artist;

            if (selectedArtist != null)
            {
                // Eliminar el artista seleccionado de la lista de álbumes
                GlobalData.ArtistList.Remove(selectedArtist);

                // Actualizar la lista de artistas
                lstArtistList.ItemsSource = null;
                lstArtistList.ItemsSource = GlobalData.ArtistList;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artista para eliminar.", "Álbum no seleccionado");
            }
        }
    }
}
