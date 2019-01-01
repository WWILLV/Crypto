using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class CryptoZip
    {
        static private byte[] file;
        /// <summary>
        /// 修改标志
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private static int changeFlag(byte by)
        {
            int count = 0;
            for (int i = file.Length - 8; i > 0; i--)
            {
                if (file[i] == 0x50)
                    if (file[i + 1] == 0x4B)
                        if (file[i + 2] == 0x01)
                            if (file[i + 3] == 0x02)
                                if (file[i + 7] == 0x00)
                                {
                                    file[i + 8] = by;
                                    count++;
                                }
            }
            return count;
        }
        /// <summary>
        /// 压缩文件伪加密
        /// </summary>
        /// <param name="path">压缩文件路径</param>
        /// <param name="newpath">新文件路径</param>
        /// <returns>修改的标志数</returns>
        static public int fakeEncryption(string path, string newpath)
        {
            file = CryptoFile.fileToArray(path);
            int count = changeFlag(0x09);
            CryptoFile.arrayToFile(newpath, file, System.IO.FileMode.Create);
            return count;
        }
        /// <summary>
        /// 恢复伪加密
        /// </summary>
        /// <param name="path">伪加密文件路径</param>
        /// <param name="newpath">新文件路径</param>
        /// <returns>修改的标志数</returns>
        static public int fakeRecover(string path, string newpath)
        {
            file = CryptoFile.fileToArray(path);
            int count = changeFlag(0x00);
            CryptoFile.arrayToFile(newpath, file, System.IO.FileMode.Create);
            return count;
        }
    }
}
