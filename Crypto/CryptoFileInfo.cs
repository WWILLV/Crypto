using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crypto
{
    public class CryptoFileInfo
    {
        private string path = CryptoFile._tempPath;
        private FileInfo fi;

        /// <summary>
        /// CryptoFileInfo(必须先指定CryptoFile临时文件）
        /// </summary>
        public CryptoFileInfo() { fi = new FileInfo(path); }
        public CryptoFileInfo(string path) { this.path = path; fi = new FileInfo(path); }

        /// <summary>
        /// 获取文件md5
        /// </summary>
        /// <returns></returns>
        public string getMd5()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取文件Sha1
        /// </summary>
        /// <returns></returns>
        public string GetSha1()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] retval = sha1.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sb.Append(retval[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取文件Sha256
        /// </summary>
        /// <returns></returns>
        public string GetSha256()
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
                byte[] retval = sha256.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retval.Length; i++)
                {
                    sb.Append(retval[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region FileInfo
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return fi.Name.ToString();
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <returns></returns>
        public string getExtension()
        {
            return fi.Extension.ToString();
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <returns></returns>
        public string getLength()
        {
            return fi.Length.ToString();
        }

        /// <summary>
        /// 获取文件创建时间
        /// </summary>
        /// <returns></returns>
        public string getCreationTime()
        {
            return fi.CreationTime.ToString();
        }

        /// <summary>
        /// 获取文件上次访问时间
        /// </summary>
        /// <returns></returns>
        public string getLastAccessTime()
        {
            return fi.LastAccessTime.ToString();
        }

        /// <summary>
        /// 获取文件上次写入时间
        /// </summary>
        /// <returns></returns>
        public string getLastWriteTime()
        {
            return fi.LastWriteTime.ToString();
        }

        /// <summary>
        /// 获取文件属性
        /// </summary>
        /// <returns></returns>
        public string getAttributes()
        {
            return fi.Attributes.ToString();
        }
        #endregion
    }
}
