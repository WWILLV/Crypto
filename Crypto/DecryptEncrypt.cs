using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Crypto
{
    /// <summary>
    /// 加解密类
    /// </summary>
    static public class DecryptEncrypt
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="text">要加密的原文</param>
        /// <returns>md5密文</returns>
        static public string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }

        /// <summary>
        /// 16位MD5
        /// </summary>
        /// <param name="str">要加密的原文</param>
        /// <returns>16位md5密文</returns>
        static public string md5_16(string str)
        {
            return md5(str).Remove(24).Remove(0, 8);
        }

        /// <summary>
        /// 异或加解密(慎用,加密后密文基本无法显示，建议用Base加密一次)
        /// </summary>
        /// <param name="str">明文或密文</param>
        /// <param name="key">密钥</param>
        /// <param name="isB64">返回是否需要Base64加密（加密建议true）</param>
        /// <returns></returns>
        static public string xor(string str, string key, bool isB64)
        {
            string result = "";
            while (key.Length < str.Length)   //key比str短，key循环异或（123->123123123)以比较
            {
                key += key;
            }
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                buffer.Append((char)(str[i] ^ key[i]));
            }
            result = buffer.ToString();
            if (isB64)
                return Code.Base64Encode(result);
            else
                return result;
        }

        #region 凯撒维吉尼亚系列

        /// <summary>
        /// 凯撒加解密
        /// </summary>
        /// <param name="str">要加密或解密的字符串</param>
        /// <param name="digits">移位的位数</param>
        /// <param name="symbol">是否带符号移位</param>
        /// <returns></returns>
        static public string caesar(string str, int digits, bool symbol)
        {
            //a-z:97-122;A-Z:65-90;0-9:48-57
            string output = "";
            int length = str.Length;
            if (symbol) //带符号加解密
            {
                for (int i = 0; i < length; i++)
                {
                    char temp = str[i];
                    temp = (char)(temp + digits);
                    output += temp;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    char temp = str[i];
                    int asciinum = temp + digits;
                    if (temp < 58 && temp > 47) //数字
                    {
                        if (asciinum > 77)
                            asciinum = asciinum - 30;
                        if (asciinum > 67)
                            asciinum = asciinum - 20;
                        if (asciinum > 57)
                            asciinum = asciinum - 10;
                    }
                    else if (temp < 91 && temp > 64) //A-Z
                    {
                        if (asciinum > 90)
                            asciinum = asciinum - 26;
                    }
                    else if (temp < 123 && temp > 96) //a-z
                    {
                        if (asciinum > 122)
                            asciinum = asciinum - 26;
                    }
                    else //对不是字母和阿拉伯数字的字符保留
                    {
                        asciinum = temp;
                    }
                    temp = (char)(asciinum);
                    output += temp;
                }
            }
            return output;
        }

        /// <summary>
        /// 凯撒加解密(默认不包括符号)
        /// </summary>
        /// <param name="str">要加密或解密的字符串</param>
        /// <param name="digits">移位的位数</param>
        /// <returns></returns>
        static public string caesar(string str, int digits)
        {
            return caesar(str, digits, false);
        }

        /// <summary>
        /// Rot13加解密
        /// </summary>
        /// <param name="str">要加解密的字符串</param>
        /// <returns></returns>
        static public string rot13(string str)
        {
            return caesar(str, 13);
        }

        /// <summary>
        /// 维吉尼亚加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        static public string vigenereEncrypt(string str, string key)
        {
            str = str.ToUpper();
            key = key.ToUpper();
            char[,] vigenereTable = new char[26, 26];
            string result = "";
            for (char i = 'A'; i < 'Z'; i++)    //生成密码表
            {
                int row = i - 'A';
                for (int j = 0; j < 25; j++)
                {
                    char add = (char)(i + j);
                    if (add <= 'Z')
                        vigenereTable[row, j] = add;
                    else
                        vigenereTable[row, j] = (char)((int)add - 26);

                }
            }
            while (key.Length < str.Length)   //密钥长度短于密文，加长符合要求
            {
                key += key;
            }
            for (int i = 0,k=0; i < str.Length; i++,k++)
            {
                if (str[i] == ' ')  //跳过空格
                {
                    result += ' ';
                    k--;
                }
                else
                    result += vigenereTable[key[k] - 'A', str[i] - 'A'];
            }
            return result;
        }

        /// <summary>
        /// 维吉尼亚解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        static public string vigenereDecrypt(string str, string key)
        {
            str = str.ToUpper();
            key = key.ToUpper();
            char[,] vigenereTable = new char[26, 26];
            string result = "";
            for (char i = 'A'; i < 'Z'; i++)    //生成密码表
            {
                int row = i - 'A';
                for (int j = 0; j < 25; j++)
                {
                    char add = (char)(i + j);
                    if (add <= 'Z')
                        vigenereTable[row, j] = add;
                    else
                        vigenereTable[row, j] = (char)((int)add - 26);

                }
            }
            while (key.Length < str.Length)   //密钥长度短于密文，加长符合要求
            {
                key += key;
            }
            for (int i = 0, k = 0; i < str.Length; i++, k++)
            {
                if (str[i] == ' ')  //跳过空格
                {
                    result += ' ';
                    k--;
                }
                else
                {
                    int set = 0;
                    for (int j = 0; j < 25; j++)
                    {
                        if (vigenereTable[key[k] - 'A', j] ==str[i])
                            set = j;
                    }
                    result += vigenereTable[0,set];
                }
            }
            return result;
        }

        #endregion

        #region AES-128

        /// <summary>
        /// 随机生成密钥向量
        /// </summary>
        /// <param name="n">位数</param>
        /// <returns></returns>
        public static string getIv(int n)
        {
            char[] arrChar = new char[]{
           'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x',
           '0','1','2','3','4','5','6','7','8','9',
           'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z'
          };

            StringBuilder num = new StringBuilder();

            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }

            return num.ToString();
        }

        /// <summary>
        /// 128位AES加密（CBC模式PKCS7填充）
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <param name="key">密码</param>
        /// <param name="iv">密钥向量</param>
        /// <returns></returns>
        public static string AESEncrypt_CBC(string encryptStr, string key, string iv)
        {
            int size = 128;
            int bytesNum = size / 8;
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = size;
            rijndaelCipher.BlockSize = 128;

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[bytesNum];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = ivBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(encryptStr);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// 128位AES解密（CBC模式PKCS7填充）
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密码</param>
        /// <param name="iv">密钥向量</param>
        /// <returns></returns>
        public static string AESDecrypt_CBC(string decryptStr, string key, string iv)
        {
            int size = 128;
            int bytesNum = size / 8;
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;   //CBC加密模式
            rijndaelCipher.Padding = PaddingMode.PKCS7; //PKCS7填充
            rijndaelCipher.KeySize = size;
            rijndaelCipher.BlockSize = 128;

            byte[] encryptedData = Convert.FromBase64String(decryptStr);
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[bytesNum];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = ivBytes;
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        /// <summary>  
        /// 128位AES加密(ECB)
        /// </summary>  
        /// <param name="encryptStr">明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns></returns>  
        public static string AESEncrypt_ECB(string encryptStr, string key)
        {
            if (key.Length != 16) throw new Exception("密钥位数错误");
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        /// <summary>
        /// 128位AES解密(ECB)
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string AESDecrypt_ECB(string decryptStr, string key)
        {
            if (key.Length != 16) throw new Exception("密钥位数错误");
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion

        #region 培根加密

        static private string[] baconArray = { "AAAAA", "AAAAB", "AAABA", "AAABB", "AABAA", "AABAB",
        "AABBA","AABBB","ABAAA","ABAAA","ABAAB","ABABA","ABABB","ABBAA","ABBAB","ABBBA","ABBBB",
        "BAAAA","BAAAB","BAABA","BAABB","BAABB","BABAA","BABAB","BABBA","BABBB"};

        /// <summary>
        /// 培根加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns>密文</returns>
        static public string baconEncrypt(string str)
        {
            str = str.ToUpper();
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch >= 'A' && ch <= 'Z')
                {
                    result += baconArray[ch - 'A'];
                }
                else
                    throw new Exception("输入有误");
            }
            return result;
        }

        /// <summary>
        /// 培根解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="ab">原文是否只含AB(若false将进行转换，默认大写为A)</param>
        /// <returns>明文</returns>
        static public string baconDecrypt(string str, bool ab)
        {
            str = str.Replace(" ", "");
            if (str.Length % 5 != 0)
                throw new Exception("输入长度有误，应为5的倍数！");
            if (!ab)    //大小写分别替换为AB
            {
                char[] str1 = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    char s = str[i];
                    if (s >= 'A' && s <= 'Z')
                        str1[i] = 'A';
                    else if (s >= 'a' && s <= 'z')
                        str1[i] = 'B';
                    else
                        throw new Exception("非法输入！");
                }
                str = str1.ToString();
            }
            string result = "";
            string temp = "";   //5个一组保存密文
            for (int i = 0; i < str.Length; i = i + 5)
            {
                temp = "";
                for (int j = i; j < i + 5; j++)
                {
                    temp += str[j];
                }
                for (int j = 0; j < baconArray.Length; j++)
                {
                    //IJ和UV存在重复
                    if (temp == "ABAAA")
                    {
                        result += "I(J)";
                        break;
                    }
                    if (temp == "BAABB")
                    {
                        result += "U(V)";
                        break;
                    }
                    if (temp == baconArray[j])
                    {
                        result += Convert.ToChar('A' + j);
                        break;
                    }
                }
            }
            return result;
        }

        #endregion

        #region 栅栏密码

        /// <summary>
        /// 获得栅栏数
        /// </summary>
        /// <param name="str">栅栏密码原文</param>
        /// <returns>包含所有可做栅栏数的int数组</returns>
        static public int[] fenceGetNum(string str)
        {
            str = str.Replace(" ", "");
            int length = str.Length;
            int[] result;
            Stack<int> s = new Stack<int> { };
            //分解因数
            for (int i = 2; i < System.Math.Sqrt(length); i++)  //博扬大佬说到开根号就行了
            {
                if (length % i == 0)
                {
                    s.Push(i);
                }
            }
            result = s.Reverse().ToArray();
            return result;
        }

        /// <summary>
        /// 栅栏密码加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="num">栅栏数</param>
        /// <returns></returns>
        static public string fenceEncrypt(string str, int num)
        {
            /*
             * 明文：THERE IS A CIPHER
             * 七个一组：THEREIS ACIPHER
             * 抽取字母：TA HC EI RP EH IE SR
             * 组合得到密码：TAHCEIRPEHIESR
             */
            str = str.Replace(" ", "");
            if (str.Length % num != 0)
            {
                throw new Exception("栅栏数错误");
            }
            int cp = str.Length / num;  //可分的组数
            string[] temp = new string[cp]; //保存分组
            for (int i = 0; i < cp; i++)    //为分组复制
            {
                for (int j = 0; j < num; j++)
                {
                    temp[i] += str[i * num + j];
                }
            }
            string result = "";
            //抽取字母
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < cp; j++)
                {
                    result += temp[j][i];
                }
            }
            return result;
        }

        /// <summary>
        /// 栅栏密码解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="num">栅栏数</param>
        /// <returns></returns>
        static public string fenceDecrypt(string str, int num)
        {
            str = str.Replace(" ", "");
            if (str.Length % num != 0)
            {
                throw new Exception("栅栏数错误");
            }
            return fenceEncrypt(str, str.Length / num);
        }

        /// <summary>
        /// 栅栏密码加密(未知栅栏数，自动计算，返回第一个可分的结果)
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns></returns>
        static public string fenceEncrypt(string str)
        {
            int[] num = fenceGetNum(str);
            if (num.Length == 0)
            {
                throw new Exception("密文长度无法进行栅栏密码解密");
            }
            else
                return fenceEncrypt(str, num[0]);
        }

        /// <summary>
        /// 栅栏密码解密(未知栅栏数，自动计算，返回第一个可分的结果）
        /// </summary>
        /// <param name="str">密文</param>
        /// <returns></returns>
        static public string fenceDecrypt(string str)
        {
            int[] num = fenceGetNum(str);
            if (num.Length == 0)
            {
                throw new Exception("密文长度无法进行栅栏密码解密");
            }
            else
                return fenceDecrypt(str, num[0]);
        }

        #endregion

    }
}
