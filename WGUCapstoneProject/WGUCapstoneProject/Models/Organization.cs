using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int AddressId { get; set; }
        public static ObservableCollection<Organization> RecipientObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Organization> organizations = new ObservableCollection<Organization>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;

            //Step 2.5 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();

            //Step 3 - Command
            SqliteCommand command = new SqliteCommand();
            command.CommandText = "SELECT * FROM Organization";
            command.Connection = conn;

            //Step 4 - Open connection
            conn.Open();

            //Step 5 - Execute Command
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Organization organization = new Organization();
                    organization.OrganizationId = reader.GetInt32(0);
                    organization.OrganizationName = reader.GetString(1);
                    organization.AddressId = reader.GetInt32(2);
                    organizations.Add(organization);
                }
            }
            else
            {
                return null;
            }

            //Step x = Close Connection
            conn.Close();

            //Step x = return the ObservableCollection
            return organizations;
        }
    }
}
