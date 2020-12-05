using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using DESDbStringMes = task_2_messages.DESDbStingMes;
using System.IO;

namespace task_2_server
{
    class Decryptor
    {
        public static string RSAkey;

        public static string RSACreateKeys()
        {
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSAkey = RSA.ToXmlString(true);
                return RSA.ToXmlString(false);
            }
        }

        public static byte[] RSAdecrypt(byte[] encryptedKey)
        {
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(RSAkey);
                byte[] result = RSA.Decrypt(encryptedKey, true);
                return result;
            }
        }

        public static string DESdecrypt(DESDbStringMes mes)
        {
            DES DESalg = DES.Create();
            DESalg.Key = mes.Key;
            DESalg.IV = mes.IV;
            var decryptor = DESalg.CreateDecryptor();
            using (MemoryStream msDecrypt = new MemoryStream(mes.Value))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        string result = srDecrypt.ReadToEnd();
                        return result;
                    }
                }

            }
        }
    }
}
