using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class Address
    {



        public Address(string addressLine1, string addressLine2, string city, string state, string zipCode)
        {
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