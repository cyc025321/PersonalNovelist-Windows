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
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;
using Path = System.IO.Path;
using PersonalNovelist_Windows.Pages.Other;
using PersonalNovelist_Windows.Pages;
using PersonalNovelist_Windows.ViewModels;
using System.Drawing;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Brush = System.Windows.Media.Brush;

namespace PersonalNovelist_Windows
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //背景颜色中等
        private readonly Brush BackGray3Color = new SolidColorBrush(Color.FromRgb(224, 224, 224));
        //背景颜色浅色
        private readonly Brush BackGray1Color = new SolidColorBrush(Color.FromRgb(238, 238, 238));

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();

        }



        private void SoftwareAbout_click (object sender, RoutedEventArgs e)
        {
            SoftWareAbout softWareAbout = new SoftWareAbout();
            softWareAbout.Show();
        }


        /// <summary>
        /// 鼠标移入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_MouseEnter(object sender, MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString(MainBookShl.Background.ToString());
            if (color.R == 238 && color.G == 238 && color.B == 238)
            {
                MainBookShl.Background = BackGray3Color;
            }
        }

        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_MouseRelese(object sender, MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString(MainBookShl.Background.ToString());
            if (color.R == 224 && color.G == 224 && color.B == 224)
            {
                MainBookShl.Background = BackGray1Color;
            }
        }
    } 
}
