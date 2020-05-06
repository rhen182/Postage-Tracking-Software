using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Address
    {

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public static ObservableCollection<Address> AddressObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Address> addresses = new ObservableCollection<Address>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;

            //Step 2.5 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();

            //Step 3 - Command
            SqliteCommand command = new SqliteCommand();
            command.CommandText = "SELECT * FROM Address";
            command.Connection = conn;

            //Step 4 - Open connection
            conn.Open();

            //Step 5 - Execute Command
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Address address = new Address();
                    address.AddressId = reader.GetInt32(0);
                    address.AddressLine1 = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        address.AddressLine2 = reader.GetString(2).ToString();
                    }
                    address.City = reader.GetString(3);
                    address.State = reader.GetString(4);
                    address.ZipCode = reader.GetString(5);
                    addresses.Add(address);
                }
            }
            else
            {
                return null;
            }

            //Step x = Close Connection
            conn.Close();

            //Step x = return the ObservableCollection
            return addresses;
        }





        //public int GetIdFromDb(SQLiteConnection conn, string tableName)
        //{
        //    SQLiteDataReader sqliteDataReader;
        //    SQLiteCommand sqliteCmd;
        //    sqliteCmd = conn.CreateCommand();
        //    sqliteCmd.CommandText = "SELECT " + tableName + "Id FROM " + tableName;

        //    sqliteDataReader = sqliteCmd.ExecuteReader();
        //    while (sqliteDataReader.Read())
        //    {
        //        string desiredId = 
        //    }
        //}

    }
}