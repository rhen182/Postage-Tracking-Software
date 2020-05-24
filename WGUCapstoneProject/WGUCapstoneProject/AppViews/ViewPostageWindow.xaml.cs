using System;
using System.Windows;
using System.Windows.Controls;
using WGUCapstoneProject.Models;
using System.Data.SQLite;
using System.Data;
using WGUCapstoneProject.HelperClasses;
using System.Linq;
using WGUCapstoneProject.PlaygroundViews;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for ViewPostageWindow.xaml
    /// </summary>
    public partial class ViewPostageWindow : Window
    {
        //Constructor
        public ViewPostageWindow()
        {
            InitializeComponent();
            LoadPostageDataToGrid(mailDataGrid);
        }

        //Window Methods
        public void LoadPostageDataToGrid(DataGrid dataGrid)
        {
            SQLiteCommand command = CustomSQLiteCommand.SelectStatement(SQLiteDBConnection.Connection, "MailId", "CaseName", "LastName", "OrganizationName", "Cost", "PostageTypeName", "DateSent", "PostageDBEntry");
            DatagridController datagridController = new DatagridController(command, SQLiteDBConnection.Connection);
            datagridController.FillDataGrid(dataGrid, datagridController.Command);
        }
        public void DeleteSelectedPostage(DataGrid dataGrid)
        {
            SQLiteCommand command = CustomSQLiteCommand.DeleteFromTableStatement(SQLiteDBConnection.Connection, "Mail", DatagridController.GetSelectedId(dataGrid));
            CustomSQLiteCommand.DeleteFromTable(command);
        }
        private void BtnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            CustomSQLiteCommand.TruncateTable("Mail", "LegalCase", "Organization", "PostageType", "Recipient");
            LoadPostageDataToGrid(mailDataGrid);
        }

        //Button Click Events
        private void BtnDeleteOne_Click(object sender, RoutedEventArgs e)
        {
            if (mailDataGrid.SelectedItem != null)
            {
                DeleteSelectedPostage(mailDataGrid);
                LoadPostageDataToGrid(mailDataGrid);
            }
            else
            {
                MessageBox.Show("Please select a postage entry to delete.");
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateToWindow(new AddPostageWindow());
        }
        private void btnGetReport_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateToWindow(new PostageReport());
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (mailDataGrid.SelectedItem != null)
            {
                int postageTypeIndex;
                int caseIndex;
                int organizationIndex;
                Mail selectedMail = new Mail();
                selectedMail.MailId = Convert.ToInt32(((DataRowView)mailDataGrid.SelectedValue)[0]);
                selectedMail = Mail.MailObservableCollection().ToList().Find(x => x.MailId == selectedMail.MailId);
                Case selectedCase = Case.CaseObservableCollection().ToList().Find(x => x.CaseId == selectedMail.CaseId);
                Organization selectedOrganization = Organization.OrganizationObservableCollection().ToList().Find(x => x.OrganizationId == selectedMail.OrganizationId);
                PostageType selectedPostageType = PostageType.PostageTypeObservableCollection().ToList().Find(x => x.PostageTypeId == selectedMail.PostageTypeId);
                Recipient selectedRecipient = Recipient.RecipientObservableCollection().ToList().Find(x => x.RecipientId == selectedMail.RecipientId);

                caseIndex = Case.CaseObservableCollection().ToList().FindIndex(x => x.CaseId == selectedMail.CaseId);
                postageTypeIndex = PostageType.PostageTypeObservableCollection().ToList().FindIndex(x => x.PostageTypeId == selectedMail.PostageTypeId);
                organizationIndex = Organization.OrganizationObservableCollection().ToList().FindIndex(x => x.OrganizationId == selectedMail.OrganizationId);

                Navigator.NavigateToWindow(new ModifyPostageWindow
                    (caseIndex, organizationIndex, postageTypeIndex, selectedMail, selectedCase, selectedOrganization, selectedPostageType, selectedRecipient));
            }
            else
            {
                MessageBox.Show("Please select a postage entry.");
            }
        }
    }
}