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
            conn.Close();

            //Step x = return the ObservableCollection
            return cases;
        }
    }
}
