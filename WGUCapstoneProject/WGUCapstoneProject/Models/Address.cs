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



        public Address(int addressId, string addressLine1, string addressLine2, string city, string state, string zipCode)
        {
            AddressId = addressId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public void GetAddresses()
        {
            ObservableCollection<Address> addressList = new ObservableCollection<Address>();
            SQLiteCommand command = new SQLiteCommand("select * from Address", SQLiteHelper.conn);
            try
            {
                SQLiteHelper.conn.Open();
                SQLiteDataReader sqliteDataReader = command.ExecuteReader();
                while (sqliteDataReader.Read())
                {
                    addressList.Add(new Address(sqliteDataReader));
                }
                //SQLiteCommand sqliteCmd;
                //sqliteCmd = SQLiteHelper.conn.CreateCommand();
                //sqliteCmd.CommandText = "Select * FROM Address"; //trying to add to list
            }
            catch (Exception)
            {

                throw;
            }
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