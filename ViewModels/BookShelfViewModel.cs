using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalNovelist_Windows.Data;
using PersonalNovelist_Windows.Pages.Other;

namespace PersonalNovelist_Windows.ViewModels
{
    public partial class BookShelfViewModel : ObservableObject, INotifyPropertyChanged
    {

        public BookShelfViewModel()
        {
            AddBookInfmaEventCommand = new RelayCommand(AddBookInfmaEvent);
            BookShelvesItem = new ObservableCollection<System.Windows.Controls.UserControl>();
            AddBookInformation = new AddBookInformation();
            OneAdd = true;
        }

        private bool OneAdd { set; get; }
        private AddBookInformation AddBookInformation { set; get; }


        //Item绑定的布局，添加卡片后，自动界面更新
        private ObservableCollection<System.Windows.Controls.UserControl>? _bookShelvesItem;

        public ObservableCollection<System.Windows.Controls.UserControl>? BookShelvesItem
        {
            get => _bookShelvesItem;
            set => SetProperty(ref _bookShelvesItem, value);
        }


        /// <summary>
        /// 打开添加书籍界面，输入参数后，创建新的卡片
        /// </summary>
        public ICommand AddBookInfmaEventCommand { get; }
        public void AddBookInfmaEvent()
        {
            if (OneAdd)
            {
                AddBookInformation.ShowDialog();

                if (AddBookInformation.ConfirmConfirmJudgment)
                {
                    ADDBookItem(AddBookInformation.bookInformation);
                }
                OneAdd = false;
            }
            else
            {
                AddBookInformation = new();
                AddBookInformation.ShowDialog();

                if (AddBookInformation.ConfirmConfirmJudgment)
                {
                    ADDBookItem(AddBookInformation.bookInformation);
                }
            }
            
            
        }


        /// <summary>
        /// 添加卡片函数
        /// </summary>
        /// <param name="bookInformation"></param>
        private void ADDBookItem (BookInformation bookInformation)
        {
            BookCard bc = new BookCard(); //创建新的卡片
            bc.NameItem.Text = bookInformation.BookName;
            bc.SummaryItem.Text = bookInformation.BookInstroduction;
            bc.Margin = new Thickness(20,0,0,0);
            BookShelvesItem?.Add(bc);
        }

    }
}
