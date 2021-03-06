﻿using System;
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

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for AddPostageWindow.xaml
    /// </summary>
    public partial class AddPostageWindow : Window
    {
        public ObservableCollection<Case> caseList { get; set; }
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

        int counter = 0;

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
            Navigator.NavigateToWindow(new ViewPostageWindow());
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCase.SelectedItem != null && cmbCase.Visibility == Visibility.Visible && counter == 0)
            {
                legalCase = (Case)cmbCase.SelectedItem;
                mail.CaseId = legalCase.CaseId;
                mail.CaseId = Case.CaseObservableCollection().ToList().Max(x => x.CaseId);
                counter++;
                //MessageBox.Show("CaseId = " + mail.CaseId.ToString());
            }
            else if (!String.IsNullOrWhiteSpace(txtNewCaseName.Text) && txtNewCaseName.Visibility == Visibility.Visible && counter == 0)
            {
                legalCase.CaseName = txtNewCaseName.Text;
                Case.InsertCaseToDb(legalCase.CaseName);
                mail.CaseId = Case.CaseObservableCollection().ToList().Max(x => x.CaseId);
                counter++;
                //MessageBox.Show("CaseId = " + mail.CaseId.ToString());
            }
            else
            {
                counter = 0;
            }

            if (cmbPostageType.SelectedItem != null && cmbPostageType.Visibility == Visibility.Visible && counter == 1)
            {
                postageType = (PostageType)cmbPostageType.SelectedItem;
                mail.PostageTypeId = postageType.PostageTypeId;
                mail.PostageTypeId = PostageType.PostageTypeObservableCollection().ToList().Max(x => x.PostageTypeId);
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
                mail.OrganizationId = postageType.PostageTypeId;
                mail.OrganizationId = Organization.OrganizationObservableCollection().ToList().Max(x => x.OrganizationId);
                counter++;
                //MessageBox.Show("OrganizationId = " + mail.OrganizationId.ToString());
            }
            else if(!String.IsNullOrWhiteSpace(txtNewOrganizationName.Text) && txtNewOrganizationName.Visibility == Visibility.Visible && counter == 2)
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
                mail.DateSent = DateTime.Now;
                Recipient.InsertRecipientToDb(recipient.FirstName, recipient.LastName);

                List<Recipient> recs = new List<Recipient>();

                mail.RecipientId = Recipient.RecipientObservableCollection().ToList().Max(x => x.RecipientId);

                Mail.InsertPostageToDb(mail.DateSent, mail.Cost, mail.CaseId, mail.PostageTypeId, mail.OrganizationId, mail.RecipientId);

                Navigator.NavigateToWindow(new ViewPostageWindow());
            }
            else
            {
                counter = 0;
            }
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
            }
            else
            {
                Organization changedOrganization = (Organization)cmbOrganization.SelectedItem;
                txtAddress1.Text = changedOrganization.AddressLine1;
                txtAddress2.Text = changedOrganization.AddressLine2;
                txtCity.Text = changedOrganization.City;
                txtState.Text = changedOrganization.State;
                txtZip.Text = changedOrganization.Zip;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCase.Visibility == Visibility.Collapsed && Case.CaseObservableCollection() != null)
            {
                cmbCase.Visibility = Visibility.Visible;
                txtNewCaseName.Visibility = Visibility.Collapsed;
            }
            if (cmbOrganization.Visibility == Visibility.Collapsed && Organization.OrganizationObservableCollection() != null)
            {
                cmbOrganization.Visibility = Visibility.Visible;
                txtNewOrganizationName.Visibility = Visibility.Collapsed;
            }
            if (cmbPostageType.Visibility == Visibility.Collapsed && PostageType.PostageTypeObservableCollection() != null)
            {
                cmbPostageType.Visibility = Visibility.Visible;
                txtNewPostageTypeName.Visibility = Visibility.Collapsed;
            }
            cmbCase.SelectedIndex = 1;
            cmbOrganization.SelectedIndex = 1;
            cmbPostageType.SelectedIndex = 1;
            txtNewRecipientFirstName.Text = "";
            txtNewRecipientLastName.Text = "";
            txtCost.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
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
