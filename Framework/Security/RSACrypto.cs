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

        #region ������Կ��

        /// <summary>
        /// ������Կ��
        /// </summary>
        /// <param name="xmlPublicKey">��Կ</param>
        /// <param name="xmlPrivateKey">˽Կ</param>
        public static void GenerateKeys(out string xmlPublicKey, out string xmlPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            xmlPublicKey = rsa.ToXmlString(false);
            xmlPrivateKey = rsa.ToXmlString(true);
            rsa.Clear();
        }

        #endregion ������Կ��

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="cleanText">����</param>
        /// <param name="xmlPublicKey">��Կ</param>
        /// <returns>����</returns>
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
        
        #endregion ����

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="cypherText">����</param>
        /// <param name="xmlPrivateKey">˽Կ</param>
        /// <returns>����</returns>
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
        
        #endregion ����

        #region ǩ��

        /// <summary>
        /// ��ϣǩ��
        /// </summary>
        /// <param name="xmlPrivateKey">˽Կ</param>
        /// <param name="rawData">����</param>
        /// <returns>ǩ����</returns>
        public static string SignData(string xmlPrivateKey, string rawData)
        {
            string hashData = MD5Hash.GetHashString(rawData);
            string signature = RSACrypto.SignatureStringFormatter(xmlPrivateKey, hashData);
            return signature;
        }

        /// <summary>
        /// ǩ��
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashbyteSignature"></param>
        /// <returns></returns>
        public static byte[] SignatureFormatter(string xmlPrivateKey, byte[] hashbyteSignature)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
            // ����ǩ�����㷨ΪMD5 
            rsaFormatter.SetHashAlgorithm("MD5");
            //ִ��ǩ�� 
            return rsaFormatter.CreateSignature(hashbyteSignature);
        }

        /// <summary>
        /// ǩ��
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
        /// ǩ��
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
        /// ǩ��
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="hashSignatureString"></param>
        /// <returns></returns>
        public static string SignatureStringFormatter(string xmlPrivateKey, string hashSignatureString)
        {
            byte[] encryptedSignatureData = RSACrypto.SignatureFormatter(xmlPrivateKey, hashSignatureString);
            return Convert.ToBase64String(encryptedSignatureData);
        }

        #endregion ǩ��

        #region ǩ����֤

        /// <summary>
        /// ��֤ǩ��
        /// </summary>
        /// <param name="xmlPublicKey">��Կ</param>
        /// <param name="rawData">����</param>
        /// <param name="signature">ǩ����</param>
        /// <returns></returns>
        public static bool VerifyData(string xmlPublicKey, string rawData, string signature)
        {
            string hashData = MD5Hash.GetHashString(rawData);
            return RSACrypto.SignatureDeformatter(xmlPublicKey, hashData, signature);
        }

        /// <summary>
        /// ǩ����֤
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
            //ָ�����ܵ�ʱ��HASH�㷨ΪMD5 
            rsaDeformatter.SetHashAlgorithm("MD5");
            return rsaDeformatter.VerifySignature(hashbyteDeformatter, deformatterData);
        }

        /// <summary>
        /// ǩ����֤
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
        /// ǩ����֤
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
        /// ǩ����֤
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

        #endregion ǩ����֤
    }
}
