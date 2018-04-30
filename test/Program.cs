using Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\n-----\n选择要选择的加解密");
                Console.WriteLine("1、Base64加密 2、Base64解密 3、Base32加密 4、Base32解密");
                Console.WriteLine("5、异或加密（输出b64） 6、异或解密（输入b64） 7、凯撒加解密 8、Rot13加解密");
                Console.WriteLine("9、morse加密 10、morse解密 11、16位md5 12、128位AES(CBC)加密 13、128位AES(CBC)解密");
                Console.WriteLine("14、128位AES(ECB)加密 15、128位AES(ECB)解密 16、培根加密 17、培根解密");
                Console.WriteLine("18、栅栏加密 19、栅栏解密 20、维吉尼亚加密 21、维吉尼亚解密 22、任意进制转换");
                Console.WriteLine("23、URL编码 24 URL解码 25、字符串转Unicode 26、字符串转为UniCode码字符串 27、Unicode字符串转为正常字符串");
                Console.WriteLine("28、字符串转ASCII（byte[]） 29、ASCII(byte[])转字符串");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Write("请输入要加解密的字符串：");
                string str = Console.ReadLine();
                switch (choice)
                {
                    #region 1-8
                    case 1:
                        Console.WriteLine("B64加密结果为：" + Code.Base64Encode(str));
                        break;
                    case 2:
                        Console.WriteLine("B64解密结果为：" + Code.Base64Decode(str));
                        break;
                    case 3:
                        Console.WriteLine("B32加密结果为：" + Code.Base32Encode(str));
                        break;
                    case 4:
                        Console.WriteLine("B32解密结果为：" + Code.Base32Decode(str));
                        break;
                    case 5:
                        Console.Write("请输入密钥：");
                        string key = Console.ReadLine();
                        Console.WriteLine("xor结果为：" + DecryptEncrypt.xor(str,key,true));
                        break;
                    case 6:
                        Console.Write("请输入密钥：");
                        string key1 = Console.ReadLine();
                        Console.WriteLine("xor结果为：" +
                            DecryptEncrypt.xor(Code.Base64Decode(str), key1, false));
                        break;
                    case 7:
                        Console.Write("请输入移位数：");
                        int digits = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("caesar结果为：" + DecryptEncrypt.caesar(str, digits));
                        break;
                    case 8:
                        Console.WriteLine("rot13结果为：" + DecryptEncrypt.rot13(str));
                        break;
                    #endregion
                    #region 9-15
                    case 9:
                        Console.WriteLine("morse加密结果为：" + Code.morseEncode(str));
                        break;
                    case 10:
                        Console.WriteLine("morse解密结果为：" + Code.morseDecode(str, '/'));
                        break;
                    case 11:
                        Console.WriteLine("16位MD5结果为：" + DecryptEncrypt.md5_16(str));
                        break;
                    case 12:
                        string iv = DecryptEncrypt.getIv(16);
                        Console.WriteLine("随机生成的iv为:" + iv);
                        Console.Write("请输入密码:");
                        string aes_cbc_password = Console.ReadLine();
                        Console.WriteLine("128位AES(CBC)加密:" + DecryptEncrypt.AESEncrypt_CBC(str, aes_cbc_password, iv));
                        break;
                    case 13:
                        Console.Write("请输入iv:");
                        string iv1 = Console.ReadLine(); 
                        Console.Write("请输入密码:");
                        string aes_cbc_password1 = Console.ReadLine();
                        Console.WriteLine("128位AES(CBC)解密:" + DecryptEncrypt.AESDecrypt_CBC(str, aes_cbc_password1, iv1));
                        break;

                    case 14:
                        Console.Write("请输入密码:");
                        string aes_ecb_password = Console.ReadLine();
                        Console.WriteLine("128位AES(ECB)加密:" + DecryptEncrypt.AESEncrypt_ECB(str, aes_ecb_password));
                        break;
                    case 15:
                        Console.Write("请输入密码:");
                        string aes_ecb_password1 = Console.ReadLine();
                        Console.WriteLine("128位AES(ECB)解密:" + DecryptEncrypt.AESDecrypt_ECB(str, aes_ecb_password1));
                        break;
                    #endregion
                    #region 16-22
                    case 16:
                        Console.WriteLine("培根加密结果为：" + DecryptEncrypt.baconEncrypt(str));
                        break;
                    case 17:
                        Console.WriteLine("培根加密结果为：" + DecryptEncrypt.baconDecrypt(str,true));
                        break;
                    case 18:
                        Console.WriteLine("栅栏加密结果为：" + DecryptEncrypt.fenceEncrypt(str));
                        break;
                    case 19:
                        Console.WriteLine("栅栏解密结果为：" + DecryptEncrypt.fenceDecrypt(str));
                        break;
                    case 20:
                        Console.Write("请输入密钥:");
                        string vigenere_key = Console.ReadLine();
                        Console.WriteLine("维吉尼亚加密结果为：" + DecryptEncrypt.vigenereEncrypt(str, vigenere_key));
                        break;
                    case 21:
                        Console.Write("请输入密钥:");
                        string vigenere1_key = Console.ReadLine();
                        Console.WriteLine("维吉尼亚解密结果为：" + DecryptEncrypt.vigenereDecrypt(str, vigenere1_key));
                        break;
                    case 22:
                        Console.Write("请输入现在的进制数:");
                        int convertin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("请输入要转换的进制数:");
                        int convertout = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("进制转换结果为：" + Conversion.convert(str,convertin,convertout));
                        break;
                    #endregion
                    #region 23-
                    case 23:
                        Console.WriteLine("URL编码结果为："+Code.UrlEncode(str));
                        break;
                    case 24:
                        Console.WriteLine("URL解码结果为：" + Code.UrlDecode(str));
                        break;
                    case 25:
                        Console.WriteLine("字符串转Unicode结果为：" + Code.String2Unicode(str));
                        break;
                    case 26:
                        Console.WriteLine("字符串转为UniCode码字符串结果为：" + Code.StringToUnicode(str));
                        break;
                    case 27:
                        Console.WriteLine("Unicode字符串转为正常字符串结果为：" + Code.UnicodeToString(str));
                        break;
                    case 28:
                        Console.WriteLine("字符串转ASCII结果为：");
                        foreach (var item in Code.StringToASCII(str))
                        {
                            Console.Write(item.ToString()+',');
                        }
                        break;
                    case 29:
                        Console.WriteLine("ASCII转字符串结果为：(这个输入不了)");
                        break;
                    #endregion
                    default:
                        Console.WriteLine("Error！");
                        break;
                }
            }
        }
    }
}
