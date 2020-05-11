using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Employee user = new Employee();

            List<Employee> employees = Employee.EmployeeObservableCollection().ToList();

            user.Username = txtUsername.Text;
            user.Password = txtPassword.Password;
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
                Close();
                viewPostageWindow.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
