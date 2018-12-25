using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Crypto
{
    /// <summary>
    /// 编解码类
    /// </summary>
    public class Code
    {
        #region Base64/32

        /// <summary>
        /// base64解密
        /// </summary>
        /// <param name="text">要解密的密文</param>
        /// <returns>原文</returns>
        static public string Base64Decode(string str)  //base64->string
        {
            try
            {
                return System.Text.ASCIIEncoding.Default.GetString(Convert.FromBase64String(str));
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="str">要加密的原文</param>
        /// <returns>Base64密文</returns>
        static public string Base64Encode(string str)  //string->base64
        {
            try
            {
                System.Text.Encoding encode = System.Text.Encoding.ASCII;
                byte[] bytedata = encode.GetBytes(str);
                return Convert.ToBase64String(bytedata, 0, bytedata.Length);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// base32加密
        /// </summary>
        /// <param name="str">要加密的原文</param>
        /// <returns>Base32密文</returns>
        public static string Base32Encode(string str)
        {
            var bin = "";
            foreach (var _ in str.Select(c => Convert.ToString(c, 16)))
            {
                bin += Convert.ToString(Convert.ToInt32(_[0] + "", 16), 2).PadLeft(4, '0');
                bin += Convert.ToString(Convert.ToInt32(_[1] + "", 16), 2).PadLeft(4, '0');
            }
            while (bin.Length % 5 != 0)
            {
                bin += '0';
            }

            var bins = new string[bin.Length / 5];
            for (var i = 0; i < bins.Length; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    bins[i] += bin[i * 5 + j];
                }
            }

            str = "";
            foreach (var n in bins.Select(t => Convert.ToInt32(t, 2)))
            {
                if (n < 26)
                {
                    str += (char)(n + 0x41);
                }
                else
                {
                    str += (char)(n + 0x32 - 26);
                }
            }

            while (str.Length % 8 != 0)
            {
                str += '=';
            }

            return str;
        }

        /// <summary>
        /// base32解密
        /// </summary>
        /// <param name="str">要解密的密文</param>
        /// <returns>原文</returns>
        public static string Base32Decode(string str)
        {
            str = Regex.Replace(str, "=", "");
            var bin = "";
            foreach (var t in str)
            {
                var n = 0;
                if (t < 0x38)
                {
                    n = t - 0x30 + 24;
                }
                else
                {
                    n = t - 0x41;
                }
                bin += Convert.ToString(n, 2).PadLeft(5, '0');
            }

            while (bin.Length % 4 != 0 && bin[bin.Length - 1].Equals('0'))
            {
                bin = bin.Remove(bin.Length - 1);
            }

            var s = "";

            for (var i = 0; i < bin.Length / 4; i++)
            {
                var _ = "";
                for (var j = 0; j < 4; j++)
                {
                    _ += bin[i * 4 + j];
                }
                s += Convert.ToString(Convert.ToInt32(_, 2), 16);
            }

            str = "";

            for (var i = 0; i < s.Length / 2; i++)
            {
                var _ = s[i * 2] + "" + s[i * 2 + 1];
                str += (char)Convert.ToInt32(_, 16);
            }

            return str;
        }

        #endregion

        #region Morse

        /* Morse表
            A	．━	B	━ ．．．	C	━ ．━ ．	D	━ ．．
            E	．	F	．．━ ．	G	━ ━ ．	H	．．．．
            I	．．	J	．━ ━ ━	K	━ ．━	L	．━ ．．
            M	━ ━	N	━ ．	O	━ ━ ━	P	．━ ━ ．
            Q	━ ━ ．━	R	．━ ．	S	．．．	T	━
            U	．．━	V	．．．━	W	．━ ━	X	━ ．．━
            Y	━ ．━ ━	Z	━ ━ ．．
            0	━ ━ ━ ━ ━	1	．━ ━ ━ ━	2	．．━ ━ ━	3	．．．━ ━
            4	．．．．━	5	．．．．．	6	━ ．．．．	7	━ ━ ．．．
            8	━ ━ ━ ．．	9	━ ━ ━ ━ ．
         */

        //字母morse表
        private static string[] morseDistAlphabet = {"01","1000","1010","100",
        "0","0010","110","0000","00","0111","101","0100","11","10","111","0110",
        "1101","010","000","1","001","0001","011","1001","1011","1100"};
        //数字morse表
        private static string[] morseDistNumber = { "11111","01111","00111","00011",
        "00001","00000","10000","11000","11100","11110"};
        //符号morse表（暂时不考虑）
        private static string[] morseDistSymbol = { "" };

        /// <summary>
        /// 摩斯解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="separated">分隔符</param>
        /// <returns>原文</returns>
        static public string morseDecode(string str, char separated)
        {
            //替换为标准格式
            str = str.Replace('.', '0');
            str = str.Replace('-', '1');
            str = str.Replace(separated, '/');
            string morse = "";
            //temp保存每一段的morse密码
            string temp = "";
            for (int i = 0; i < str.Length; i = i + (temp.Length + 1))
            {
                temp = "";
                int p = i;  //p为一个指针
                //do-while循环在把temp逐渐取为每一段的值时检查下一个字符是否为分隔符或结尾
                do
                {
                    temp += str[p];
                    p++;
                } while (str[p] != '/' && p != str.Length - 1);
                if (temp == "") //temp为空说明该段结束，检查下一段
                    continue;
                //当最后一个字符不为分隔符时temp加上最后一个字符（上面的循环不会加上最后一个字符）
                if (p == str.Length - 1 && str[p] != '/')
                    temp += str[p];
                if (temp.Length == 5)  //temp长度为5即为数字
                {
                    for (int j = 0; j < morseDistNumber.Length; j++)
                    {
                        if (temp == morseDistNumber[j]) //当匹配成功直接j就是数字值（从0保存的数字morse）
                        {
                            morse += (j).ToString();
                            break;
                        }
                    }
                }
                else if (temp.Length < 5)   //temp<5为字母
                {
                    for (int j = 0; j < morseDistAlphabet.Length; j++)
                    {
                        if (temp == morseDistAlphabet[j])   //匹配成功后需要加65直接转换为对应ASCII码（加密时减了65）
                        {
                            morse += Convert.ToChar(j + 65);
                            break;
                        }
                    }
                }
                else    //暂时没有考虑带符号或其他情况
                {
                    throw (new Exception("非正规的morse密码（暂时只支持字母和数字）"));
                }
            }
            return morse;
        }

        /// <summary>
        /// 摩斯加密(分隔符为/)
        /// </summary>
        /// <param name="str">原文</param>
        /// <returns>密文</returns>
        static public string morseEncode(string str)
        {
            string morse = "";
            str = str.ToUpper();    //morse不区分大小写，统一为大写
            for (int i = 0; i < str.Length; i++)
            {
                //逐字符替换
                char ch = str[i];
                if (ch > 64 && ch < 91)    //字母
                {
                    morse += morseDistAlphabet[ch - 65];
                }
                if (ch > 47 && ch < 58)    //数字
                {
                    morse += morseDistNumber[ch - 48];
                }
                morse += "/";
            }
            //转换为标准格式
            morse = morse.Replace('0', '.');
            morse = morse.Replace('1', '-');
            return morse.Remove(morse.Length - 1);  //最后一位有一个/,去掉
        }
        #endregion

        #region URL

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str">要编码的内容</param>
        /// <returns>URL编码</returns>
        static public string UrlEncode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str">要编码的内容</param>
        /// <param name="code">返回编码类型（1、Unicode 2、UTF-8 3、GB2312）</param>
        /// <returns>URL编码</returns>
        static public string UrlEncode(string str,int code)
        {
            if (code == 1)
                return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.Unicode);
            else if (code == 2)
                return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
            else if (code == 3)
                return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("GB2312 "));
            else
                return "";
        }
        
        /// <summary>
        /// URL解码 
        /// </summary>
        /// <param name="str">URL编码</param>
        /// <returns>解码的内容</returns>
        static public string UrlDecode(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="str">URL编码</param>
        /// <param name="code">返回编码类型（1、Unicode 2、UTF-8 3、GB2312）</param>
        /// <returns>解码的内容</returns>
        static public string UrlDecode(string str,int code)
        {
            if (code == 1)
                return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.Unicode);
            else if (code == 2)
                return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.UTF8);
            else if (code == 3)
                return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.GetEncoding("GB2312 "));
            else
                return "";
        }

        #endregion

        #region ASCII String Unicode
        
        /// <summary>  
        /// 字符串转为UniCode码字符串  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string StringToUnicode(string str)
        {
            char[] charbuffers = str.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// Unicode字符串转为正常字符串  
        /// </summary>  
        /// <param name="srcText"></param>  
        /// <returns></returns>  
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }

        /// <summary>
        /// 字符串转ASCII
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>ASCII</returns>
        public static byte[] StringToASCII(string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        /// <summary>
        /// ASCII转字符串
        /// </summary>
        /// <param name="buf">ASCII</param>
        /// <returns>字符串</returns>
        public static string ASCIIToString(byte[] buf)
        {
            return System.Text.Encoding.ASCII.GetString(buf);
        }

        #endregion

    }
}
