// Updated by XamlIntelliSenseFileGenerator 5/8/2020 4:30:06 AM
#pragma checksum "..\..\..\..\AppViews\ModifyPostageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F4A7B4A92FD2DD58EBEF145B9D7B6878FEB76816"
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
using WGUCapstoneProject.AppViews;


namespace WGUCapstoneProject.AppViews
{


    /// <summary>
    /// ModifyPostageWindow
    /// </summary>
    public partial class ModifyPostageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WGUCapstoneProject;component/appviews/modifypostagewindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\AppViews\ModifyPostageWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox cmbCase;
        internal System.Windows.Controls.TextBox txtNewCaseName;
        internal System.Windows.Controls.TextBox txtAddress1;
        internal System.Windows.Controls.TextBox txtNewRecipientFirstName;
        internal System.Windows.Controls.TextBox txtNewRecipientLastName;
        internal System.Windows.Controls.TextBox txtAddress2;
        internal System.Windows.Controls.ComboBox cmbOrganization;
        internal System.Windows.Controls.TextBox txtNewOrganizationName;
        internal System.Windows.Controls.TextBox txtCity;
        internal System.Windows.Controls.TextBox txtCost;
        internal System.Windows.Controls.TextBox txtState;
        internal System.Windows.Controls.ComboBox cmbPostageType;
        internal System.Windows.Controls.TextBox txtNewPostageTypeName;
        internal System.Windows.Controls.TextBox txtZip;
        internal System.Windows.Controls.Button btnCancel;
        internal System.Windows.Controls.Button btnAdd;
    }
}

