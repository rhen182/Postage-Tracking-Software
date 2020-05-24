using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WGUCapstoneProject.HelperClasses
{
    public class DatagridController
    {
        public SQLiteConnection Connection { get; }
        public SQLiteCommand Command { get; set;}
        public SQLiteDataAdapter Adapter { get; }
        public DataTable DataTable { get; }

        public DatagridController(SQLiteCommand cmd, SQLiteConnection conn)
        {
            Connection = new SQLiteConnection($"Data Source = {SQLiteDBConnection.DatabaseDirectory};");
            Command = new SQLiteCommand();
            Adapter = new SQLiteDataAdapter(cmd.CommandText, conn);
            DataTable = new DataTable();
        }

        public static int GetSelectedId(DataGrid dataGrid)
        {
            int selectedId = Convert.ToInt32(((DataRowView)dataGrid.SelectedValue)[0]);
            return selectedId;
        }

        public void FillDataGrid(DataGrid selectedDataGrid, SQLiteCommand command)
        {
            using (Connection)
            {
                Command = command;
                Connection.Open();
                Adapter.Fill(DataTable);
                selectedDataGrid.ItemsSource = DataTable.AsDataView();
                command = null;
                Connection.Close();
            }
        }
    }
}
