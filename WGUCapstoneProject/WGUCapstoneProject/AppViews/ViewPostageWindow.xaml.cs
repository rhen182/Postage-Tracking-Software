using System;
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

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for ViewPostageWindow.xaml
    /// </summary>
    public partial class ViewPostageWindow : Window
    {
        public ViewPostageWindow()
        {
            InitializeComponent();
            RefreshPostageDataToGrid(postageDataGrid);
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteOne_Click(object sender, RoutedEventArgs e)
        {

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
    }
}