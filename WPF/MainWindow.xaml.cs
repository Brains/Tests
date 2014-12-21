﻿using System;
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

            var viewModel = new WindowViewModel();
            
            DataContext = viewModel;
        }
    }
}
