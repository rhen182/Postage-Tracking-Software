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
using WGUCapstoneProject.PopupWindows;

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
        public Case newCase = new Case("New Case");
        public Recipient newRecipient = new Recipient("New", "Recipient");
        public PostageType newPostageType = new PostageType("New Postage Type");
        public AddPostageWindow()
        {
            InitializeComponent();

            caseList = Case.CaseObservableCollection();
            caseList.Add(newCase);
            caseList.Move(caseList.IndexOf(caseList[caseList.Count - 1]), caseList.IndexOf(caseList[0]));


            recipients = Recipient.RecipientObservableCollection();
            recipients.Add(newRecipient);
            recipients.Move(recipients.IndexOf(recipients[recipients.Count - 1]), recipients.IndexOf(recipients[0]));


            postageTypes = PostageType.PostageTypeObservableCollection();
            postageTypes.Add(newPostageType);
            postageTypes.Move(postageTypes.IndexOf(postageTypes[postageTypes.Count - 1]), postageTypes.IndexOf(postageTypes[0]));


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

        private void cmbCase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbCase.SelectedItem == newCase)
            {
                cmbCase.Visibility = Visibility.Collapsed;
                txtNewCaseName.Visibility = Visibility.Visible;
            }

        }

        private void cmbRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRecipient.SelectedItem == newRecipient)
            {
                cmbRecipient.Visibility = Visibility.Collapsed;
                txtNewRecipientFirstName.Visibility = Visibility.Visible;
                txtNewRecipientLastName.Visibility = Visibility.Visible;
            }
        }

        private void cmbPostageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPostageType.SelectedItem == newPostageType)
            {
                cmbPostageType.Visibility = Visibility.Collapsed;
                txtNewPostageTypeName.Visibility = Visibility.Visible;
            }
        }
    }
}