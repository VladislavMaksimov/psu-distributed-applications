using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace task_1_api
{
    class Crypto
    {
        // Шифрование строки с помощью алгоритма AES
        public static byte[] encrypt(string text, string pass, string salt)
        {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pass, Encoding.ASCII.GetBytes(salt));
            byte[] encrypted;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.BlockSize = 128;
                aesAlg.Key = rfc2898DeriveBytes.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = rfc2898DeriveBytes.GetBytes(aesAlg.BlockSize / 8);
               
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        // Дешифрование строки с помощью алгоритма AES
        public static string decrypt(byte[] encryptedText, string pass, string salt)
        {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pass, Encoding.ASCII.GetBytes(salt));
            string decrypted;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.BlockSize = 128;
                aesAlg.Key = rfc2898DeriveBytes.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = rfc2898DeriveBytes.GetBytes(aesAlg.BlockSize / 8);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}
