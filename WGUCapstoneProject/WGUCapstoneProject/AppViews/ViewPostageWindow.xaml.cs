﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
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
        public int postageTypeIndex;
        public int caseIndex;
        public int organizationIndex;


        public ViewPostageWindow()
        {
            InitializeComponent();

            RefreshPostageDataToGrid(postageDataGrid);
        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPostageDataToGrid(postageDataGrid);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnectionStringBuilder connStringBuilder = new SQLiteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = conn;
                command.CommandText = @"DELETE FROM Mail; DELETE FROM LegalCase; DELETE FROM Organization; DELETE FROM PostageType; DELETE FROM Recipient; DELETE FROM sqlite_sequence;";
                conn.Open();
                command.ExecuteNonQuery();
                RefreshPostageDataToGrid(postageDataGrid);
            }
        }
        private void BtnDeleteOne_Click(object sender, RoutedEventArgs e)
        {
            if (postageDataGrid.SelectedItem != null)
            {
                Mail selectedMail = new Mail();
                selectedMail.MailId = Convert.ToInt32(((DataRowView)postageDataGrid.SelectedValue)[0]);
                SQLiteConnectionStringBuilder connStringBuilder = new SQLiteConnectionStringBuilder();
                connStringBuilder.DataSource = SQLiteHelper.dbDir;
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = connStringBuilder.ToString();
                using (conn)
                {
                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = conn;
                    command.CommandText = @"DELETE FROM Mail WHERE MailId = " + selectedMail.MailId + ";";
                    conn.Open();
                    command.ExecuteNonQuery();
                    RefreshPostageDataToGrid(postageDataGrid);
                }
            }
            else
            {
                MessageBox.Show("Please select a postage entry to delete.");
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPostageWindow addPostage = new AddPostageWindow();
            Close();
            addPostage.Show();
        }

        public void RefreshPostageDataToGrid(DataGrid dataGrid)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + SQLiteHelper.dbDir + ";");
            try
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM PostageDBEntry ";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd.CommandText, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (postageDataGrid.SelectedItem != null)
            {
                Mail selectedMail = new Mail();
                selectedMail.MailId = Convert.ToInt32(((DataRowView)postageDataGrid.SelectedValue)[0]);
                selectedMail = Mail.MailObservableCollection().ToList().Find(x => x.MailId == selectedMail.MailId);
                Case selectedCase = Case.CaseObservableCollection().ToList().Find(x => x.CaseId == selectedMail.CaseId);
                Organization selectedOrganization = Organization.OrganizationObservableCollection().ToList().Find(x => x.OrganizationId == selectedMail.OrganizationId);
                PostageType selectedPostageType = PostageType.PostageTypeObservableCollection().ToList().Find(x => x.PostageTypeId == selectedMail.PostageTypeId);
                Recipient selectedRecipient = Recipient.RecipientObservableCollection().ToList().Find(x => x.RecipientId == selectedMail.RecipientId);

                caseIndex = Case.CaseObservableCollection().ToList().FindIndex(x => x.CaseId == selectedMail.CaseId);
                postageTypeIndex = PostageType.PostageTypeObservableCollection().ToList().FindIndex(x => x.PostageTypeId == selectedMail.PostageTypeId);
                organizationIndex = Organization.OrganizationObservableCollection().ToList().FindIndex(x => x.OrganizationId == selectedMail.OrganizationId);

                ModifyPostageWindow modifyPostageWindow = new ModifyPostageWindow
                    (caseIndex, organizationIndex, postageTypeIndex, selectedMail, selectedCase, selectedOrganization, selectedPostageType, selectedRecipient);
                Close();
                modifyPostageWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a postage entry.");
            }

        }

        private void btnGetReport_Click_1(object sender, RoutedEventArgs e)
        {
            PostageReport postageReport = new PostageReport();
            Close();
            postageReport.Show();
        }
    }
}