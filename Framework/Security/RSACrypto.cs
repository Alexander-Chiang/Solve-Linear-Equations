using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Framework.Security
{
    /// <summary>
    /// RSA
    /// </summary>
    public class RSACrypto
    {
        //private static RSACryptoServiceProvider rsa;

        #region 产生密钥对

        /// <summary>
        /// 产生密钥对
        /// </summary>
        /// <param name="xmlPublicKey">公钥</param>
        /// <param name="xmlPrivateKey">私钥</param>
        public static void GenerateKeys(out string xmlPublicKey, out string xmlPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            xmlPublicKey = rsa.ToXmlString(false);
            xmlPrivateKey = rsa.ToXmlString(true);
            rsa.Clear();
        }

        #endregion 产生密钥对

        #region 加密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="cleanText">明文</param>
        /// <param name="xmlPublicKey">公钥</param>
        /// <returns>密文</returns>
        public static string Encrypt(string cleanText, string xmlPublicKey)
        {
            byte[] plainTextBArray;
            byte[] cypherTextBArray;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            plainTextBArray = (new UnicodeEncoding()).GetBytes(cleanText);
            cypherTextBArray = rsa.Encrypt(plainTextBArray, false);
	    rsa.Clear();
            return Convert.ToBase64String(cypherTextBArray);
        }
        
        #endregion 加密

        #region 解密

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cypherText">密文</param>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <returns>明文</returns>
        public static string Decrypt(string cypherText, string xmlPrivateKey)
        {
            byte[] cypherTextBArray;
            byte[] decipherTextBArray;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            cypherTextBArray = Convert.FromBase64String(cypherText);
            decipherTextBArray = rsa.Decrypt(cypherTextBArray, false);
	    rsa.Clear();
            return (new UnicodeEncoding()).GetString(decipherTextBArray);
        }
        
        #endregion 解密

        #region 签名

        /// <summary>
        /// 哈希签名
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="rawData">数据</param>
        /// <returns>签名串</returns>
        public static string SignData(string xmlPrivateKey, string rawData)
        {
            string hashData = MD5Hash.GetHashString(rawData);
            string signature = RSACrypto.SignatureStringFormatter(xmlPrivateKey, hashData);
            return signature;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashbyteSignature"></param>
        /// <returns></returns>
        public static byte[] SignatureFormatter(string xmlPrivateKey, byte[] hashbyteSignature)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
            // 设置签名的算法为MD5 
            rsaFormatter.SetHashAlgorithm("MD5");
            //执行签名 
            return rsaFormatter.CreateSignature(hashbyteSignature);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashbyteSignature"></param>
        /// <returns></returns>
        public static string SignatureStringFormatter(string xmlPrivateKey, byte[] hashbyteSignature)
        {
            byte[] encryptedSignatureData = RSACrypto.SignatureFormatter(xmlPrivateKey, hashbyteSignature);
            return Convert.ToBase64String(encryptedSignatureData);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashSignatureString"></param>
        /// <returns></returns>
        public static byte[] SignatureFormatter(string xmlPrivateKey, string hashSignatureString)
        {
            byte[] hashSignatureBytes = Convert.FromBase64String(hashSignatureString);
            return RSACrypto.SignatureFormatter(xmlPrivateKey, hashSignatureBytes);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashSignatureString"></param>
        /// <returns></returns>
        public static string SignatureStringFormatter(string xmlPrivateKey, string hashSignatureString)
        {
            byte[] encryptedSignatureData = RSACrypto.SignatureFormatter(xmlPrivateKey, hashSignatureString);
            return Convert.ToBase64String(encryptedSignatureData);
        }

        #endregion 签名

        #region 签名验证

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="xmlPublicKey">公钥</param>
        /// <param name="rawData">数据</param>
        /// <param name="signature">签名串</param>
        /// <returns></returns>
        public static bool VerifyData(string xmlPublicKey, string rawData, string signature)
        {
            string hashData = MD5Hash.GetHashString(rawData);
            return RSACrypto.SignatureDeformatter(xmlPublicKey, hashData, signature);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="hashbyteDeformatter"></param>
        /// <param name="deformatterData"></param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string xmlPublicKey, byte[] hashbyteDeformatter, byte[] deformatterData)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
            //指定解密的时候HASH算法为MD5 
            rsaDeformatter.SetHashAlgorithm("MD5");
            return rsaDeformatter.VerifySignature(hashbyteDeformatter, deformatterData);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="hashDeformatterString"></param>
        /// <param name="deformatterData"></param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string xmlPublicKey, string hashDeformatterString, byte[] deformatterData)
        {
            byte[] hashbyteDeformatter = Convert.FromBase64String(hashDeformatterString);
            return RSACrypto.SignatureDeformatter(xmlPublicKey, hashbyteDeformatter, deformatterData);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="hashbyteDeformatter"></param>
        /// <param name="deformatterDataString"></param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string xmlPublicKey, byte[] hashbyteDeformatter, string deformatterDataString)
        {
            byte[] deformatterData = Convert.FromBase64String(deformatterDataString);
            return RSACrypto.SignatureDeformatter(xmlPublicKey, hashbyteDeformatter, deformatterData);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="hashDeformatterString"></param>
        /// <param name="deformatterDataString"></param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string xmlPublicKey, string hashDeformatterString, string deformatterDataString)
        {
            byte[] hashbyteDeformatter = Convert.FromBase64String(hashDeformatterString);
            return RSACrypto.SignatureDeformatter(xmlPublicKey, hashbyteDeformatter, deformatterDataString);
        }

        #endregion 签名验证
    }
}
