using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ObservableCollection<Organization> organizations { get; set; }
        public Case newCase = new Case("New Case");
        public Recipient newRecipient = new Recipient("New", "Recipient");
        public PostageType newPostageType = new PostageType("New Postage Type");

        Mail mail = new Mail();
        Case legalCase = new Case();
        PostageType postageType = new PostageType();
        Address address = new Address();
        Recipient recipient = new Recipient();
        Organization organization = new Organization();

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


            mail.DateSent = DateTime.Now;

            if (String.IsNullOrEmpty(txtNewCaseName.Text))
            {
                legalCase = (Case)cmbCase.SelectedItem;
                mail.CaseId = legalCase.CaseId;
            }
            else
            {
                legalCase.CaseName = txtNewCaseName.Text;
                Case.InsertCaseToDb(legalCase.CaseName);
            }

            if (String.IsNullOrEmpty(txtNewPostageTypeName.Text))
            {
                postageType = (PostageType)cmbPostageType.SelectedItem;
                mail.PostageTypeId = postageType.PostageTypeId;
            }
            else
            {
                postageType.PostageTypeName = txtNewPostageTypeName.Text;
                PostageType.InsertPostageTypeToDb(postageType.PostageTypeName);
            }

            mail.RecipientId = recipient.RecipientId;




            address.AddressLine1 = txtAddress1.Text;
            address.AddressLine2 = txtAddress2.Text;
            address.City = txtCity.Text;
            address.State = txtState.Text;
            address.ZipCode = txtZipCode.Text;

            Address.InsertAddressToDb(address.AddressLine1, address.AddressLine2, address.City, address.State, address.ZipCode);
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
            Recipient recipient = new Recipient();
            Mail mail = new Mail();

            if (cmbRecipient.SelectedItem == newRecipient)
            {
                cmbRecipient.Visibility = Visibility.Collapsed;
                txtNewRecipientFirstName.Visibility = Visibility.Visible;
                txtNewRecipientLastName.Visibility = Visibility.Visible;
            }
            else
            {
                recipient.FirstName = txtNewRecipientFirstName.Text;
                recipient.LastName = txtNewRecipientLastName.Text;

                recipient = (Recipient)cmbRecipient.SelectedItem;
                txtOrganization.Text = Organization.RecipientObservableCollection().ToList().Find(x => recipient.OrganizationId == x.OrganizationId).OrganizationName;
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