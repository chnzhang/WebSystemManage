using System.Security.Cryptography;

namespace Common.EncryptionDecryption
{
    public class ShaUnit
    {
         // <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string SHA256(string strData)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(strData);
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] retVal = sha256.ComputeHash(bytValue);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="strData">内容</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string SHA256(string strData, string salt)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(salt + strData);
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] retVal = sha256.ComputeHash(bytValue);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="strData">内容</param>
        /// <param name="salt">盐</param>
        /// <param name="hashIterations">次数 </param>
        /// <returns></returns>
        public static string SHA256(string strData, string salt, int hashIterations)
        {
            string content = salt + strData;
            for (int j = 0; j < hashIterations; j++)
            {
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(content);
                SHA256 sha256 = new SHA256CryptoServiceProvider();

                byte[] retVal = sha256.ComputeHash(bytValue);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                content = sb.ToString();
            }

            return content;
        }
    }
}