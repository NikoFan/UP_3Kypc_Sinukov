﻿#pragma checksum "..\..\CreateApplication.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EF6E3C506F4790678B02F390D13B7E9AE0352831202F0CF0A2879CFDDA28A6A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SinukovUP;
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


namespace SinukovUP {
    
    
    /// <summary>
    /// CreateApplication
    /// </summary>
    public partial class CreateApplication : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\CreateApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock dateInformation;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CreateApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TechTypeInput;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CreateApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TechModelInput;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\CreateApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TechDInput;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CreateApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SettingsPlace;
        
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
            System.Uri resourceLocater = new System.Uri("/SinukovUP;component/createapplication.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateApplication.xaml"
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
            
            #line 20 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.HideSettingsPlace);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dateInformation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TechTypeInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TechModelInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TechDInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 48 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateNewApplication);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SettingsPlace = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            
            #line 59 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenMyApps);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 64 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Account);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 68 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseApp);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 72 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HideSettingsPlace);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 79 "..\..\CreateApplication.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenSettingsPlace);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

