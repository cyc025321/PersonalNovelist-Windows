using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNovelist_Windows.Data
{
    public class NumToChinese
    {

        //数字1-9转换为中文数字
        private static string OneBitNumberToChinese(string num)
        {
            string numStr = "123456789";
            string chineseStr = "一二三四五六七八九";
            string result = "";
            int numIndex = numStr.IndexOf(num);
            if (numIndex > -1)
            {
                result = chineseStr.Substring(numIndex, 1);
            }
            return result;
        }


        //阿拉伯数字转换为中文数字（0-99999）
        public static string NumberToChinese(int num)
        {
            int tem;
            string strNum = num.ToString();
            string result = "";
            if (strNum.Length == 5)
            {//万
                result += OneBitNumberToChinese(strNum[0..1]) + "万";
                strNum = strNum[1..2];
            }
            if (strNum.Length == 4)
            {//千
                string secondBitNumber = strNum[0..1];
                if (secondBitNumber == "0") result += "零";
                else result += OneBitNumberToChinese(secondBitNumber) + "千";
                strNum = strNum[1..2];
            }
            if (strNum.Length == 3)
            {//百
                string hundredBitNumber = strNum[0..1];
                tem = result.Length - 1;
                if (hundredBitNumber == "0" && result[tem..tem++] != "零") result += "零";
                else result += OneBitNumberToChinese(hundredBitNumber) + "百";
                strNum = strNum[1..2];
            }
            if (strNum.Length == 2)
            {//十
                string hundredBitNumber = strNum[0..1];
                tem = result.Length - 1;
                if (hundredBitNumber == "0" && result[tem..tem++] != "零") result += "零";
                else if (hundredBitNumber == "1" && string.IsNullOrEmpty(result)) result += "十";//10->十
                else result += OneBitNumberToChinese(hundredBitNumber) + "十";
                strNum = strNum[1..2];
            }
            if (strNum.Length == 1)
            {//个
                if (strNum == "0") result += "零";
                else result += OneBitNumberToChinese(strNum);
            }
            //100->一百零零
            if (!string.IsNullOrEmpty(result) && result != "零") result = result.TrimEnd('零');
            return result;
        }

    }
}
