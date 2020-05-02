﻿using System;
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
using WGUCapstoneProject.Models;

namespace WGUCapstoneProject.AppViews
{
    /// <summary>
    /// Interaction logic for ViewPostageWindow.xaml
    /// </summary>
    public partial class ViewPostageWindow : Window
    {
        ObservableCollection<PostageDBEntry> PostageList = GetPostageList();

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
                new PostageDBEntry("Christian Allen", "Allen", "Kyle Muller", "Muller", 12.51, "USPS", Convert.ToDateTime("12/20/2020"))
            };
            return postageList;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            PostageList.Clear();
            postageDataGrid.ItemsSource = PostageList;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ViewPostageWindow viewPostageWindow = new ViewPostageWindow();
            Close();
            viewPostageWindow.Show();
        }

        private void btnDeleteOne_Click(object sender, RoutedEventArgs e)
        {
            PostageList.Remove(PostageList[1]);
            postageDataGrid.ItemsSource = PostageList;
        }
    }
}