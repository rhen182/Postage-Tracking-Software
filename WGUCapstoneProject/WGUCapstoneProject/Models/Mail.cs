using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        public DateTime DateSent { get; set; }
        public double Cost { get; set; }
        public int CaseId { get; set; }
        public int PostageTypeId { get; set; }
        public int OrganizationId { get; set; }
        public int RecipientId { get; set; }

        public static ObservableCollection<Mail> MailObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Mail> mails = new ObservableCollection<Mail>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;

            //Step 2.5 - Connection
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
                    mail.Cost = reader.GetDouble(2);
                    mail.CaseId = reader.GetInt32(3);
                    
                    mail.PostageTypeId = reader.GetInt32(4);
                    mail.OrganizationId = reader.GetInt32(5);
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
        public static ObservableCollection<Mail> MailByCaseAndMonthReport(DateTime selectedMonth, Case selectedCase)
        {
            //Step 1 - define the observable collection
            ObservableCollection<Mail> monthCaseMail = new ObservableCollection<Mail>();

            //Step 2 - Connection String
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;

            //Step 2.5 - Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            {
                //Step 3 - Command
                SqliteCommand command = new SqliteCommand();
                command.CommandText = @$"SELECT MailId, CaseName, LastName, OrganizationName, Cost, PostageTypeName, DateSent FROM PostageDBEntry WHERE strftime('%m', 'DateSent') = {selectedMonth.Month.ToString("d2")} AND {selectedCase.CaseName} = CaseName";
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
                        mail.OrganizationId = reader.GetInt32(5);
                        mail.RecipientId = reader.GetInt32(6);
                        monthCaseMail.Add(mail);
                    }
                }
                else
                {
                    return null;
                }
                //Step x = Close Connection

                //Step x = return the ObservableCollection
                return monthCaseMail;
            }
        }

        public static void InsertPostageToDb(DateTime dateSent, double cost, int caseId, int postageTypeId, int organizationId, int recipientId)
        {
            //Step 1 - The Connection String
            
            SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
            connStringBuilder.DataSource = SQLiteHelper.dbDir;
            //Step 2 - The Connection
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connStringBuilder.ToString();
            using (conn)
            { 
                //Step 3 - The Command
                SqliteCommand command = new SqliteCommand();
                command.Connection = conn;
                command.CommandText =
                    $@"INSERT INTO Mail (DateSent, Cost, CaseId, PostageTypeId, OrganizationId, RecipientId) 
                      VALUES ('{dateSent.ToString("MM-dd-yyyy")}', {cost}, {caseId}, {postageTypeId}, {organizationId}, {recipientId});";
                //Step 4 - Open the Connection
                conn.Open();
                //Step 5 - Execute the Command
                command.ExecuteNonQuery();
                //Step 6 - Close the Connection
            }
        }
        public static void UpdatePostageToDb(int currentMailId, double newCost, int newCaseId, int newPostageTypeId, int newOrganizationId, int newRecipientId)
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = SQLiteHelper.dbDir;
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connectionStringBuilder.ToString();
            using (conn)
            {
                SqliteCommand command = new SqliteCommand();

                command.Connection = conn;
                command.CommandText =
                    @$"UPDATE
	                    Mail
                    SET
	                    Cost = {newCost},
	                    CaseId = {newCaseId},
	                    PostageTypeId = {newPostageTypeId},
	                    OrganizationId = {newOrganizationId},
	                    RecipientId = {newRecipientId}
                    WHERE
	                    MailId = {currentMailId};";

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
//date('%d/%M/%Y', DateSent)