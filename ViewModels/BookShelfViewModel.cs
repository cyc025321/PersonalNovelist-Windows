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
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using PersonalNovelist_Windows.Data;
using PersonalNovelist_Windows.Pages.Other;

namespace PersonalNovelist_Windows.ViewModels
{
    /// <summary>
    /// 书籍信息传递，公共属性
    /// </summary>
    public static class BookInforEvent
    {
        private static List<BookInformation> _bookInforList = new();

        public static event Action<List<BookInformation>>? OnBookInforChange;

        public static List<BookInformation> BookInforList
        {
            get { return _bookInforList; }
            set
            {
                _bookInforList = value;
                OnBookInforChange?.Invoke(_bookInforList);
            }
        }
        public static void AddItem(BookInformation item)
        {
            BookInforList.Add(item);
            OnBookInforChange?.Invoke(BookInforList);
        }

        public static void RemoveItem(BookInformation item)
        {
            BookInforList.Remove(item);
            OnBookInforChange?.Invoke(BookInforList);
        }
    }

    public partial class BookShelfViewModel : ObservableObject, INotifyPropertyChanged
    {

        public BookShelfViewModel()
        {
            AddBookInfmaEventCommand = new RelayCommand(AddBookInfmaEvent);
            BookShelvesItem = new ObservableCollection<System.Windows.Controls.UserControl>();
            TotalNumber = 0; //书籍序号
        }



        public AddBookInformation? AddBookInformation;


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
        private void AddBookInfmaEvent()
        {
            AddBookInformation = new();
            AddBookInformation.ShowDialog();

            if (AddBookInformation.ConfirmConfirmJudgment)
            {
                ADDBookItem(AddBookInformation.bookInformation);
            }
        }

        private int TotalNumber { set; get; }
        public event Action<int>? TagNumberEvent;

        /// <summary>
        /// 添加卡片函数
        /// </summary>
        /// <param name="bookInformation"></param>
        private void ADDBookItem (BookInformation bookInformation)
        {
            BookCard bc = new(); //创建新的卡片
            bc.NameItem.Text = "《"+ bookInformation.BookName + "》";
            bc.SummaryItem.Text = bookInformation.BookInstroduction;
            bc.Margin = new Thickness(20,0,0,0);
            TotalNumber += 1;
            bc.BookButton.Tag = TotalNumber;
            bookInformation.SerialNumber = TotalNumber; // 书籍序号
            BookInforEvent.BookInforList.Add(bookInformation); // 把书籍添加到集合中
            bc.BookButton.Click += (o, e) => {
                Button? button = o as Button;
                int newTagNumber = (int)button!.Tag;
                // 触发参数变化事件，并传递参数值给订阅者,打开编辑界面
                TagNumberEvent?.Invoke(newTagNumber);
            };
            BookShelvesItem?.Add(bc);  //将卡片添加到集合，并在界面显示

        }

    }
}
