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
using System.Windows.Shapes;
using CommunityToolkit.Mvvm;
using PersonalNovelist_Windows.ViewModels;
using PersonalNovelist_Windows.Pages.Other;
using PersonalNovelist_Windows.Data;

namespace PersonalNovelist_Windows.Pages
{
    /// <summary>
    /// BookShelves.xaml 的交互逻辑
    /// </summary>
    public partial class BookShelves : UserControl
    {
        public BookShelves()
        {
            InitializeComponent();
            this.DataContext = new BookShelfViewModel();
            aa.Content = new BookCard();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UIElementCollection children = wrapPanel.Children;
            //SQLiteClass.CreateDB();
            //SQLiteClass.CreateTable();
            //BookCard mid = new BookCard();
            //mid.Margin = new Thickness(20);
            // 将新控件添加到StackPanel中
            //BookShelvePanel.Children.Add(mid);
        }

    }
}
