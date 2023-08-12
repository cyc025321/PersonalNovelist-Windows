using Microsoft.Win32;
using PersonalNovelist_Windows.Data;
using PersonalNovelist_Windows.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace PersonalNovelist_Windows.Pages.Other
{
    /// <summary>
    /// AddBookInformation.xaml 的交互逻辑
    /// </summary>
    public partial class AddBookInformation : Window, INotifyPropertyChanged
    {

        readonly Brush BlueColor = new SolidColorBrush(Color.FromRgb(48, 51, 107));
        readonly Brush GrayColor = new SolidColorBrush(Color.FromRgb(122, 122, 122));
        public BookInformation bookInformation = new();
        private string? CoverPath; // 图片路径
        public bool ConfirmConfirmJudgment; //判断是否确认按钮被点击

        public AddBookInformation()
        {
            InitializeComponent();
            DataContext = this;
            ConfirmConfirmJudgment = false;


        }

        private string? _imagePath;
        public string? ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        /// 读取图片路径事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PickImage_click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
                CoverPath = ImagePath;
            }
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

        /// <summary>
        /// 确认按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirmed_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(BookName_Text.Text))
            {
                System.Windows.MessageBox.Show("书籍名称未输入，该项必须输入！", "警告", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);//弹出MessageBox窗口
            }
            else
            {
                //传递参数
                bookInformation.BookName = BookName_Text.Text;
                bookInformation.BookAuthor = BookAuthor_Text.Text;
                bookInformation.BookCoverpath = CoverPath;
                bookInformation.BookInstroduction = BookInstroduction_Text.Text;
                bookInformation.CopyEditTextUI!.viewModel.Bookname = BookName_Text.Text;
                bookInformation.CopyEditTextUI!.viewModel.UpdateItems();
                ConfirmConfirmJudgment = true;
                Close();
            }

        }
    }
}
