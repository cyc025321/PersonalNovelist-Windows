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
    /// AddBookInformation.xaml 的交互逻辑
    /// </summary>
    public partial class AddBookInformation : Window
    {
        public AddBookInformation()
        {
            InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // 获取鼠标位置
            Point mousePosition = e.GetPosition(this);
            // 启动窗口拖拽操作
            DragMove();
        }
    }
}
