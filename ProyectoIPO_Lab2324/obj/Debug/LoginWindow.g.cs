// Updated by XamlIntelliSenseFileGenerator 20/12/2023 18:15:18
#pragma checksum "..\..\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8A5C0D90455903E03BABB475232597B010CB04F47CCAE1EE82BA779D6A63AFB8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ProyectoIPO_Lab2324;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProyectoIPO_Lab2324
{


    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 9 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_login;

#line default
#line hidden


#line 39 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image wallpaper;

#line default
#line hidden


#line 40 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectangle_grey;

#line default
#line hidden


#line 41 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_tittle;

#line default
#line hidden


#line 42 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_user;

#line default
#line hidden


#line 43 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_user;

#line default
#line hidden


#line 44 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_password;

#line default
#line hidden


#line 45 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_login;

#line default
#line hidden


#line 46 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_language;

#line default
#line hidden


#line 50 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_warning;

#line default
#line hidden


#line 51 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Ad_image;

#line default
#line hidden


#line 52 "..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passBox;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProyectoIPO_Lab2324;component/loginwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\LoginWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.login_window = ((ProyectoIPO_Lab2324.LoginWindow)(target));

#line 8 "..\..\LoginWindow.xaml"
                    this.login_window.Closing += new System.ComponentModel.CancelEventHandler(this.stopAtClose);

#line default
#line hidden
                    return;
                case 2:
                    this.grid_login = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.wallpaper = ((System.Windows.Controls.Image)(target));
                    return;
                case 4:
                    this.rectangle_grey = ((System.Windows.Shapes.Rectangle)(target));
                    return;
                case 5:
                    this.label_tittle = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 6:
                    this.label_user = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.textbox_user = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.label_password = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 9:
                    this.button_login = ((System.Windows.Controls.Button)(target));

#line 45 "..\..\LoginWindow.xaml"
                    this.button_login.Click += new System.Windows.RoutedEventHandler(this.click_login);

#line default
#line hidden
                    return;
                case 10:
                    this.combobox_language = ((System.Windows.Controls.ComboBox)(target));

#line 46 "..\..\LoginWindow.xaml"
                    this.combobox_language.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combobox_language_SelectionChanged);

#line default
#line hidden
                    return;
                case 11:
                    this.label_warning = ((System.Windows.Controls.Label)(target));
                    return;
                case 12:
                    this.Ad_image = ((System.Windows.Controls.Image)(target));
                    return;
                case 13:
                    this.passBox = ((System.Windows.Controls.PasswordBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window login_window;
        internal System.Windows.Controls.ComboBoxItem cbItem1;
        internal System.Windows.Controls.ComboBoxItem cbItem2;
    }
}

