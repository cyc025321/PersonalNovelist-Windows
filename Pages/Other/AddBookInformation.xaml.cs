using Microsoft.Win32;
using PersonalNovelist_Windows.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PersonalNovelist_Windows.Pages.Other
{
    /// <summary>
    /// AddBookInformation.xaml 的交互逻辑
    /// </summary>
    public partial class AddBookInformation : Window
    {

        Brush BlueColor = new SolidColorBrush(Color.FromRgb(48, 51, 107));
        Brush GrayColor = new SolidColorBrush(Color.FromRgb(122, 122, 122));
        

        public AddBookInformation()
        {
            InitializeComponent();
            this.DataContext = new AddBookInfViewNodel();
        }



        private void BookName_MouseEnter(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookName_ICON.Foreground = BlueColor;
        }

        private void BookName_MouseLeave(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookName_ICON.Foreground = GrayColor;
        }
        //--------------------
        //作者
        
        private void BookAuthor_MouseEnter(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookAuthor_ICON.Foreground = BlueColor;
        }

        private void BookAuthor_MouseLeave(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookAuthor_ICON.Foreground = GrayColor;
        }

        //-----------------------------------------
        // 封面 
        private void BookCover_MouseEnter(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookCover_ICON.Foreground = BlueColor;
        }

        private void BookCover_MouseLeave(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookCover_ICON.Foreground = GrayColor;
        }

        //-----------------------------------------
        // 书籍简介
        private void BookSummary_MouseEnter(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookSummary_ICON.Foreground = BlueColor;
        }

        private void BookSummary_MouseLeave(object sender, MouseEventArgs e)
        {
            // 将新的Brush对象设置为TextBlock的前景色
            BookSummary_ICON.Foreground = GrayColor;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
