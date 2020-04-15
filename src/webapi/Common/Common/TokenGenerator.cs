using System;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class TokenGenerator
    {
           public static string generateValue()
        {
            return generateValue(System.Guid.NewGuid().ToString("N"));
        }

        private static readonly char[] HEX_CODE = "0123456789abcdef".ToCharArray();

        public static string toHexString(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            StringBuilder r = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
            {
                r.Append(HEX_CODE[(b >> 4) & 0xF]);
                r.Append(HEX_CODE[(b & 0xF)]);
            }
            return r.ToString();
        }

        public static string generateValue(string param)
        {
            try
            {

                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedDataBytes;
                hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("utf-8").GetBytes(param));

                //byte[] messageDigest = algorithm.digest();
                return toHexString(hashedDataBytes);
            }
            catch (Exception e)
            {
                throw new Exception("生成Token失败", e);
            }
        }
    }
}