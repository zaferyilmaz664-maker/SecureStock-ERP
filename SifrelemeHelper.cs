using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureStock.BusinessLogic
{
    public static class SifrelemeHelper
    {
        public static string SHA256Sifrele(string düzMetin)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Düz metni byte dizisine çevir ve hash'le
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(düzMetin));

                // Byte dizisini string'e (Hexadecimal formatta) dönüştür
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}