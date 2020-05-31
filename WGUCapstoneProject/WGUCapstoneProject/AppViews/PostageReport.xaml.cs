using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WGUCapstoneProject.AppViews;
using WGUCapstoneProject.HelperClasses;
using WGUCapstoneProject.Models;
using Ookii.Dialogs.Wpf;

namespace WGUCapstoneProject.PlaygroundViews
{
    /// <summary>
    /// Interaction logic for PostageReport.xaml
    /// </summary>
    public partial class PostageReport : Window
    {
        ObservableCollection<Mail> mails { get; set; }
        ObservableCollection<string> months { get; set; }
        ObservableCollection<int> years { get; set; }
        ObservableCollection<Case> cases { get; set; }
        DataTable dt1 { get; set; }
        DataTable dt2 { get; set; }
        bool exportAvailable = false;
        public PostageReport()
        {
            InitializeComponent();
            cases = Case.CaseObservableCollection();
            mails = Mail.MailObservableCollection();
            years = new ObservableCollection<int>();
            months = new ObservableCollection<string>();
            foreach (Mail mail in mails)
            {
                if (!months.Contains(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mail.DateSent.Month)))
                {
                    months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mail.DateSent.Month));
                }
                if (!years.Contains(mail.DateSent.Year))
                {
                    years.Add(mail.DateSent.Year);
                }
            }
            cmbMonths.ItemsSource = months;
            cmbYears.ItemsSource = years;
            cmbCase.ItemsSource = cases;
            DataContext = this;
        }

        public void RefreshPostageDataToGrid(DataGrid dataGrid, string selectedMonth, int selectedYear, string caseName)
        {
            string month = DateTime.Parse("1" + selectedMonth + " 2008").Month.ToString("d2");

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + SQLiteDBConnection.DatabaseDirectory + ";");
            try
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = @$"SELECT MailId, CaseName, LastName, OrganizationName, Cost, PostageTypeName, DateSent FROM PostageDBEntry WHERE substr(DateSent, 0, 3) = '{month}' AND substr(DateSent, 7, 4) = '{selectedYear}' AND CaseName = '{caseName}'";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd.CommandText, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.AsDataView();
                    dt1 = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshPostageTotalToGrid(DataGrid dataGrid, string selectedMonth, int selectedYear, string caseName)
        {
            string month = DateTime.Parse("1" + selectedMonth + " 2009").Month.ToString("d2");

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + SQLiteDBConnection.DatabaseDirectory + ";");
            try
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT \"Case\", \"Month Sent\" AS MonthSent, \"Year Sent\" AS YearSent, \"Total\" FROM SummaryView WHERE \"Month Sent\" = \"{month}\" AND \"Year Sent\" = \"{selectedYear.ToString()}\" AND \"Case\" = \"{caseName}\"";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd.CommandText, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGrid.ItemsSource = dataTable.AsDataView();
                    dt2 = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCase.SelectedItem != null && cmbMonths.SelectedItem != null && cmbYears.SelectedItem != null)
            {
                Case selectedCase = (Case)cmbCase.SelectedItem;

                RefreshPostageDataToGrid(postageDataGrid, cmbMonths.SelectedItem.ToString(), Convert.ToInt32(cmbYears.SelectedItem), selectedCase.CaseName);

                RefreshPostageTotalToGrid(postageTotalGrid, cmbMonths.SelectedItem.ToString(), Convert.ToInt32(cmbYears.SelectedItem), selectedCase.CaseName);

                exportAvailable = true;
            }
            else
            {
                MessageBox.Show("Parameters for report not set.");
            }
        }

        private void btnExportToCsv_Click(object sender, RoutedEventArgs e)
        {
            ExportTotalToCSV(dt1, dt2);
        }

        public void ExportToCSV(DataTable dataTable)
        {
            if (exportAvailable == true)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in dataTable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                File.WriteAllText($"{txtCsvName.Text}.csv", sb.ToString());
                MessageBox.Show("A report has been generated.");
            }
            else
            {
                MessageBox.Show("A report has not been generated.");
            }
        }
        public void ExportTotalToCSV(DataTable dt1, DataTable dt2)
        {
            if (exportAvailable == true)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Postage List");
                foreach (DataRow row in dt1.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                sb.Append(",");
                sb.Append(",");
                sb.Append(",");
                sb.Append("Total Cost: ,");
                foreach (DataRow row in dt2.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(fields.ToArray()[3]);
                }


                VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
                dialog.ShowDialog();
                string selectedDir = dialog.SelectedPath;
                MessageBox.Show(selectedDir);
                if(!String.IsNullOrWhiteSpace(selectedDir))
                {
                    string fileName = $"{txtCsvName.Text}.csv";
                    if (txtCsvName.Text == "Enter Exported Report Name")
                    {
                        foreach (DataRow row in dt2.Rows)
                        {
                            IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                            fileName = "Postage_" + fields.ToArray()[0] + "_" + fields.ToArray()[1] + "-" + fields.ToArray()[2] + ".csv";
                        }
                    }
                    string fileDir = Convert.ToString(@$"{selectedDir}\{fileName}");
                    File.WriteAllText(fileDir, sb.ToString());
                    MessageBox.Show("A report has been generated.");
                }
                else
                {
                    MessageBox.Show("Please choose a place to save the file.");
                    
                }
            }
            else
            {
                MessageBox.Show("A report has not been generated.");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow view = new ViewPostageWindow();
            Close();
            view.Show();
        }

        private void txtCsvName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtCsvName != null)
            {
                txtCsvName.SelectAll();
            }
        }
    }
}
