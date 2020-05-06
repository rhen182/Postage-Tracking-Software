using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class PostageType
    {
        public int PostageTypeId { get; set; }
        public string PostageTypeName { get; set; }

        public static ObservableCollection<PostageType> PostageTypeObservableCollection(ObservableCollection<PostageType> postageTypes, string connString)
        {
            //Step 1 - define the observable collection

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = connString;

            //Step 2 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();

            //Step 3 - Command
            SqliteCommand command = new SqliteCommand();
            command.CommandText = "SELECT * FROM PostageType";
            command.Connection = conn;

            //Step 4 - Open connection
            conn.Open();

            //Step 5 - Execute Command
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PostageType postageType = new PostageType();
                    postageType.PostageTypeId = reader.GetInt32(0);
                    postageType .PostageTypeName = reader.GetString(1);
                    postageTypes.Add(postageType);
                }
            }
            else
            {
                return null;
            }

            //Step x = Close Connection
            conn.Close();

            //Step x = return the ObservableCollection
            return postageTypes;
        }
    }
}
