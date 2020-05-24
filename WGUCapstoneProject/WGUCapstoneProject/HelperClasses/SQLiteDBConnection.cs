using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;

namespace WGUCapstoneProject.HelperClasses
{
    public class SQLiteDBConnection
    {
        //Hard coded, will probably want to make databaseName and DatabaseDirectory browseable
        private static readonly string databaseName = "PostageDB.db";
        public static string DatabaseDirectory
        {
            get
            {
                string databaseLocation = Directory.GetParent
                (Directory.GetParent
                (Directory.GetParent
                (Environment.CurrentDirectory).ToString()).ToString()).ToString() + $"/{databaseName}";
                return databaseLocation; 
            }
        }
        public static SQLiteConnection Connection
        {
            get
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + DatabaseDirectory + ";");
                return connection;
            }
        }
    }
}
