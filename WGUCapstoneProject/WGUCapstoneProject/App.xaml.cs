using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WGUCapstoneProject.AppViews;
using WGUCapstoneProject.PlaygroundViews;

namespace WGUCapstoneProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
            viewPostageWindow.Show();
        }
    }
}
