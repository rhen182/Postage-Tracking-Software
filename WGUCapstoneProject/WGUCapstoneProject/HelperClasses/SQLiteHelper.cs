using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace WGUCapstoneProject.HelperClasses
{
    public class SQLiteHelper
    {
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=PostageDB.db; Version=3;New=True;Compress=True;");
            try
            {
                sqliteConn.Open();
            }
            catch (Exception ex)
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
    }
}
