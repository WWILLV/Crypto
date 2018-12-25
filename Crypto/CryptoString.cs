using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crypto
{
    public class CryptoString
    {
        /// <summary>
        /// 常用字符串
        /// </summary>
        public struct commonString
        {
            /// <summary>
            /// 数字列表
            /// </summary>
            static public string num = "0123456789";
            /// <summary>
            /// 小写字母列表
            /// </summary>
            static public string lowAlpha = "abcdefghijklmnopqrstuvwxyz";
            /// <summary>
            /// 大写字母列表
            /// </summary>
            static public string upAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            /// <summary>
            /// 数字和大小写字母
            /// </summary>
            static public string numAlpha = num + lowAlpha + upAlpha;
        }
        
        /// <summary>
        /// 随机生成字符串
        /// </summary>
        /// <param name="n">字符串长度</param>
        /// <param name="_chars">字符串内容，默认所有数字和大小写字母</param>
        /// <returns></returns>
        static public string randomString(int n, 
            string _chars = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM")
        {
            Random r = new Random();
            char[] buffer = new char[n];
            for (int i = 0; i < n; i++)
            {
                buffer[i] = _chars[r.Next(_chars.Length)];
            }
            return new string(buffer);
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        static public string reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        #region 字符串，字节数组，流操作
        /// <summary>
        /// 字符串到字节数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public byte[] stringToBytes(string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }

        /// <summary>
        /// 字节数组到字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static public string bytesToString(byte[] bytes)
        {
            return System.Text.Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 字符串到流
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public System.IO.MemoryStream stringToStream(string str)
        {
            return new System.IO.MemoryStream(stringToBytes(str));
        }

        /// <summary>
        /// 字节数组到流
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static public System.IO.MemoryStream bytesToStream(byte[] bytes)
        {
            return new System.IO.MemoryStream(bytes);
        }
        
        /// <summary>
        /// 流到字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        static public string streamToString(System.IO.MemoryStream stream)
        {
            return System.Text.Encoding.Default.GetString(stream.ToArray());
        }

        /// <summary>
        /// 流到字节数组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        static public byte[] streamToBytes(System.IO.MemoryStream stream)
        {
            return stream.ToArray();
        }
        #endregion

        #region 正则表达式
        
        /// <summary>
        /// 常用正则表达式
        /// </summary>
        public struct commonRegular
        {
            /// <summary>
            /// 数字
            /// </summary>
            static public string regNum = "^[0-9]*$";
            /// <summary>
            /// 汉字
            /// </summary>
            static public string regChinese = "^[\u4e00-\u9fa5]{0,}$";
            /// <summary>
            /// 字母
            /// </summary>
            static public string regAlpha = "^[A-Za-z]+$";
            /// <summary>
            /// 小写字母
            /// </summary>
            static public string regLowAlpha = "^[a-z]+$";
            /// <summary>
            /// 大写字母
            /// </summary>
            static public string regUpAlpha = "^[A-Z]+$";
            /// <summary>
            /// 邮箱
            /// </summary>
            static public string regEmail = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            /// <summary>
            /// Url
            /// </summary>
            static public string regUrl = @"[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(/.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+/.?";
            /// <summary>
            /// 手机号
            /// </summary>
            static public string regMobile = @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";
            /// <summary>
            /// 身份证号
            /// </summary>
            static public string regId = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";
            /// <summary>
            /// 空白行
            /// </summary>
            static public string regBlank = @"\n\s*\r";
            /// <summary>
            /// Xml
            /// </summary>
            static public string regXml = "^([a-zA-Z]+-?)+[a-zA-Z0-9]+\\.[x|X][m|M][l|L]$";
            /// <summary>
            /// Html
            /// </summary>
            static public string regHtml = @"<(\S*?)[^>]*>.*?|<.*? />";
            /// <summary>
            /// Ip地址
            /// </summary>
            static public string regIp = @"((?:(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d))";
            /// <summary>
            /// 国内邮政编码
            /// </summary>
            static public string regZipcode = @"[1-9]\d{5}(?!\d)";
        }

        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="regexStr">正则表达式</param>
        /// <returns></returns>
        static public bool isMarch(string str,string regexStr)
        {
            return Regex.IsMatch(str, regexStr);
        } 

        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="regexStr">正则表达式</param>
        /// <returns>匹配到的字符串数组</returns>
        static public string[] match(string str,string regexStr)
        {
            List<string> list = new List<string> { };
            Match ma = Regex.Match(str, regexStr);
            for (int i = 0; i < ma.Groups.Count; i++)
            {
                list.Add(ma.Groups[i].Value);
            }
            return list.ToArray();
        }

        #endregion
    }
}
