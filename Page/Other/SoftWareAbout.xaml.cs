﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalNovelist_Windows.Page.Other
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class SoftWareAbout : Window
    {
        public SoftWareAbout()
        {
            InitializeComponent();
        }

        private void Close_Software (object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
