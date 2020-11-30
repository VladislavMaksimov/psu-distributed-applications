using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using DESDbStringMes = task_2_messages.DESDbStingMes;
using System.IO;

namespace task_2_client
{
    class Encryptor
    {
        public static string publicKey;

        public static byte[] RSAencrypt(byte[] desKey)
        {
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKey);
                byte[] result = RSA.Encrypt(desKey, true);
                return result;
            }
        }

        public static DESDbStringMes DESencrypt(string data)
        {
            DES DESalg = DES.Create();
            var encryptor = DESalg.CreateEncryptor();
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(data);
                    }
                    DESDbStringMes result = new DESDbStringMes(DESalg.Key, DESalg.IV, msEncrypt.ToArray());
                    return result;
                }
            }
        }
    }
}
