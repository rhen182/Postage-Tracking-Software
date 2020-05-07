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
        public Organization newOrganization = new Organization("New Organization");

        Mail mail = new Mail();
        Case legalCase = new Case();
        PostageType postageType = new PostageType();
        Recipient recipient = new Recipient();
        Organization organization = new Organization();

        public AddPostageWindow()
        {
            InitializeComponent();

            if (Case.CaseObservableCollection() == null)
            {
                cmbCase.Visibility = Visibility.Collapsed;
                txtNewCaseName.Visibility = Visibility.Visible;
            }
            else
            {
                caseList = Case.CaseObservableCollection();
                caseList.Add(newCase);
                caseList.Move(caseList.IndexOf(caseList[caseList.Count - 1]), caseList.IndexOf(caseList[0]));
            }

            if (PostageType.PostageTypeObservableCollection() == null)
            {
                cmbPostageType.Visibility = Visibility.Collapsed;
                txtNewPostageTypeName.Visibility = Visibility.Visible;
            }
            else
            {
                postageTypes = PostageType.PostageTypeObservableCollection();
                postageTypes.Add(newPostageType);
                postageTypes.Move(postageTypes.IndexOf(postageTypes[postageTypes.Count - 1]), postageTypes.IndexOf(postageTypes[0]));
            }

            if (Organization.OrganizationObservableCollection() == null)
            {
                cmbOrganization.Visibility = Visibility.Collapsed;
                txtNewOrganizationName.Visibility = Visibility.Visible;
            }
            else
            {
                organizations = Organization.OrganizationObservableCollection();
                organizations.Add(newOrganization);
                organizations.Move(organizations.IndexOf(organizations[organizations.Count - 1]), organizations.IndexOf(organizations[0]));
            }
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
            if (String.IsNullOrEmpty(txtNewCaseName.Text))
            {
                legalCase = (Case)cmbCase.SelectedItem;
                mail.CaseId = legalCase.CaseId;
            }
            else
            {
                legalCase.CaseName = txtNewCaseName.Text;
                Case.InsertCaseToDb(legalCase.CaseName);
                mail.CaseId = legalCase.CaseId;
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
                mail.PostageTypeId = postageType.PostageTypeId;
            }
            if (String.IsNullOrEmpty(txtNewOrganizationName.Text))
            {
                organization = (Organization)cmbOrganization.SelectedItem;
                Organization.InsertOrganizationToDb(organization.OrganizationName, organization.AddressLine1, organization.AddressLine2, organization.City, organization.State, organization.Zip);
                mail.OrganizationId = organization.OrganizationId;
            }
            else
            {
                organization.OrganizationName = txtNewOrganizationName.Text;
                Organization.InsertOrganizationToDb(organization.OrganizationName, organization.AddressLine1, organization.AddressLine2, organization.City, organization.State, organization.Zip);
                mail.OrganizationId = organization.OrganizationId;
            }

            recipient.FirstName = txtNewRecipientFirstName.Text;
            recipient.LastName = txtNewRecipientLastName.Text;
            Recipient.InsertRecipientToDb(recipient.FirstName, recipient.LastName);
            
            mail.DateSent = DateTime.Now;
            mail.Cost = Convert.ToDouble(txtCost.Text);
            
            Mail.InsertPostageToDb(mail.DateSent, mail.CaseId, mail.Cost, mail.PostageTypeId, mail.OrganizationId, mail.RecipientId);

        }

        private void cmbCase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbCase.SelectedItem == newCase)
            {
                cmbCase.Visibility = Visibility.Collapsed;
                txtNewCaseName.Visibility = Visibility.Visible;
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

        private void cmbOrganization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Organization organization = new Organization();

            if (cmbOrganization.SelectedItem == newOrganization)
            {
                cmbOrganization.Visibility = Visibility.Collapsed;
                txtNewOrganizationName.Visibility = Visibility.Visible;
            }
            else
            {
                organization = (Organization)cmbOrganization.SelectedItem;
                txtAddress1.Text = organization.AddressLine1;
                txtAddress2.Text = organization.AddressLine2;
                txtCity.Text = organization.City;
                txtState.Text = organization.State;
                txtZip.Text = organization.Zip;
            }
        }
    }
}