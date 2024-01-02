﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ProyectoIPO_Lab2324
{
    public partial class LandingWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private static string musicPath = @"Resources/Music/HereComesTheSun.mp3"; // Ruta relativa al archivo mp3
        string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, musicPath);

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
            textblock_lastTime.Text = "Ultimo Acceso: " + GlobalData.CurrentDateTime;
        }

        private void setAlbumInitialContent()
        {
            // Load data
            LoadContentAlbumXML();

            // Indicate that the lstAlbumList items origin is albumList
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
                btnApplyChanges.Visibility = Visibility.Collapsed;
                btnChangeCover.Visibility = Visibility.Collapsed;
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
                btnApplyChanges.Visibility = Visibility.Visible;
                btnChangeCover.Visibility = Visibility.Visible;
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

                // Obtener la lista de canciones
                foreach (XmlNode songNode in node.SelectNodes("SongList/Song"))
                {
                    newAlbum.Songs.Add(songNode.InnerText);
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


        ////////// ALBUM LIST MANAGEMENT //////////
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

                // Actualizar la lista de artistas
                UpdateArtistsList();

                // ...
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un álbum para eliminar.", "Álbum no seleccionado");
            }
        }

        private void UpdateArtistsList()
        {

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
                else
                {
                    // Manejo de error si lstAlbumList es nula
                }
            }
        }



        private void btnBuyAlbum_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnApplyChanges_Click(object sender, RoutedEventArgs e)
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

        private void btnChangeCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;

                    // Asignar la nueva imagen al control Image (imgCover)
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath);
                    bitmap.EndInit();
                    imgCover.Source = bitmap;

                    // Actualizar la imagen en el objeto del álbum seleccionado
                    var selectedItem = lstAlbumList.SelectedItem as Album;
                    if (selectedItem != null)
                    {
                        // Convertir la ruta del archivo de imagen (imagePath) a un objeto Uri
                        Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                        // Actualizar la propiedad de la imagen en el objeto del álbum con el Uri generado
                        selectedItem.Cover = imageUri;
                    }

                    // Actualizar la vista de la lista para reflejar los cambios
                    lstAlbumList.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            string musicPath = "Resources/Music/HereComesTheSun.mp3";
            Uri musicUri = new Uri(musicPath, UriKind.Relative);

            var resourceInfo = Application.GetResourceStream(musicUri);
            if (resourceInfo == null)
            {
                MessageBox.Show("El archivo de música no se encontró en la ruta especificada.", "Error al reproducir", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            mediaPlayer.Open(musicUri);
            mediaPlayer.Play();
        }


        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Close();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Close();
        }
    }
}
