﻿using System;using System.Collections.Generic;using System.Globalization;using System.IO;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Windows;using System.Windows.Controls;using System.Windows.Data;using System.Windows.Documents;using System.Windows.Input;using System.Windows.Media;using System.Windows.Media.Imaging;using System.Windows.Threading;namespace ProyectoIPO_Lab2324{    /// <summary>    /// Lógica de interacción para LoginWindow.xaml    /// </summary>    public partial class LoginWindow : Window    {        public LoginWindow()        {            InitializeComponent();            label_warning.Visibility = Visibility.Hidden;            textbox_user.Text = "";            passBox.Password = "";            Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));        }        private void click_login(object sender, RoutedEventArgs e)        {            if ((!string.IsNullOrWhiteSpace(textbox_user.Text)) && (!string.IsNullOrWhiteSpace(passBox.Password)))            {                // Save the actual date and username                GlobalData.CurrentDateTime = DateTime.Now.ToString();                GlobalData.Username = textbox_user.Text;
                GlobalData.counterLanding++;
                LandingWindow landingWindow = new LandingWindow();
                WindowManager.LandingWindowInstance = landingWindow;
                textbox_user.Text = "";
                passBox.Password = "";

                WindowManager.LandingWindowInstance.Show();
                this.Hide();            }            else            {                label_warning.Visibility = Visibility.Visible;            }        }        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)        {            System.Windows.Application.Current.Shutdown();        }        private void combobox_language_SelectionChanged(object sender, SelectionChangedEventArgs e)        {            ComboBoxItem cbi = (ComboBoxItem)combobox_language.SelectedItem; string selectedText = cbi.Content.ToString();            if ((selectedText.Equals("ES") || selectedText.Equals("SP")) && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))            {                Resources.MergedDictionaries.Add(App.SelectCulture("es-ES"));            }            else if (selectedText.Equals("EN")            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))            {                Resources.MergedDictionaries.Add(App.SelectCulture("en-US"));            }        }

        private void button_about_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }
    }}