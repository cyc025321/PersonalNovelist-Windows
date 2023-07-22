using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using PersonalNovelist_Windows.Pages.Other;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using PersonalNovelist_Windows.Pages;

namespace PersonalNovelist_Windows.ViewModels
{
    class AddBookInfViewNodel : ObservableObject, INotifyPropertyChanged
    {

        public AddBookInfViewNodel() 
        {
            PickImageEventCommand = new RelayCommand(PickImageEvent);
            ConfirmedEventCommand = new RelayCommand(ConfirmedEvent);
        }


        /// <summary>
        /// 添加书籍界面，书籍的封面路径
        /// </summary>
        private string? _imagePath;
        public string? ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        /// <summary>
        /// 书籍名称
        /// </summary>
        private string? _booknameText;
        public string? BookNameText
        {
            get => _booknameText;
            set => SetProperty(ref _booknameText, value);
        }

        /// <summary>
        /// 作者
        /// </summary>
        private string? _bookAuthorText;
        public string? BookAuthorText
        {
            get => _bookAuthorText;
            set => SetProperty(ref _bookAuthorText, value);
        }


        /// <summary>
        /// 书籍简介
        /// </summary>
        private string? _bookSummaryText;
        public string? BookSummaryText
        {
            get => _bookSummaryText;
            set => SetProperty(ref _bookSummaryText, value);

        }

        /// <summary>
        /// 读取图片路径事件
        /// </summary>
        public ICommand PickImageEventCommand { get; }
        private void PickImageEvent()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                ImagePath = openFileDialog.FileName;
        }


        /// <summary>
        /// 确认按钮事件
        /// </summary>
        public ICommand ConfirmedEventCommand { get; }
        private void ConfirmedEvent()
        {
            if (BookNameText == null)
            {
                System.Windows.MessageBox.Show("书籍名称未输入，该项必须输入！", "警告", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Warning);//弹出MessageBox窗口
            }
            else
            {
                BookCard mid = new BookCard();
                mid.Margin = new Thickness(20);
                mid.NameItem.Text = BookNameText;
                BookShelfViewModel? viewModel = new BookShelfViewModel();
                viewModel.BookShelvesItem.Add(mid);
            }
                
        }
    }
}
