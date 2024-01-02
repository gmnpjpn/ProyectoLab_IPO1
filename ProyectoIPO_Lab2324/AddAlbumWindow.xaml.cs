using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;



namespace ProyectoIPO_Lab2324
{
    /// <summary>
    /// Lógica de interacción para AddAlbumWindow.xaml
    /// </summary>
    public partial class AddAlbumWindow : Window
    {
        public string AlbumName => txtAlbumName.Text;
        public string Author => txtArtistName.Text;
        public string LaunchYear => txtReleaseYear.Text;
        public string Genre => txtGenre.Text;
        public string RecordLabel => txtRecordLabel.Text;
        public string Format => txtFormat.Text;
        public string Country => txtCountry.Text;
        public string Likes => txtLikes.Text;
        public string Puntuation => txtPuntuation.Text;
        public string Pvp => txtPvp.Text;
        public string Stock => txtStock.Text;
        public Uri Cover => new Uri(txtCover.Text, UriKind.RelativeOrAbsolute);

        public AddAlbumWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Verificar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtAlbumName.Text) ||
                string.IsNullOrWhiteSpace(txtArtistName.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text) ||
                string.IsNullOrWhiteSpace(txtFormat.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtCover.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios (*) antes de agregar.", "Campos obligatorios vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Detiene la ejecución si faltan campos obligatorios
            }

            // Verificar campo PVP con símbolo € al final, puntos, comas y números
            string pvpText = txtPvp.Text.Trim();
            Regex regex = new Regex(@"^[0-9,.]+€$");
            if (string.IsNullOrWhiteSpace(pvpText) || !regex.IsMatch(pvpText))
            {
                MessageBox.Show("El campo PVP debe contener números, puntos o comas seguidos del símbolo € al final.", "Formato PVP incorrecto", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Detiene la ejecución si el formato del campo PVP es incorrecto
            }

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
                txtCover.Text = openFileDialog.FileName;
            }
        }

    }


}
