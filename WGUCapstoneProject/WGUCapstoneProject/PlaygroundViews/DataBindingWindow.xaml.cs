using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WGUCapstoneProject.PlaygroundViews
{
    /// <summary>
    /// Interaction logic for DataBindingWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public DataBindingWindow()
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
