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
using System.Windows.Shapes;

namespace PersonalNovelist_Windows.Pages.Other
{
    /// <summary>
    /// SoftWareAbout.xaml 的交互逻辑
    /// </summary>
    public partial class SoftWareAbout : Window
    {
        public SoftWareAbout()
        {
            InitializeComponent();
        }

        private void Close_Software(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
