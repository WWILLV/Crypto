using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crypto
{
    public class CryptoFile
    {
        /// <summary>
        /// 文件反转为新文件(新文件存在会追加到末尾)
        /// </summary>
        /// <param name="oriFile">要翻转的文件</param>
        /// <param name="newFile">翻转的文件</param>
        static public void fileReverse(string oriFile, string newFile)
        {
            byte[] array = fileToArray(oriFile);
            Array.Reverse(array);
            arrayToFile(newFile, array, FileMode.Append);
        }

        /// <summary>
        /// 读取文件到字节数组
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        static public byte[] fileToArray(string path)
        {
            FileStream fileStream = File.Open(path, FileMode.Open);//初始化文件流
            byte[] array = new byte[fileStream.Length];//初始化字节数组，用来暂存读取到的字节
            fileStream.Read(array, 0, array.Length);//读取流中数据，写入到字节数组中
            fileStream.Close(); //关闭流
            return array;
        }

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        static public string fileToString(string path)
        {
            return Encoding.Default.GetString(fileToArray(path));//将字节数组内容转化为字符串
        }

        /// <summary>
        /// 字节数组到文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="array">字节数组</param>
        /// <param name="fm">文件打开方法</param>
        static public void arrayToFile(string path, byte[] array, FileMode fm)
        {
            FileStream fileStream = File.Open(path, fm);//初始化文件流
            fileStream.Write(array, 0, array.Length);//将字节数组写入文件流
            fileStream.Close();//关闭流
        }

        /// <summary>
        /// 字符串到文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="str">字符串</param>
        /// <param name="fm">文件打开方法</param>
        static public void stringToFile(string path, string str, FileMode fm)
        {
            arrayToFile(path, Encoding.Default.GetBytes(str), fm);
        }

        #region 临时文件操作
        /// <summary>
        /// 临时文件路径
        /// </summary>
        static public string _tempPath = "";//临时文件路径

        /// <summary>
        /// 检查临时文件是否使用
        /// </summary>
        /// <returns></returns>
        static private bool checkTemp()
        {
            if (_tempPath == "") return false;
            return true;
        }

        /// <summary>
        /// 字节数组到临时文件
        /// </summary>
        /// <param name="array">字节数组</param>
        /// <param name="fm">文件打开方式</param>
        static public void arrayToFile(byte[] array, FileMode fm)
        {
            if (checkTemp())
                arrayToFile(_tempPath, array, fm);
            else
                throw new Exception("临时文件路径错误");
        }

        /// <summary>
        /// 字符串到临时文件
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="fm">文件打开方法</param>
        static public void stringToFile(string str, FileMode fm)
        {
            if (checkTemp())
                arrayToFile(_tempPath, Encoding.Default.GetBytes(str), fm);
            else
                throw new Exception("临时文件路径错误");
        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        /// <returns></returns>
        static public bool delTemp()
        {
            if (File.Exists(_tempPath))
            {
                File.Delete(_tempPath);
                return true;
            }
            return false;
        }
        #endregion
    }
}
