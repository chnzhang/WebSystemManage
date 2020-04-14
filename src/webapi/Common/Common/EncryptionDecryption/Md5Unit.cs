using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.EncryptionDecryption
{
    public class Md5Unit
    {
        /// <summary>
        /// MD5加密字符串（32位）
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD532(string source, int type = 1)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            string result = BitConverter.ToString(md5.ComputeHash(bytes));
            result = result.Replace("-", "");
            return type == 1 ? result : result.ToLower();
        }


        /// <summary>
        ///  MD5加密字符串（16位）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string MD516(string source, int type = 1)
        {
            //16位大写
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder builder = new StringBuilder();
                // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("X2"));
                }
                string result4 = builder.ToString().Substring(8, 16);
                return type == 1 ? result4 : result4.ToLower();
            }
        }
    }
}