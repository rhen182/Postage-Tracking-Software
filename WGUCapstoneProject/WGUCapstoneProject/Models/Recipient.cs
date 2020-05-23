using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Recipient : PersonBase
    {
        public int RecipientId { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public Recipient()
        {

        }
        public Recipient(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }



        public static ObservableCollection<Recipient> RecipientObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Recipient> recipients = new ObservableCollection<Recipient>();

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
                command.CommandText = "SELECT * FROM Recipient";
                command.Connection = conn;

                //Step 4 - Open connection
                conn.Open();

                //Step 5 - Execute Command
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipient recipient = new Recipient();
                        recipient.RecipientId = reader.GetInt32(0);
                        recipient.FirstName = reader.GetString(1);
                        recipient.LastName = reader.GetString(2);
                        recipients.Add(recipient);
                    }
                }
                else
                {
                    return null;
                }

                //Step x = Close Connection
                conn.Close();

                //Step x = return the ObservableCollection
                return recipients;
            }
        }

        public static void UpdateRecipientToDb(string firstName, string lastName)
        {
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                SqliteCommand command = new SqliteCommand();
                command.Connection = conn;
                command.CommandText = @"UPDATE Recipient SET FirstName = " + firstName + ", SET LastName = " + lastName + "')";
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void InsertRecipientToDb(string firstName, string lastName)
        {
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteDBConnection.DatabaseDirectory;
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                SqliteCommand command = new SqliteCommand();
                command.Connection = conn;
                command.CommandText = @"INSERT INTO Recipient (FirstName, LastName)
                                    VALUES ('" + firstName + "', '" + lastName + "')";
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
