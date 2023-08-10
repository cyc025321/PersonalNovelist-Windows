using System;
using System.Collections.Generic;
using System.Linq;
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
            CopyEditTextUI = new(); // 创建编辑控件
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
        public EditTextUI? CopyEditTextUI;
        
    }
}
