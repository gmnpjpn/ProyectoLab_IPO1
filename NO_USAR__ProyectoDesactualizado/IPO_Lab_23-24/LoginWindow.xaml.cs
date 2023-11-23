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
using System.Windows.Threading;
using Microsoft.Win32;

namespace IPO_Lab_23_24
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
<<<<<<< HEAD:IPO_Lab_23-24/LoginWindow.xaml.cs
        private OpenFileDialog dlg_archivo;
        private List<String> ruta_archivos;
        private int ident;
        public MainWindow()
=======
        public LoginWindow()
>>>>>>> main:NO_USAR__ProyectoDesactualizado/IPO_Lab_23-24/LoginWindow.xaml.cs
        {
            InitializeComponent();

            this.dlg_archivo = new OpenFileDialog();
            this.dlg_archivo.Multiselect = true;
            this.dlg_archivo.Filter = "Imagenes JPG (*.jpg)|*jpg|Imagenes PNG (*.png)|*png|Imagenes BMP (*.bmp)|*bmp";

            this.ruta_archivos = null;
            this.ident = 0;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            DateTime actualDateTime = DateTime.Now;
            string dateTimeFormatted = actualDateTime.ToString("dd-MM-yyyy HH:mm");

            string userName = txtBoxUser.Text.ToString();
            string userPass = PassBoxPass.Password.ToString();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                lblWarning.Content = "Nombre de usuario y/o contraseña no válidos";
            }
            else
            {
                lblWarning.Content = "";
                if (userName == "admin" && userPass == "admin")
                {
                    LandingPage landingPage_Admin = new LandingPage(userName, dateTimeFormatted);
                    this.Close();
                    landingPage_Admin.Show();

                }
                else
                {
                    LandingPage landingPage_User = new LandingPage(userName, dateTimeFormatted);
                    this.Close();
                    landingPage_User.Show();
                }

            }
        }

        private void cargar_imagen(string path)
        {

            BitmapImage bitmapImage = new BitmapImage();//crear un objeto bitmapImage
            bitmapImage.BeginInit();//inicializar bitmapImage
            bitmapImage.UriSource = new Uri(path);//cargar primera imagen
            bitmapImage.EndInit();//Fin inicializacion bitmapImage
            this.contenedor_imagen.Source = bitmapImage; //mostrar imagen
        }
        private void btn_cargar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dlg_archivo.ShowDialog() == true)
            {//si se selecciono una imagen
                //convertir el arreglo resultante en un lista
                this.ruta_archivos = this.dlg_archivo.FileNames.OfType<String>().ToList();
                cargar_imagen(this.ruta_archivos[0]);
                // Console.WriteLine(ruta_archivos[0].Replace(@"\",@"\\"));//cambiar \ por \\ del path
                /*BitmapImage bitmapImage = new BitmapImage();//crear un objeto bitmapImage
                bitmapImage.BeginInit();//inicializar bitmapImage
                bitmapImage.UriSource = new Uri(ruta_archivos[0]);//cargar primera imagen
                bitmapImage.EndInit();//Fin inicializacion bitmapImage
                this.contenedor_imagen.Source = bitmapImage; //mostrar imagen*/
                // this.contenedor_imagen.Source = new BitmapImage(new Uri(@"C:\Users\rock_\OneDrive\Imágenes\per.jpg", UriKind.Relative));
            }
        }

        private void btn_atras_Click(object sender, RoutedEventArgs e)
        {
            if (this.ruta_archivos != null)//validacion
            {
                this.ident = this.ident == 0 ? this.ruta_archivos.Count - 1 : this.ident - 1;
                cargar_imagen(this.ruta_archivos[ident]);
            }
        }

        internal void btn_siguente_Click(object sender, RoutedEventArgs e)
        {
            if (this.ruta_archivos != null)//validacion
            {
                this.ident = this.ident == this.ruta_archivos.Count - 1 ? 0 : this.ident + 1;
                cargar_imagen(this.ruta_archivos[ident]);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.ruta_archivos != null)//validacion
            {
                this.ident = this.ident == this.ruta_archivos.Count - 1 ? 0 : this.ident + 1;
                cargar_imagen(this.ruta_archivos[ident]);
            }
        }
    }
}
