using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para AddArtistWindow.xaml
    /// </summary>
    public partial class AddArtistWindow : Window
    {
        public string ArtisticName => txtArtisticName.Text;
        public string RealName => txtRealName.Text;
        public string Birthday => txtBirthday.Text;
        public string Description => txtDescription.Text;
        public string Genre => txtGenre.Text;
        public string ArtistInstagram => txtInstagram.Text;
        public string ArtistX_Twitter => txtX_Twitter.Text;
        public string Likes => txtLikes.Text;
        public Uri Image => new Uri(txtImage.Text, UriKind.RelativeOrAbsolute);


        public AddArtistWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Si todos los campos obligatorios están completos y el campo PVP tiene el formato correcto, establecemos DialogResult a true para confirmar el éxito de la operación
            DialogResult = true;
            Close();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtiene la ruta del archivo seleccionado y la coloca en el TextBox para la portada
                txtImage.Text = openFileDialog.FileName;
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
    }
}