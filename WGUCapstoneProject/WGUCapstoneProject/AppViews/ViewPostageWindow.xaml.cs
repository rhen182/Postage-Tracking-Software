using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for ViewPostageWindow.xaml
    /// </summary>
    public partial class ViewPostageWindow : Window
    {
        ObservableCollection<PostageDBEntry> PostageList = GetPostageList();
        //Database directory. Takes the parent of the current directory and goes up a few times so the conn string is universal
        string dbDir =
            Directory.GetParent
            (Directory.GetParent
            (Directory.GetParent
            (Environment.CurrentDirectory)
            .ToString()).ToString()).ToString()
            + "/PostageDB.db";
        



        public ViewPostageWindow()
        {
            InitializeComponent();
            postageDataGrid.ItemsSource = PostageList;
        }

        public static ObservableCollection<PostageDBEntry> GetPostageList()
        {
            ObservableCollection<PostageDBEntry> postageList = new ObservableCollection<PostageDBEntry>
            {
                new PostageDBEntry("Christian Allen", "Allen", "Brandon Roberts", "Roberts", 12.50, "USPS", Convert.ToDateTime("12/20/2020")),
                new PostageDBEntry("Christian Allen", "Allen", "Jake Serna", "Serna", 1.30, "USPS", Convert.ToDateTime("12/20/2020")),
                new PostageDBEntry("Christian Allen", "George", "Davinaty Roberts", "Roberts", 14.00, "USPS", Convert.ToDateTime("12/20/2020")),
                new PostageDBEntry("Christian Allen", "Bob", "Kyle Muller", "Muller", 12.51, "USPS", Convert.ToDateTime("12/20/2020"))
            };
            return postageList;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            PostageList.Clear();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
            Close();
            viewPostageWindow.Show();
        }

        private void BtnDeleteOne_Click(object sender, RoutedEventArgs e)
        {
            PostageList.Remove(PostageList[postageDataGrid.SelectedIndex]);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPostageWindow addPostage = new AddPostageWindow();
            Close();
            addPostage.Show();
        }
    }
}