﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonalNovelist_Windows.Data;
using PersonalNovelist_Windows.Pages;
using FontFamily = System.Windows.Media.FontFamily;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PersonalNovelist_Windows.ViewModels
{
    
    public class EditTextUIViewModel : ObservableObject, INotifyPropertyChanged
    {
        public EditTextUIViewModel()
        {
            FontItem = new ObservableCollection<string>
            {
                "宋体",
                "黑体",
                "正宋体",
                "正楷体",
                "小新黑体",
                "微软雅黑"

            };

            CustomFonts = new ObservableCollection<FontFamily>
            {
                new FontFamily("宋体"),
                new FontFamily("黑体"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#TW-Sung-Plus"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#TW-Kai"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#联想小新黑体 常规"),
                new FontFamily("微软雅黑")
            };
            FontSizeItem = new ObservableCollection<int>
            {
                12,14,16,18,20,22,24,26
            };
            AddVolumeCommand = new RelayCommand(AddVolume);
            FontFamilyIndex = 0;
            FontSizeIndex = 2;
            FontFam = CustomFonts[FontFamilyIndex];
            FontSize = FontSizeItem[FontSizeIndex];
            TitleFontSize = CalculatedTitFontSize(FontSize);

            Items = new ObservableCollection<BookChapterItem>();
            //VolumeBool = false;
            //VolumeCurrentNum = 0;
        }
        /// <summary>
        /// 书籍序号
        /// </summary>
        private int editSerialNumber = 0;
        public int EditSerialNumber
        {
            get { return editSerialNumber; }
            set 
            { 
                if (value == 0)
                {
                    editSerialNumber = value;
                    ChangeItems(value);
                }
                else if (value != editSerialNumber)
                {
                    editSerialNumber = value;
                    ChangeItems(value);
                }
            }
        }

        /// <summary>
        /// 更改Items方法
        /// </summary>
        private void ChangeItems(int Num)
        {
            Items = BookInforEvent.BookInforList[Num].Items;
        }

        /// <summary>
        /// 选中treeview节点事件
        /// </summary>
        private BookChapterItem? selectedItem;
        public BookChapterItem? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                //OnPropertyChanged(nameof(SelectedItem));
            }
        }

        /// <summary>
        /// 初始化界面，treeview的第一个层级title
        /// </summary>
        public void UpdateItems(string bookname)
        {
            Bookname = bookname;
            Items!.Add(new BookChapterItem() { Title = bookname, NodeType=0, FatherNode=0, SelfNode=0});
            Items[0].IsExpanded = true; // 展开
        }

        /// <summary>
        /// Treeview数据集
        /// </summary>
        private ObservableCollection<BookChapterItem>? _items;
        public ObservableCollection<BookChapterItem>? Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        //private bool VolumeBool; // 是否有卷，层级
        //private int VolumeCurrentNum { set; get; }
        private int curVolumeNum;
        private int curChaterNum;
        public int CurVolumeNum { get => curVolumeNum; set => curVolumeNum = value; }
        public int CurChaterNum { get => curChaterNum; set => curChaterNum = value; }

        private int aa = 0;
        /// <summary>
        /// 添加卷，按钮点击事件
        /// </summary>
        public ICommand AddVolumeCommand { get; }
        private void AddVolume()
        {
            if (InputVolChaName !=  null)
            {
                int len = Items![0].ChildrenItems.Count; // 获取集合长度
                string tem = NumToChinese.NumberToChinese(len+1);
                Items![0].ChildrenItems.Add(new BookChapterItem() { Title ="第" + tem + "卷:" + InputVolChaName, 
                    TextContent = Convert.ToString(aa),
                    NodeType=1, FatherNode=0, SelfNode=len});
                aa++;
                BookInforEvent.BookInforList[EditSerialNumber].Items = Items;
                InputVolChaName = null;
            }

        }

        private string? _selectText;
        public string? SelectText
        {
            get => _selectText;
            set => SetProperty(ref _selectText, value);
        }

        /// <summary>
        /// 输入卷名
        /// </summary>
        private string? _inputVolChaName;
        public string? InputVolChaName
        {
            get => _inputVolChaName;
            set => SetProperty(ref _inputVolChaName, value);
        }

        // 章节目录，第一层书籍名字
        public string? Bookname;
        /// <summary>
        /// 字体实物集合
        /// </summary>
        public ObservableCollection<FontFamily> CustomFonts { get; set; }

        /// <summary>
        /// Combox字体绑定集合
        /// </summary>
        private ObservableCollection<string>? _fontItem;
        public ObservableCollection<string>? FontItem
        {
            get => _fontItem;
            set => SetProperty(ref _fontItem, value);
        }

        /// <summary>
        /// 字体
        /// </summary>
        private FontFamily? fontfam;
        public FontFamily? FontFam
        {
            get => fontfam;
            set => SetProperty(ref fontfam, value);
        }

        
        /// <summary>
        /// 更改字体方法
        /// </summary>
        /// <param name="index">字体Combox索引值</param>
        private void OnFontChanged(int? index)
        {
            switch (index)
            {
                case 0:
                    FontFam = CustomFonts[0];
                    break;
                case 1:
                    FontFam = CustomFonts[1];
                    break;
                case 2:
                    FontFam = CustomFonts[2];
                    break;
                case 3:
                    FontFam = CustomFonts[3];
                    break;
                case 4:
                    FontFam = CustomFonts[4];
                    break;
                case 5:
                    FontFam = CustomFonts[5];
                    break;
            }
        }

        /// <summary>
        /// 字体索引修改时的变化事件
        /// </summary>
        private int _fontFamilyIndex;
        public int FontFamilyIndex
        {
            get => _fontFamilyIndex;
            set 
            {
                _fontFamilyIndex = value;
                
                OnFontChanged(value); // 更改字体
                OnPropertyChanged(); // 通知属性更改
            }
        }

        /// <summary>
        /// ComBox字体尺寸集合
        /// </summary>
        private ObservableCollection<int>? _fontSizeItem;
        public ObservableCollection<int>? FontSizeItem
        {
            get => _fontSizeItem;
            set => SetProperty(ref _fontSizeItem, value);
        }


        /// <summary>
        /// 字体尺寸索引修改时的变化事件
        /// </summary>
        private int _fontSizeIndex;
        public int FontSizeIndex
        {
            get => _fontSizeIndex;
            set
            {
                _fontSizeIndex = value;

                OnFontSizeChanged(value); // 更改字体
                OnPropertyChanged(); // 通知属性更改
            }
        }

        /// <summary>
        /// 字体尺寸
        /// </summary>
        private int _fontSize;
        public int FontSize
        { 
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }

        /// <summary>
        /// 更改字体尺寸方法
        /// </summary>
        /// <param name="index">字体Combox索引值</param>
        private void OnFontSizeChanged(int index)
        {
            if (FontSizeItem != null)
            {
                switch (index)
                {
                    case 0:
                        FontSize = FontSizeItem[0];
                        break;
                    case 1:
                        FontSize = FontSizeItem[1];
                        break;
                    case 2:
                        FontSize = FontSizeItem[2];
                        break;
                    case 3:
                        FontSize = FontSizeItem[3];
                        break;
                    case 4:
                        FontSize = FontSizeItem[4];
                        break;
                    case 5:
                        FontSize = FontSizeItem[5];
                        break;
                    case 6:
                        FontSize = FontSizeItem[6];
                        break;
                    case 7:
                        FontSize = FontSizeItem[7];
                        break;
                }
                TitleFontSize = CalculatedTitFontSize(FontSize);
            }
            else
            {
                MessageBox.Show("设置错误", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }

        /// <summary>
        /// 标题字体尺寸
        /// </summary>
        private int _titleFontSize;
        public int TitleFontSize
        {
            get => _titleFontSize;
            set => SetProperty(ref _titleFontSize, value);
        }

        /// <summary>
        /// 计算标题字体尺寸
        /// </summary>
        /// <param name="textfontsize">文本字体尺寸</param>
        /// <returns></returns>
        private static int CalculatedTitFontSize(int textfontsize)
        {
            if (textfontsize % 3 != 0)
            {
                double tem = textfontsize / 3;
                return textfontsize + (int)Math.Floor(tem);
            }
            else
            {
                return textfontsize + textfontsize / 3;
            }
        }

        private string? _titleName;
        

        public string? TitleName
        {
            get => _titleName;
            set
            {
                SetProperty(ref _titleName, value);
            }
        }
    }
}
