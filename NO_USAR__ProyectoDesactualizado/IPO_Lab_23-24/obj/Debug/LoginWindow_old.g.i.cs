﻿#pragma checksum "..\..\LoginWindow_old.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D163C91FA3CEFBDE9716B980CDE946CD4CB8E2D2C33580BDA530D9B9AD6E3C26"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using IPO_Lab_23_24;
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


namespace IPO_Lab_23_24 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal IPO_Lab_23_24.MainWindow loginWindow;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridLogin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle wallpaper;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVinylShop;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUser;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxUser;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPass;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblWarning;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\LoginWindow_old.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassBoxPass;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IPO_Lab_23-24;component/loginwindow_old.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoginWindow_old.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginWindow = ((IPO_Lab_23_24.MainWindow)(target));
            return;
            case 2:
            this.GridLogin = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.wallpaper = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.lblVinylShop = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblUser = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtBoxUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lblPass = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\LoginWindow_old.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnAction_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lblWarning = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.PassBoxPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

