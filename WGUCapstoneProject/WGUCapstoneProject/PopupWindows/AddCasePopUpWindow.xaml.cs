using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.PopupWindows
{
    /// <summary>
    /// Interaction logic for AddCasePopUpWindow.xaml
    /// </summary>
    public partial class AddCasePopUpWindow : Window
    {
        public AddCasePopUpWindow()
        {
            InitializeComponent();
            Case newCase = new Case();
            newCase.CaseName = txtNewCase.Text;

            Case.InsertCaseToDb(newCase.CaseName);
        }
    }
}
