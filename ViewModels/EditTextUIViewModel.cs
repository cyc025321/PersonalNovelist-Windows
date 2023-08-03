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
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FontFamily = System.Windows.Media.FontFamily;

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

            FontFamilyIndex = 0;
            FontFam = CustomFonts[FontFamilyIndex];
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
            // 根据选择的索引执行相应操作

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

    }
}
