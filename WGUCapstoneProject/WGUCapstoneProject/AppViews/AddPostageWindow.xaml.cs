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
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for AddPostageWindow.xaml
    /// </summary>
    public partial class AddPostageWindow : Window
    {
        public AddPostageWindow()
        {
            InitializeComponent();
            ObservableCollection<Recipient> recipientList = new ObservableCollection<Recipient>();




            cmbRecipient.ItemsSource = recipientList;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow viewPostage = new ViewPostageWindow();
            Close();
            viewPostage.Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {




            Case legalCase = new Case();

            Recipient recipient = new Recipient();

            Organization organization = new Organization();

            PostageType postageType = new PostageType();

            Mail mail = new Mail();
        }


        private void cmbRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


