using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PersonalNovelist_Windows.ViewModels;
using DataFormats = System.Windows.DataFormats;
using DataObject = System.Windows.DataObject;
using UserControl = System.Windows.Controls.UserControl;

namespace PersonalNovelist_Windows.Pages
{
    /// <summary>
    /// EditTextUI.xaml 的交互逻辑
    /// </summary>
    public partial class EditTextUI : UserControl
    {
        public EditTextUIViewModel viewModel;
        public EditTextUI()
        {
            InitializeComponent();
            viewModel = new();
            DataContext = viewModel;
            DataObject.AddPastingHandler(EditorText, TextBoxPasting); //处理粘贴命令
            
        }
        

        // 处理粘贴命令
        private static void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            e.DataObject = new DataObject(DataFormats.UnicodeText, e.DataObject.GetData(DataFormats.UnicodeText) as string ?? string.Empty);
            
        }

    }
}
