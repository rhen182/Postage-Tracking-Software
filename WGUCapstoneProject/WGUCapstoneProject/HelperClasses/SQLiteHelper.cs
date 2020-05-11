using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;

namespace WGUCapstoneProject.HelperClasses
{
    public class SQLiteHelper
    {
        static public string dbDir = Directory.GetParent
                (Directory.GetParent
                (Directory.GetParent
                (Environment.CurrentDirectory)
                .ToString()).ToString()).ToString()
                + "/PostageDB.db";

        static public string reportDir = Directory.GetParent
                (Directory.GetParent
                (Directory.GetParent
                (Environment.CurrentDirectory)
                .ToString()).ToString()).ToString() + "/Report.csv";

        static public SQLiteConnection conn = new SQLiteConnection("Data Source=" + SQLiteHelper.dbDir + ";");



        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=PostageDB.db; Version=3;New=True;Compress=True;");
            try
            {
                sqliteConn.Open();
            }
            catch (Exception)
            {
                throw;
            }
            return sqliteConn;
        }

        static void InsertData(SQLiteConnection conn, string insertStatement)
        {
            SQLiteCommand sqliteCmd;
            sqliteCmd = conn.CreateCommand();
            sqliteCmd.CommandText = insertStatement; //Example: "INSERT INTO SampleTable (Col1, Col2) VALUES ('Test Text ', 1);";
            sqliteCmd.ExecuteNonQuery();
            conn.Close();
        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteDataReader;
            SQLiteCommand sqliteCmd;
            sqliteCmd = conn.CreateCommand();
            sqliteCmd.CommandText = "Select * FROM SampleTable";

            sqliteDataReader = sqliteCmd.ExecuteReader();
            while (sqliteDataReader.Read())
            {
                string dataReader = sqliteDataReader.GetString(0);
                MessageBox.Show(dataReader);
            }
            conn.Close();
        }

        public static int SelectIdValue(string idColumn, string sourceTable, string targetTable)
        {
            //Step 1 - The Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;

            //Step 2 - The Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();

            //Step 3 - Command
            SqliteCommand command = new SqliteCommand();
            command.CommandText = @"SELECT " + idColumn + " FROM " + sourceTable + " WHERE " + idColumn + " = (SELECT " + idColumn + "FROM " + targetTable + ")";
            command.Connection = conn;

            //Step 4 - Open conn
            conn.Open();

            //Step 5 - execute command
            int id = Convert.ToInt32(command.ExecuteScalar());

            //Step 6 - Clean Up
            command.Dispose();
            conn.Close();

            //Step 7 - return data
            return id;
        }
    }
}
