using System;
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



        private void BookName_MouseEnter(object sender, MouseEventArgs e)
        {
            // 创建一个新的Brush对象来设置颜色
            Brush brush = (Brush)new BrushConverter().ConvertFromString("#30336b");
            // 将新的Brush对象设置为TextBlock的前景色
            BookName_ICON.Foreground = brush;
        }

        private void BookName_MouseLeave(object sender, MouseEventArgs e)
        {
            // 创建一个新的Brush对象来设置颜色
            Brush brush = (Brush)new BrushConverter().ConvertFromString("#7a7a7a");
            // 将新的Brush对象设置为TextBlock的前景色
            BookName_ICON.Foreground = brush;
        }
        //--------------------
        //作者
        
        private void BookAuthor_MouseEnter(object sender, MouseEventArgs e)
        {
            // 创建一个新的Brush对象来设置颜色
            Brush brush = (Brush)new BrushConverter().ConvertFromString("#30336b");
            // 将新的Brush对象设置为TextBlock的前景色
            BookAuthor_ICON.Foreground = brush;
        }

        private void BookAuthor_MouseLeave(object sender, MouseEventArgs e)
        {
            // 创建一个新的Brush对象来设置颜色
            Brush brush = (Brush)new BrushConverter().ConvertFromString("#7a7a7a");
            // 将新的Brush对象设置为TextBlock的前景色
            BookAuthor_ICON.Foreground = brush;
        }
    }
}
