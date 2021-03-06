using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace A2ZPortal.Helper.Extension
{
    public static class PasswordEncrypter
    {
        public static string GetEncryptedPassword(string password)
        {
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
            ICryptoTransform encryptor = rc2CSP.CreateEncryptor(Convert.FromBase64String("A2ZPortal"), Convert.FromBase64String("A2Zportal"));
            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            byte[] toEncrypt = Encoding.Unicode.GetBytes(password);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            byte[] encrypted = msEncrypt.ToArray();

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptText(string encryptedText)
        {
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
            ICryptoTransform decryptor = rc2CSP.CreateDecryptor(Convert.FromBase64String("A2ZPortal"), Convert.FromBase64String("A2ZPortal"));
            using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText));
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            List<Byte> bytes = new List<byte>();
            int b;
            do
            {
                b = csDecrypt.ReadByte();
                if (b != -1)
                {
                    bytes.Add(Convert.ToByte(b));
                }

            }
            while (b != -1);

            return Encoding.Unicode.GetString(bytes.ToArray());
        }
    }
}
