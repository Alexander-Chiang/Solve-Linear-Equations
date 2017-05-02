using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Framework.Security
{
    public class MD5Hash
    {
        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="rawData"></param>
        public static byte[] GetHash(string rawData)
        {
            byte[] buffer;
            HashAlgorithm md5 = HashAlgorithm.Create("MD5");
            buffer = Encoding.GetEncoding("GB2312").GetBytes(rawData);
            return md5.ComputeHash(buffer);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static string GetHashString(string rawData)
        {
            byte[] hashData = MD5Hash.GetHash(rawData);
            return Convert.ToBase64String(hashData);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static byte[] GetHash(FileStream fileStream)
        {
            HashAlgorithm md5 = HashAlgorithm.Create("MD5");
            byte[] hashData = md5.ComputeHash(fileStream);
            fileStream.Close();
            return hashData;
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static string GetHashString(FileStream fileStream)
        {
            byte[] hashData = MD5Hash.GetHash(fileStream);
            fileStream.Close();
            return Convert.ToBase64String(hashData);
        }
    }
}
