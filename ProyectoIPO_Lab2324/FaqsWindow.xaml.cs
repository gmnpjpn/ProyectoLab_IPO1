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

        private string userName_local;
        private string dateTime_local;

        public FaqsWindow(String userName, String dateTime)
        {
            InitializeComponent();

            userName_local = userName;
            dateTime_local = dateTime;

            textblock_lastTime.Text = "Ultimo Acceso: " + dateTime;
            textblock_username.Text = userName_local;

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

        private void clickHome(object sender, RoutedEventArgs e)
        {
            if (WindowManager.LandingWindowInstance != null && !WindowManager.LandingWindowInstance.IsVisible)
            {
                WindowManager.LandingWindowInstance.Show();
            }
            this.Hide();

        }

        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
