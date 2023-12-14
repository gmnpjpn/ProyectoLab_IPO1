using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoIPO_Lab2324
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoginWindow loginWindow = new LoginWindow();
            WindowManager.LoginWindowInstance = loginWindow;
        }

        public static ResourceDictionary SelectCulture(string idioma)
        {
            var resourceDictionary = new ResourceDictionary();
            switch (idioma)
            {
                case "en-US":
                    resourceDictionary.Source =
                    new Uri("/Resources/StringResources/StringResources.en-US.xaml", UriKind.Relative);
                    break;
                case "es-ES":
                    resourceDictionary.Source =
                    new Uri("/Resources/StringResources/StringResources.es-ES.xaml", UriKind.Relative);
                    break;
                default:
                    resourceDictionary.Source =
                    new Uri("/Resources/StringResources/StringResources.es-ES.xaml", UriKind.Relative);
                    break;
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);
            return resourceDictionary;
        }


    }
}








