using System;
using System.Text;

namespace MyWeb.Common
{
    public class Encodingvmms
    {
        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKey = "!5623a#de";
        #region[Encode for URL]
        public static string Encode(string src)
        {
            byte[] b;
            try
            {
                b = Encoding.Unicode.GetBytes(EncryptionKey + src);
            }
            catch { return src; }
            return Convert.ToBase64String(b).Replace("=", "%3D");

        }
        public static string Decode(string src)
        {
            byte[] b;
            try
            {
                b = Convert.FromBase64String(src.Replace("%3D", "="));
                src = Encoding.Unicode.GetString(b);
                // src = src.Substring(0, src.Length - 9);
                src = src.Remove(0, 9);
            }
            catch { return src; }
            return src;

        }
        #endregion

    }
}