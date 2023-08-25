using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PersonalNovelist_Windows.Pages;

namespace PersonalNovelist_Windows.Data
{
    public class BookInformation
    {
        public BookInformation()
        {
            Items = new ObservableCollection<BookChapterItem>(); // 创建编辑控件
        }

        private string? bookName;
        /// <summary>
        /// 书籍名称
        /// </summary>
        public string? BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        
        private string? bookInstroduction;
        /// <summary>
        /// 书籍简介
        /// </summary>
        public string? BookInstroduction
        {
            get { return bookInstroduction;}
            set { bookInstroduction = value; }
        }


        private string? creationTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string? CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }


        private string? bookText;
        /// <summary>
        /// 书籍正文内容
        /// </summary>
        public string? BookText
        {
            get { return bookText; }
            set { bookText = value; }
        }


        private string? bookcoverpath;
        /// <summary>
        /// 封面路径
        /// </summary>
        public string? BookCoverpath
        {
            get { return bookcoverpath; }
            set { bookcoverpath = value; }
        }

        private string? bookauthor;
        /// <summary>
        /// 书籍作者
        /// </summary>
        public string? BookAuthor
        { 
            get { return bookauthor; }
            set { bookauthor = value; }
        }

        /// <summary>
        /// 书籍序号，第几本书
        /// </summary>
        private int serialNumber = 0;
        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        /// <summary>
        /// 编辑控件
        /// </summary>
        public ObservableCollection<BookChapterItem> Items;
    }

    /// <summary>
    /// 书籍章节Item
    /// </summary>
    public class BookChapterItem
    {
        public BookChapterItem()
        {
            ChildrenItems = new ObservableCollection<BookChapterItem>();
            IsExpanded = false;
        }

        //层级标题
        public string? Title { get; set; }

        public int NodeType { get; set; } // 节点类型，0 书名，1 卷名, 2 章节名
        public string? TextContent { get; set; }   // 文本内容

        public int FatherNode { get; set; } // 父节点
        public int SelfNode { get; set; } // 自己所在节点位置
        public bool IsExpanded { get; set; } // 是否展开
        //层级下面内容集合
        public ObservableCollection<BookChapterItem> ChildrenItems { get; set; }
    }
}
