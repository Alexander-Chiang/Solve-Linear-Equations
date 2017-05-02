using System;
using System.Security.Permissions;

namespace Framework.Security
{
    [StrongNameIdentityPermissionAttribute(SecurityAction.LinkDemand, PublicKey =
            "0024000004800000940000000602000000240000525341310004000001000100eb9a9740550035" +
            "234ef323e727ebd8ea3380b584855f916a455cd2530b1394155ec90b5261cfb4e64b5a75fa8095" +
            "0e8a0e12a7f0c28237aa3de6a9cdf45112a1fb8b8905d2c7420d9d11e20d03226734265cf63cf8" +
            "41fd31e1d266375501719894ceacd3b003e67c5cf75a4f39bb01d088595ed526c47349b189d154" +
            "49755de3")]
    public class AppKey
    {
        /// <summary>
        /// 本应用系统的ID
        /// </summary>
        public const int AppID = 5;

        /// <summary>
        /// 统一用户应用系统的ID
        /// </summary>
        public const int CentralUserAppID = 1;

        /// <summary>
        /// 本应用公钥
        /// </summary>
        private const string publicKey = "<RSAKeyValue><Modulus>1EK9HeggtXqXI9C5EEWEL2I6Sn8KB37j3AskkLVMjrJUT03trULjCALF+FYlPKa+Apcl3jYkXSfx/qvKy8XMSZqNFJx93x8WIBqX7czvc/oLhqkeA2cEkMbAFcsQa+4gNWMDp2TsBZ2uTo6WAya/SFaG3N611gb7taarbV4yldM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        /// <summary>
        /// 本应用私钥
        /// </summary>
        private const string privateKey = "<RSAKeyValue><Modulus>1EK9HeggtXqXI9C5EEWEL2I6Sn8KB37j3AskkLVMjrJUT03trULjCALF+FYlPKa+Apcl3jYkXSfx/qvKy8XMSZqNFJx93x8WIBqX7czvc/oLhqkeA2cEkMbAFcsQa+4gNWMDp2TsBZ2uTo6WAya/SFaG3N611gb7taarbV4yldM=</Modulus><Exponent>AQAB</Exponent><P>9v0TAEN3tEH98bJsmAGdCGrgoHIZ5CleRqY2TJZq+UFQtcnGfHOa6XVXL/Bg6FqCcmK4/vi8zjam/aoZtmOHLw==</P><Q>3AFMfega0FscG34TA/rEA0wLlol5IXWqLMLqjRYK5uhYrhBdTkFgh6bOJ8cJ5rD7YaKM7tB+pT+2JOYpGPaynQ==</Q><DP>Liqb1J7Hzz/OkdECD1+t1Jb1qcfqIwXAg4AqAiLTmAenaHNw0G5jdGPkiidqVcQlQfBGGBKyZ/E7QYr8B2WPLQ==</DP><DQ>0lBDiVEq4OdYFUgOcY11eBloMn4017Gd/rBOfJUH0vlmXO+z4q1I1CS3ivsREgE6Lnmv9FRH3TzsqJWF0CF1WQ==</DQ><InverseQ>uWMNVQ3zBOzYrZQFecaSgjteFNQbDiA4fht/HuuOkqNZZi+IywFpCEHN8acNqM/irXSj/LGA0s6Rq8h0VnXfWA==</InverseQ><D>hcjm4CG99ASnnJhi/KGENkVoTioSTTUqMzgGvPq4nTxDLZUFmG4PIK52zxak87x5CLLx2EQx2VFjEsx+zr8GCbv686d/4e5/F1R9e5N4sdbsFkiX8lNBJpK4vTwkcCLO4eBa7yrVRCFhon6GAGlO1fY57cQ+rRMMOgVSBhnwvtk=</D></RSAKeyValue>";

        /// <summary>
        /// (使用本应用公钥)加密
        /// </summary>
        /// <param name="cleanText">明文</param>
        /// <returns></returns>
        public static string Encrypt(string cleanText)
        {
            return RSACrypto.Encrypt(cleanText, publicKey);
        }

        /// <summary>
        /// (使用本应用公钥)解密
        /// </summary>
        /// <param name="encryptText">密文</param>
        /// <returns></returns>
        public static string Decrypt(string encryptText)
        {
            try
            {
                return RSACrypto.Decrypt(encryptText, privateKey);
            }
            catch (Exception ex)
            {
                return "bb " + ex.Message;
            }
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="cleanText"></param>
        /// <returns></returns>
        public static string SignData(string cleanText)
        {
            return RSACrypto.SignData(privateKey, cleanText);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="cleanText"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static bool VerifyData(string cleanText, string signature)
        {
            return RSACrypto.VerifyData(publicKey, cleanText, signature);
        }

    }
}
