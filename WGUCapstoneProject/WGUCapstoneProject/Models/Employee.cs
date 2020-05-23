using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using WGUCapstoneProject.AppViews;
using WGUCapstoneProject.HelperClasses;

namespace WGUCapstoneProject.Models
{
    public class Employee : PersonBase
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobPosition { get; set; }
        public Employee()
        {

        }
        public Employee(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static ObservableCollection<Employee> EmployeeObservableCollection()
        {
            //Step 1 - define the observable collection
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

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

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("test1", "test2"));
            employees.Add(new Employee("username", "password"));
            return employees;
        }

        public bool CanLoginList(string username, string password)
        {
            Employee user = new Employee();
            user.Username = username; //txtUsername.Text;
            user.Password = password; //txtPassword.Password;
            bool passwordCorrect = false;
            bool usernameCorrect = false;

            foreach (Employee employee in GetEmployees())
            {
                if (employee.Username == user.Username)
                {
                    usernameCorrect = true;
                    if (usernameCorrect == true && employee.Password == user.Password)
                    {
                        passwordCorrect = true;
                        break;
                    }
                    else
                    {
                        usernameCorrect = false;
                        passwordCorrect = false;
                    }
                }
                else
                {
                    usernameCorrect = false;
                    passwordCorrect = false;
                }
            }
            if (usernameCorrect == true && passwordCorrect == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool CanLogin(string username, string password)
        {
            Employee user = new Employee();

            List<Employee> employees = Employee.EmployeeObservableCollection().ToList();

            user.Username = username; //txtUsername.Text;
            user.Password = password; //txtPassword.Password;
            bool passwordCorrect = false;
            bool usernameCorrect = false;

            foreach (Employee employee in employees)
            {
                if (employee.Username == user.Username)
                {
                    usernameCorrect = true;
                    if (usernameCorrect == true && employee.Password == user.Password)
                    {
                        passwordCorrect = true;
                        break;
                    }
                    else
                    {
                        usernameCorrect = false;
                        passwordCorrect = false;
                    }
                }
                else
                {
                    usernameCorrect = false;
                    passwordCorrect = false;
                }
            }
            if (usernameCorrect == true && passwordCorrect == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
