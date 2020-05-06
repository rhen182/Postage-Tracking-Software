﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;

namespace WGUCapstoneProject.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        public DateTime DateSent { get; set; }
        public int CaseId { get; set; }
        public double Cost { get; set; }
        public int PostageTypeId { get; set; }
        public int AddressId { get; set; }
        public int RecipientId { get; set; }

        public static ObservableCollection<Mail> CaseObservableCollection(ObservableCollection<Mail> mails, string connString)
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
            command.CommandText = "SELECT * FROM Mail";
            command.Connection = conn;

            //Step 4 - Open connection
            conn.Open();

            //Step 5 - Execute Command
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Mail mail = new Mail();
                    mail.MailId = reader.GetInt32(0);
                    mail.DateSent = reader.GetDateTime(1);
                    mail.CaseId = reader.GetInt32(2);
                    mail.Cost = reader.GetDouble(3);
                    mail.PostageTypeId = reader.GetInt32(4);
                    mail.AddressId = reader.GetInt32(5);
                    mail.RecipientId = reader.GetInt32(6);
                    mails.Add(mail);
                }
            }
            else
            {
                return null;
            }

            //Step x = Close Connection
            conn.Close();

            //Step x = return the ObservableCollection
            return mails;
        }
    }
}
