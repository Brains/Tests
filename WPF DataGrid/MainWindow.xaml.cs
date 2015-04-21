using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF
{
    //-------------------------------------------------------------------
    public partial class MainWindow : Window
    {
        //-------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new WindowViewModel();
            
            DataContext = viewModel;
        }

        private void Button_Click (object sender, RoutedEventArgs e)
        {
            Debug.WriteLine ("Break");
	        TestTextBox.Text = "Clicked";
        }
    }
}
