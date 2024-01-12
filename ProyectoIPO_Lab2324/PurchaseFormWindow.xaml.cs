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
    /// Lógica de interacción para PurchaseFormWindow.xaml
    /// </summary>
    public partial class PurchaseFormWindow : Window
    {
        public PurchaseFormWindow()
        {
            InitializeComponent();
        }


        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            // Verificar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtName_pf.Text) ||
                string.IsNullOrWhiteSpace(txtSurname_pf.Text) ||
                string.IsNullOrWhiteSpace(txtDate_pf.Text) ||
                string.IsNullOrWhiteSpace(txtEmail_pf.Text) ||
                string.IsNullOrWhiteSpace(txtCountry_pf.Text) ||
                string.IsNullOrWhiteSpace(txtProvince_pf.Text) ||
                string.IsNullOrWhiteSpace(txtPostal_pf.Text) ||
                string.IsNullOrWhiteSpace(txtCity_pf.Text) ||
                string.IsNullOrWhiteSpace(txtAddress_pf.Text) ||
                string.IsNullOrWhiteSpace(txtCardNumber_pf.Text) ||
                string.IsNullOrWhiteSpace(txtCardName_pf.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios (*) antes de intentar el pago.", "Campos obligatorios vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Detiene la ejecución si faltan campos obligatorios
            }

            MessageBox.Show("Pago realizado con éxito, disfrute de su compra", "Compra realizada");
            DialogResult = true;
            Close();
        }
    }
}