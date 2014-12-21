using System;
using System.Collections.Generic;
using System.ComponentModel;
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
//            Grid.ColumnWidth = 100;

            var viewModel = new WindowViewModel();
            
            DataContext = viewModel;
//            Grid.DataContext = viewModel;

            Grid.ItemsSource = viewModel.Data;

//            Name.DataContext = viewModel;
            Name.SourceUpdated += (sender, args) => viewModel.FilterList();


//            var sss = Grid.FindName("Panel");
//            Button sorting = Grid.FindName("Panel") as Button;
//            sorting.DataContext = viewModel;

        }
    }
}
