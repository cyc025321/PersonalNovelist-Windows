using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNovelist_Windows.Data
{
    internal class BookInformation
    {
        private string? bookName;

        public string? BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        private string? bookInstroduction;
        public string? BookInstroduction
        {
            get { return bookInstroduction;}
            set { bookInstroduction = value; }
        }

        private string? creationTime;
        public string? CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }


        private string? bookText;
        public string? BookText
        {
            get { return bookText; }
            set { bookText = value; }
        }
    }
}
