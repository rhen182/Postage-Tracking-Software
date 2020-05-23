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
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Organization()
        {

        }
        public Organization(string organizationName)
        {
            OrganizationName = organizationName;
        }

        public static ObservableCollection<Organization> OrganizationObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Organization> organizations = new ObservableCollection<Organization>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;

            //Step 2.5 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
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
                        organization.AddressLine1 = reader.GetString(2);
                        organization.AddressLine2 = reader.GetString(3);
                        organization.City = reader.GetString(4);
                        organization.State = reader.GetString(5);
                        organization.Zip = reader.GetString(6);
                        organizations.Add(organization);
                    }
                }
                else
                {
                    return null;
                }

                //Step x = Close Connection

                //Step x = return the ObservableCollection
                return organizations;
            }
        }


        public static void InsertOrganizationToDb(string organizationName, string addressLine1, string addressLine2, string city, string state, string zip)
        {
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                SqliteCommand command = new SqliteCommand();
                command.Connection = conn;
                command.CommandText = @"INSERT INTO Organization (OrganizationName, AddressLine1, AddressLine2, City, State, Zip)
                                        VALUES ('" + organizationName + "', '" + addressLine1 + "', '" + addressLine2 + "', '" + city + "', '" + state + "', '" + zip + "')";
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
