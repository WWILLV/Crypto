using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    /// <summary>
    /// 进制转换类
    /// </summary>
    public class Conversion
    {
        static private char[] wordArray = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };  //最高支持到62进制

        /// <summary>
        /// 十进制转任意进制
        /// </summary>
        /// <param name="dec">要转换的值</param>
        /// <param name="digit">>转换的进制数</param>
        /// <returns></returns>
        static private string decToAny(string dec,int digit)
        {
            string result = "";
            if (digit == 10)
            {
                return dec;
            }
            else if (digit < 2)
                return "";
            int value = Convert.ToInt32(dec);
            Stack<int> yu = new Stack<int> { };
            while (value>0)
            {
                yu.Push(value % digit);
                value = value / digit;
            }
            while (yu.Count()>0)
            {
                result += wordArray[yu.Pop()];
            }
            return result;
        }

        /// <summary>
        /// 任意进制转十进制
        /// </summary>
        /// <param name="any">要转换的值</param>
        /// <param name="digit">转换的进制数</param>
        /// <returns></returns>
        static private string anyToDec(string any,int digit)
        {
            string result = "";
            if (digit == 10)
            {
                return any;
            }
            else if (digit < 2)
                return "";
            if (digit < 37) //小于37位的进制转换强制将输入的字母转为大写
                any = any.ToUpper();
            int dec = 0;
            for (int i = any.Length-1,k=0; i >= 0; i--,k++) //i为从后到前的游标，k为幂指数
            {
                for (int j = 0; j < wordArray.Length; j++)  //j为进制表中数的位置，即相对应的值对应的10进制的值
                {
                    if(wordArray[j]==any[i])
                    {
                        dec = dec + j*(int)System.Math.Pow(digit, k);
                        break;
                    }
                }
            }
            result = dec.ToString();
            return result;
        }

        /// <summary>
        /// 任意进制转换
        /// </summary>
        /// <param name="str">要转换的值</param>
        /// <param name="convertIn">现在的进制</param>
        /// <param name="convertOut">要转换的进制</param>
        /// <returns></returns>
        static public string convert(string str,int convertIn,int convertOut)
        {
            if (convertIn == 10)
                return decToAny(str, convertOut);
            else if (convertOut == 10)
                return anyToDec(str, convertIn);
            else
                return decToAny(anyToDec(str, convertIn), convertOut);
        }

    }
}
