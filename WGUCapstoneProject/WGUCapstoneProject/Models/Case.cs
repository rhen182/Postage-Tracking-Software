using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Case
    {
        public Case(string caseName)
        {
            CaseName = caseName;
        }
        public Case()
        {

        }

        public int CaseId { get; set; }
        public string CaseName { get; set; }

        public static ObservableCollection<Case> CaseObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Case> cases = new ObservableCollection<Case>();

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
                command.CommandText = "SELECT * FROM LegalCase";
                command.Connection = conn;

                //Step 4 - Open connection
                conn.Open();

                //Step 5 - Execute Command
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Case legalCase = new Case();
                        legalCase.CaseId = reader.GetInt32(0);
                        legalCase.CaseName = reader.GetString(1);
                        cases.Add(legalCase);
                    }
                }
                else
                {
                    return null;
                }

                //Step x = Close Connection

                //Step x = return the ObservableCollection
                return cases;
            }
        }

        public static void InsertCaseToDb(string legalCaseName)
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
                command.CommandText = @"INSERT INTO LegalCase (CaseName) VALUES ('" + legalCaseName + "')";

                //Step 4 - Open the Connection
                conn.Open();

                //Step 5 - Execute the Command
                command.ExecuteNonQuery();

                //Step 6 - Close the Connection
            }
        }
    }
}
