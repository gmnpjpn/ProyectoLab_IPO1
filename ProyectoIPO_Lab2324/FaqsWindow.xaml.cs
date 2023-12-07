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
    /// Lógica de interacción para FaqsWindow.xaml
    /// </summary>
    public partial class FaqsWindow : Window
    {

        List<Faq> faqList;

        private string usernameLocal;
        private string datetimeLocal;

        public FaqsWindow(String username, String datetime)
        {
            InitializeComponent();

            usernameLocal = username;
            datetimeLocal = datetime;

            textblock_lastTime.Text = "Ultimo Acceso: " + datetimeLocal;
            textblock_username.Text = usernameLocal;

            // Create faq list
            faqList = new List<Faq>();
            // Load data
            LoadContentXML();

            // Indicate that the lstFaqList items origin is faqList
            lstFaqList.ItemsSource = faqList;
        }
        private void LoadContentXML()
        {
            // Load test data
            XmlDocument doc = new XmlDocument();
            var file = Application.GetResourceStream(new Uri("/Resources/Data/Faqs.xml", UriKind.Relative));
            doc.Load(file.Stream);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var newFaq = new Faq("", "");

                newFaq.Title = node.Attributes["Title"].Value;
                newFaq.Content = node.Attributes["Content"].Value;

                faqList.Add(newFaq);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LandingWindowInstance.Show();
            this.Hide();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LoginWindowInstance.Show();
            this.Hide();
        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
