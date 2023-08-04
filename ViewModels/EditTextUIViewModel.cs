using System;
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
                "正宋体",
                "黑体",
                "小新黑体",
                "正楷体"
            };

            CustomFonts = new ObservableCollection<FontFamily>
            {
                new FontFamily("宋体"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#TW-Sung-Plus"),
                new FontFamily("黑体"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#联想小新黑体 常规"),
                new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#TW-Kai")

        };
            FontSizeItem = new ObservableCollection<int>
            {
                12,14,16,18,20,22,24,26
            };

            FontFamilyIndex = 0;
            FontSizeIndex = 2;
            FontFam = CustomFonts[FontFamilyIndex];
            FontSize = FontSizeItem[FontSizeIndex];
        }

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
            }
            else
            {
                MessageBox.Show("设置错误", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
