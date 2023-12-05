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

        private string textbox_user_local;
        private string dateTime_local;

        public ContactWindow(String textbox_user, String dateTime)
        {
            InitializeComponent();
            textbox_user_local = textbox_user;
            dateTime_local = dateTime;
        }

        private void StopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            if (WindowManager.LandingWindowInstance != null && !WindowManager.LandingWindowInstance.IsVisible)
            {
                WindowManager.LandingWindowInstance.Show();
            }
            this.Hide();
        }

        private void inicioArrastrar(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject((Image)sender);
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void añadirObjeto(object sender, DragEventArgs e)
        {
            Image imgDragged = (Image)e.Data.GetData(typeof(Image));
            Image imgToUpdate = (Image)e.OriginalSource;
            imgToUpdate.Source = imgDragged.Source;
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¡Sugerencia enviada!", "Envío de sugerencia");
        }
    }
}
