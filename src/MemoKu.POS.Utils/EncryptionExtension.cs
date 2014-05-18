using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Utils
{
    public static class EncryptionExtension
    {
        private static EncryptionUtil encryptionUtil;

        public static string EncryptToString(this string text)
        {
            return EncryptionUtil.EncryptToString(text);
        }

        public static byte[] Encrypt(this string text)
        {
            return EncryptionUtil.Encrypt(text);
        }

        public static string DecryptString(this string encryptedString)
        {
            return EncryptionUtil.DecryptString(encryptedString);
        }

        public static string Decrypt(this byte[] encryptedValue)
        {
            return EncryptionUtil.Decrypt(encryptedValue);
        }

        public static byte[] StrToByteArray(this string text)
        {
            return EncryptionUtil.StrToByteArray(text);
        }

        public static string ByteArrToString(this byte[] byteArr)
        {
            return EncryptionUtil.ByteArrToString(byteArr);
        }

        private static EncryptionUtil EncryptionUtil
        {
            get
            {
                if (encryptionUtil == null)
                    encryptionUtil = new EncryptionUtil();
                return encryptionUtil;
            }
        }
    }
}
