using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalNovelist_Windows;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using PersonalNovelist_Windows.Pages;
using System.Windows.Controls;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PersonalNovelist_Windows.ViewModels
{
    public class MainWindowViewModel: ObservableObject, INotifyPropertyChanged
    {

        private readonly Brush ForGrayColor = new SolidColorBrush(Color.FromRgb(127, 140, 141));
        private readonly Brush ForBlueColor = new SolidColorBrush(Color.FromRgb(52, 73, 94));

        //背景颜色浅色
        private readonly Brush BackGray1Color = new SolidColorBrush(Color.FromRgb(238, 238, 238));
        //背景颜色深色
        private readonly Brush BackGray2Color = new SolidColorBrush(Color.FromRgb(217, 217, 217));

        private int CurrentBookSerialNumber { set; get; }

        public MainWindowViewModel() 
        { 
            MainBookShelvesCommand  = new RelayCommand(MainBookShelves);
            EditUICommand = new RelayCommand(EditUI);
            ButtonThick = new System.Windows.Thickness(0,0,4,0);
            Button2Thick = new System.Windows.Thickness(0,0,0,0);
            Bo1ForBrush = ForBlueColor;
            Bo1BackBrush = BackGray2Color;
            But1bool = true;
            But2bool = false;
            Bo2ForBrush = ForGrayColor;
            Bo2BackBrush = BackGray1Color;
            BookShelve = new BookShelves();
            BookPlainPage = BookShelve;
            // 订阅File1ViewModel中的事件或消息
            BookShelve.ViewModel.TagNumberEvent += OpenEditUI;
            CurrentBookSerialNumber = 0;
        }

        private BookShelves BookShelve { set; get; }
        //private EditTextUI EditText { set; get; }

        /// <summary>
        /// 按钮1的bool类型，判断是否激活
        /// </summary>
        private bool _but1bool;
        public bool But1bool
        {
            get { return _but1bool; } 
            set { _but1bool = value; }
        }

        /// <summary>
        /// 按钮2的bool类型，判断是否激活
        /// </summary>
        private bool _but2bool;
        public bool But2bool
        {
            get { return _but2bool; }
            set { _but2bool = value; }
        }

        /// <summary>
        /// 按钮的边界宽度
        /// </summary>
        private System.Windows.Thickness _buttonThick;
        public System.Windows.Thickness ButtonThick
        {
            get => _buttonThick;
            set => SetProperty(ref _buttonThick, value);

        }

        /// <summary>
        /// 按钮1前景颜色
        /// </summary>
        private Brush? _bo1forBrush;
        public Brush? Bo1ForBrush
        {
            get => _bo1forBrush;
            set => SetProperty(ref _bo1forBrush, value);
        }

        /// <summary>
        /// 按钮1背景颜色
        /// </summary>
        private Brush? _bo1BackBrush;
        public Brush? Bo1BackBrush
        {
            get => _bo1BackBrush;
            set => SetProperty(ref _bo1BackBrush, value);
        }

        /// <summary>
        /// 按钮2前景颜色
        /// </summary>
        private Brush? _bo2forBrush;
        public Brush? Bo2ForBrush
        {
            get => _bo2forBrush;
            set => SetProperty(ref _bo2forBrush, value);
        }

        /// <summary>
        /// 按钮2背景颜色
        /// </summary>
        private Brush? _bo2BackBrush;
        public Brush? Bo2BackBrush
        {
            get => _bo2BackBrush;
            set => SetProperty(ref _bo2BackBrush, value);
        }

        /// <summary>
        /// 按钮的边界宽度
        /// </summary>
        private System.Windows.Thickness _button2Thick;
        public System.Windows.Thickness Button2Thick
        {
            get => _button2Thick;
            set => SetProperty(ref _button2Thick, value);

        }

        private ContentControl? _bookPlainPage;
        public ContentControl? BookPlainPage
        {
            get => _bookPlainPage;
            set => SetProperty(ref _bookPlainPage, value);
        }

        /// <summary>
        /// 主页书架按钮
        /// </summary>
        public ICommand MainBookShelvesCommand { get; }
        private void MainBookShelves()
        {
            ButtonThick = new System.Windows.Thickness(0, 0, 4, 0);
            Bo1ForBrush = ForBlueColor;
            Bo1BackBrush = BackGray2Color;
            //But1bool = true;
            BookPlainPage = BookShelve;
            //按钮2样式控制
            Button2Thick = new System.Windows.Thickness(0, 0, 0, 0);
            Bo2ForBrush = ForGrayColor;
            Bo2BackBrush = BackGray1Color;
            
        }

        public void OpenEditUI(int tag)
        {
            BookPlainPage = BookInforEvent.BookInforList[tag-1].CopyEditTextUI;
            CurrentBookSerialNumber = tag - 1;
            EditUI();
        }


        /// <summary>
        /// 主页编辑界面AddBookInformation
        /// </summary>
        public ICommand EditUICommand { get; }
        private void EditUI()
        {
            // 如果书籍集合有内容，才打开界面，否则提示还未创建书籍
            if (BookInforEvent.BookInforList.Count > 0)
            {
                Button2Thick = new System.Windows.Thickness(0, 0, 4, 0);
                Bo2ForBrush = ForBlueColor;
                Bo2BackBrush = BackGray2Color;
                //But2bool = true;
                //BookPlainPage = EditText;
                //按钮一样式控制
                ButtonThick = new System.Windows.Thickness(0, 0, 0, 0);
                Bo1ForBrush = ForGrayColor;
                Bo1BackBrush = BackGray1Color;
                //But1bool = false;

                BookPlainPage = BookInforEvent.BookInforList[CurrentBookSerialNumber].CopyEditTextUI;
            }
            else
            {
                MessageBox.Show("你还未创建一本书籍，请先创建书籍！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        

    }
}
