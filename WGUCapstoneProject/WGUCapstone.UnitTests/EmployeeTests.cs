using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WGUCapstoneProject.AppViews;
using WGUCapstoneProject.Models;

namespace WGUCapstone.UnitTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void Login_SuccessfulLogin(string username, string password, LoginWindow loginWindow)
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
                MessageBox.Show("Logged in");
                ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
                loginWindow.Close(); //this.Close();
                viewPostageWindow.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login");
            }
            //username = "test1";
            //password = "password";
            Assert.IsTrue(username == "test1" && password == "test2");

        }
    }
}
