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
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for ModifyPostageWindow.xaml
    /// </summary>
    public partial class ModifyPostageWindow : Window
    {
        public ObservableCollection<Case> caseList { get; set; }
        public ObservableCollection<Recipient> recipients { get; set; }
        public ObservableCollection<PostageType> postageTypes { get; set; }
        public ObservableCollection<Organization> organizations { get; set; }
        public ObservableCollection<Mail> mails { get; set; }

        public Case newCase = new Case("New Case");
        public Recipient newRecipient = new Recipient("New", "Recipient");
        public PostageType newPostageType = new PostageType("New Postage Type");
        public Organization newOrganization = new Organization("New Organization");

        Mail mail = new Mail();
        Case legalCase = new Case();
        PostageType postageType = new PostageType();
        Recipient recipient = new Recipient();
        Organization organization = new Organization();

        int counter = 0;

        public ModifyPostageWindow(int caseIndex, int orgIndex, int postageTypeIndex, Mail mailToTransfer, Case selectedCase, Organization selectedOrganization, PostageType selectedPostageType, Recipient selectedRecipient)
        {
            InitializeComponent();

            caseList = Case.CaseObservableCollection();
            postageTypes = PostageType.PostageTypeObservableCollection();
            recipients = Recipient.RecipientObservableCollection();
            organizations = Organization.OrganizationObservableCollection();
            mails = Mail.MailObservableCollection();

            mail = mailToTransfer;
            legalCase = selectedCase;
            postageType = selectedPostageType;
            recipient = selectedRecipient;
            organization = selectedOrganization;

            cmbCase.SelectedIndex = caseIndex;
            cmbOrganization.SelectedIndex = orgIndex;
            cmbPostageType.SelectedIndex = postageTypeIndex;

            //--------------------------------------------------------------------


            caseList = Case.CaseObservableCollection();
            caseList.Add(newCase);
            //caseList.Move(caseList.IndexOf(caseList[caseList.Count]), caseList.IndexOf(caseList[0]));

            postageTypes = PostageType.PostageTypeObservableCollection();
            postageTypes.Add(newPostageType);
            //postageTypes.Move(postageTypes.IndexOf(postageTypes[postageTypes.Count]), postageTypes.IndexOf(postageTypes[0]));

            organizations = Organization.OrganizationObservableCollection();
            organizations.Add(newOrganization);
            //organizations.Move(organizations.IndexOf(organizations[organizations.Count]), organizations.IndexOf(organizations[0]));

            txtNewRecipientFirstName.Text = recipient.FirstName;
            txtNewRecipientLastName.Text = recipient.LastName;
            txtCost.Text = mail.Cost.ToString();

            DataContext = this;

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

            if (cmbCase.SelectedItem != null && cmbCase.Visibility == Visibility.Visible && counter == 0)
            {
                legalCase = (Case)cmbCase.SelectedItem;
                mail.CaseId = legalCase.CaseId;
                counter++;
            }
            else if (!String.IsNullOrWhiteSpace(txtNewCaseName.Text) && txtNewCaseName.Visibility == Visibility.Visible && counter == 0)
            {
                legalCase.CaseName = txtNewCaseName.Text;
                Case.InsertCaseToDb(legalCase.CaseName);
                mail.CaseId = Case.CaseObservableCollection().ToList().Max(x => x.CaseId);
                counter++;
            }
            else
            {
                counter = 0;
            }

            if (cmbPostageType.SelectedItem != null && cmbPostageType.Visibility == Visibility.Visible && counter == 1)
            {
                postageType = (PostageType)cmbPostageType.SelectedItem;
                mail.PostageTypeId = postageType.PostageTypeId;
                counter++;
            }
            else if (!String.IsNullOrWhiteSpace(txtNewPostageTypeName.Text) && txtNewPostageTypeName.Visibility == Visibility.Visible && counter == 1)
            {
                postageType.PostageTypeName = txtNewPostageTypeName.Text;
                PostageType.InsertPostageTypeToDb(postageType.PostageTypeName);
                mail.PostageTypeId = PostageType.PostageTypeObservableCollection().ToList().Max(x => x.PostageTypeId);
                counter++;
            }
            else
            {
                counter = 0;
            }

            if (cmbOrganization.SelectedItem != null && cmbOrganization.Visibility == Visibility.Visible && counter == 2)
            {
                organization = (Organization)cmbOrganization.SelectedItem;
                mail.OrganizationId = organization.OrganizationId;
                counter++;
            }
            else if (!String.IsNullOrWhiteSpace(txtNewOrganizationName.Text) && txtNewOrganizationName.Visibility == Visibility.Visible && counter == 2)
            {
                organization.OrganizationName = txtNewOrganizationName.Text;
                organization.AddressLine1 = txtAddress1.Text;
                organization.AddressLine2 = txtAddress2.Text;
                organization.City = txtCity.Text;
                organization.State = txtState.Text;
                organization.Zip = txtZip.Text;
                Organization.InsertOrganizationToDb(organization.OrganizationName, organization.AddressLine1, organization.AddressLine2, organization.City, organization.State, organization.Zip);
                mail.OrganizationId = Organization.OrganizationObservableCollection().ToList().Max(x => x.OrganizationId);
                counter++;
                //MessageBox.Show("OrganizationId = " + mail.OrganizationId.ToString());
            }
            else
            {
                counter = 0;
            }

            double invalid = 0;
            bool validDouble = double.TryParse(txtCost.Text, out invalid);
            if (!String.IsNullOrWhiteSpace(txtCost.Text) && counter == 3 && validDouble == true)
            {
                mail.Cost = Convert.ToDouble(txtCost.Text);
                counter++;
            }
            else
            {
                counter = 0;
            }

            if (!String.IsNullOrWhiteSpace(txtNewRecipientFirstName.Text) && !String.IsNullOrWhiteSpace(txtNewRecipientLastName.Text) && counter == 4)
            {
                recipient.FirstName = txtNewRecipientFirstName.Text;
                recipient.LastName = txtNewRecipientLastName.Text;
                counter++;
            }
            else
            {
                counter = 0;
            }

            if (counter == 5)
            {
                Recipient.InsertRecipientToDb(recipient.FirstName, recipient.LastName);

                List<Recipient> recs = new List<Recipient>();

                mail.RecipientId = Recipient.RecipientObservableCollection().ToList().Max(x => x.RecipientId);

                Mail.UpdatePostageToDb(mail.MailId, mail.Cost, mail.CaseId, mail.PostageTypeId, mail.OrganizationId, mail.RecipientId);

                ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
                Close();
                viewPostageWindow.Show();
            }
            else
            {
                MessageBox.Show("Missing information for postage entry update");
                counter = 0;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
            Close();
            viewPostageWindow.Show();
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
            if (cmbOrganization.SelectedItem == newOrganization)
            {
                cmbOrganization.Visibility = Visibility.Collapsed;
                txtNewOrganizationName.Visibility = Visibility.Visible;
                txtAddress1.IsReadOnly = false;
                txtAddress2.IsReadOnly = false;
                txtCity.IsReadOnly = false;
                txtState.IsReadOnly = false;
                txtZip.IsReadOnly = false;
            }
            else
            {
                Organization changedOrganization = (Organization)cmbOrganization.SelectedItem;
                txtAddress1.IsReadOnly = true;
                txtAddress2.IsReadOnly = true;
                txtCity.IsReadOnly = true;
                txtState.IsReadOnly = true;
                txtZip.IsReadOnly = true;
                txtAddress1.Text = changedOrganization.AddressLine1;
                txtAddress2.Text = changedOrganization.AddressLine2;
                txtCity.Text = changedOrganization.City;
                txtState.Text = changedOrganization.State;
                txtZip.Text = changedOrganization.Zip;
            }
        }


        private void txtNewCaseName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewCaseName != null)
            {
                txtNewCaseName.SelectAll();
            }
        }

        private void txtNewRecipientFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewRecipientFirstName != null)
            {
                txtNewRecipientFirstName.SelectAll();
            }
        }

        private void txtNewRecipientLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewRecipientLastName != null)
            {
                txtNewRecipientLastName.SelectAll();
            }
        }

        private void txtNewOrganizationName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewOrganizationName != null)
            {
                txtNewOrganizationName.SelectAll();
            }
        }

        private void txtCost_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCost != null)
            {
                txtCost.SelectAll();
            }
        }

        private void txtNewPostageTypeName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewPostageTypeName != null)
            {
                txtNewPostageTypeName.SelectAll();
            }
        }

        private void txtAddress1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAddress1 != null)
            {
                txtAddress1.SelectAll();
            }
        }

        private void txtAddress2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAddress2 != null)
            {
                txtAddress2.SelectAll();
            }
        }

        private void txtCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCity != null)
            {
                txtCity.SelectAll();
            }
        }

        private void txtState_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtState != null)
            {
                txtState.SelectAll();
            }
        }

        private void txtZip_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtZip != null)
            {
                txtZip.SelectAll();
            }
        }
    }
}
