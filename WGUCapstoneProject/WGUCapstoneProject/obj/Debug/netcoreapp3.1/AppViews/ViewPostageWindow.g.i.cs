﻿#pragma checksum "..\..\..\..\AppViews\ViewPostageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED3745225D82983A485CD4CE9466F1CDBA66D21B"
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
using System.Windows.Forms.Integration;
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
using WGUCapstoneProject.AppViews;


namespace WGUCapstoneProject.AppViews {
    
    
    /// <summary>
    /// ViewPostageWindow
    /// </summary>
    public partial class ViewPostageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mailDataGrid;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModify;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetReport;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteOne;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteAll;
        
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
            System.Uri resourceLocater = new System.Uri("/WGUCapstoneProject;component/appviews/viewpostagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
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
            this.mailDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnModify = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
            this.btnModify.Click += new System.Windows.RoutedEventHandler(this.btnModify_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnGetReport = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
            this.btnGetReport.Click += new System.Windows.RoutedEventHandler(this.btnGetReport_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDeleteOne = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
            this.btnDeleteOne.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteOne_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDeleteAll = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\AppViews\ViewPostageWindow.xaml"
            this.btnDeleteAll.Click += new System.Windows.RoutedEventHandler(this.BtnDeleteAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

