﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WGUCapstoneProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateTextBoxToLabel(txtValue1, lblValue1);
        }

        private void ClickUpdateThroughButton(object sender, RoutedEventArgs e)
        {
            lblValue2.Text = txtValue2.Text;
        }

        public void UpdateTextBoxToLabel(TextBox sourceTextBox, TextBlock destinationTextBlock)
        {
            //Creates binding instance to the selected property
            Binding binding = new Binding("Text");
            //Defines which "Text" we are changing
            binding.Source = sourceTextBox;
            //Sets the destination
            destinationTextBlock.SetBinding(TextBlock.TextProperty, binding);
        }
    }
} 