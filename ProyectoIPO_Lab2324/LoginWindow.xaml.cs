﻿using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Windows;using System.Windows.Controls;using System.Windows.Data;using System.Windows.Documents;using System.Windows.Input;using System.Windows.Media;using System.Windows.Media.Imaging;using System.Windows.Shapes;namespace ProyectoIPO_Lab2324{    /// <summary>    /// Lógica de interacción para LoginWindow.xaml    /// </summary>    public partial class LoginWindow : Window    {        public LoginWindow()        {            InitializeComponent();            label_warning.Content = "";        }        private void combobox_language_SelectionChanged(object sender, SelectionChangedEventArgs e)        {        }        private void click_login(object sender, RoutedEventArgs e)        {            if ((!string.IsNullOrWhiteSpace(textbox_user.Text)) && (!string.IsNullOrWhiteSpace(passBox.Password)))            {                // Save the actual time and date                DateTime now = DateTime.Now;                TextBox dateTime = new TextBox();                dateTime.Text = now.ToString();                label_warning.Content = "";                LandingWindow landingWindow = new LandingWindow(textbox_user.Text, dateTime.Text);                landingWindow.Show();                this.Close();            }            else            {                label_warning.Content = "Credenciales Incorrectas";                label_warning.Visibility = Visibility.Visible;            }                    }        private void stopAtClose(object sender, System.ComponentModel.CancelEventArgs e)        {            System.Windows.Application.Current.Shutdown();        }    }}