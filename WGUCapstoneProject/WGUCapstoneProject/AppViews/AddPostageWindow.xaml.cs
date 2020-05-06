using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WGUCapstoneProject.HelperClasses;
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for AddPostageWindow.xaml
    /// </summary>
    public partial class AddPostageWindow : Window
    {
        public ObservableCollection<Case> caseList { get; set; }
        public ObservableCollection<Recipient> recipients { get; set; }
        public ObservableCollection<PostageType> postageTypes { get; set; }

        public AddPostageWindow()
        {
            InitializeComponent();

            caseList = Case.CaseObservableCollection();
            recipients = Recipient.RecipientObservableCollection();
            postageTypes = PostageType.PostageTypeObservableCollection();
            DataContext = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow viewPostage = new ViewPostageWindow();
            Close();
            viewPostage.Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}