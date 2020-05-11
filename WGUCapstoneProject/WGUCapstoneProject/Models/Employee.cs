using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Employee : PersonBase, IUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobPosition { get; set; }

        public static ObservableCollection<Employee> EmployeeObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

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
                command.CommandText = "SELECT * FROM Employee";
                command.Connection = conn;

                //Step 4 - Open connection
                conn.Open();

                //Step 5 - Execute Command
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.UserId = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Username = reader.GetString(3);
                        employee.Password = reader.GetString(4);
                        employee.JobPosition = reader.GetString(5);
                        employees.Add(employee);
                    }
                }
                else
                {
                    return null;
                }

                //Step x = Close Connection

                //Step x = return the ObservableCollection
                return employees;
            }
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}
