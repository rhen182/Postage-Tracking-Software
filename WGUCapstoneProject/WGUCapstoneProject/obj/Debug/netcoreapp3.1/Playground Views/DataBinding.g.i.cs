﻿#pragma checksum "..\..\..\..\Playground Views\DataBinding.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4036A644B5508372FC5646FEA76450C4E241BA0C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using WGUCapstoneProject.Playground_Views;


namespace WGUCapstoneProject.Playground_Views {
    
    
    /// <summary>
    /// DataBinding
    /// </summary>
    public partial class DataBinding : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\Playground Views\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtBtn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Playground Views\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValue1;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Playground Views\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValue2;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Playground Views\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblValue1;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Playground Views\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblValue2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WGUCapstoneProject;component/playground%20views/databinding.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Playground Views\DataBinding.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Playground Views\DataBinding.xaml"
            this.txtBtn.Click += new System.Windows.RoutedEventHandler(this.ClickUpdateThroughButton);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtValue1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtValue2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lblValue1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.lblValue2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

