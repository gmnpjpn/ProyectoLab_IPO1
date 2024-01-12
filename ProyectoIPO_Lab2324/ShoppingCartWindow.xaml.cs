using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        public ShoppingCartWindow()
        {
            InitializeComponent();

            textblock_username.Text = GlobalData.Username;
            textblock_lastTime.Text = GlobalData.CurrentDateTime;

            listbox_shopping_cart.ItemsSource = GlobalData.ShoppingCartList;
            listbox_shopping_cart.DisplayMemberPath = "Name";

            // add();
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.LandingWindowInstance.Show();
            this.Hide();
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
            faqsWindow.Show();
            this.Hide();
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

        private void buy_button_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana para agregar un álbum
            PurchaseFormWindow purchaseFormWindow = new PurchaseFormWindow();
            // Mostrar la ventana como un diálogo modal
            bool? result = purchaseFormWindow.ShowDialog();

            GlobalData.ShoppingCartList.Clear();
            listbox_shopping_cart.ItemsSource = GlobalData.ShoppingCartList;
            listbox_shopping_cart.DisplayMemberPath = "Name";

            ShoppingCartWindow shoppingCart = new ShoppingCartWindow();
            WindowManager.ShoppingCartWindowInstance = shoppingCart;
            this.Hide();
            shoppingCart.Show();

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

        /* private void add()
         {
             double add = 0;
             Album album = new Album();
             for (int i = 0; i < GlobalData.ShoppingCartList.Count; i++)
             {
                 //album = listbox_shopping_cart.Items.GetItemAt(i);
                 add = Convert.ToDouble(listbox_shopping_cart.Items.GetItemAt(i));
                 add += add;
             }
             tbPvp.Text = add.ToString(Name);
         }
        */
    }
}