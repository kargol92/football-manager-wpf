﻿#pragma checksum "..\..\..\OknoOpcje.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A0F192F713716566E361E78AB852F80"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1022
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Football_Manager {
    
    
    /// <summary>
    /// OknoOpcje
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class OknoOpcje : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\OknoOpcje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button powrot;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\OknoOpcje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbMale;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\OknoOpcje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSrednie;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\OknoOpcje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbDuze;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Football Manager;component/oknoopcje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OknoOpcje.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\OknoOpcje.xaml"
            ((Football_Manager.OknoOpcje)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.powrot = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\OknoOpcje.xaml"
            this.powrot.Click += new System.Windows.RoutedEventHandler(this.powrot_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbMale = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\..\OknoOpcje.xaml"
            this.rbMale.Checked += new System.Windows.RoutedEventHandler(this.rbMale_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rbSrednie = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\..\OknoOpcje.xaml"
            this.rbSrednie.Checked += new System.Windows.RoutedEventHandler(this.rbSrednie_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbDuze = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\..\OknoOpcje.xaml"
            this.rbDuze.Checked += new System.Windows.RoutedEventHandler(this.rbDuze_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

