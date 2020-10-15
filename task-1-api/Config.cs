using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace task_1_api
{
    class Config
    {
        // Параметры для работы с приложением
        public static string appID = "7621971";
        public static string token = "";
        public static string userID = "";

        // Пароль и соль для шифрования
        static string pass = "1234567890";
        static string salt = "aaaaabbb";

        // Шифрования пароля и токена и запись в файл
        public static void encrypt()
        {
            byte[] encryptedToken = Crypto.encrypt(token, pass, salt);
            using (BinaryWriter writer = new BinaryWriter(File.Open("token.dat", FileMode.OpenOrCreate)))
            {
                writer.Write(encryptedToken);
            }

            byte[] encryptedID = Crypto.encrypt(userID, pass, salt);
            using (BinaryWriter writer = new BinaryWriter(File.Open("id.dat", FileMode.OpenOrCreate)))
            {
                writer.Write(encryptedID);
            }
        }

        // Получение пароля и токена из файла и дешифрование
        public static void decrypt()
        {
            if (!File.Exists("token.dat") || !File.Exists("id.dat"))
                return;

            using (BinaryReader readerTKN = new BinaryReader(File.Open("token.dat", FileMode.Open)))
            using (BinaryReader readerID = new BinaryReader(File.Open("id.dat", FileMode.Open)))
            {
                List<byte> tknRead = new List<byte>();

                while (readerTKN.BaseStream.Position != readerTKN.BaseStream.Length)
                {
                    tknRead.Add(readerTKN.ReadByte());
                }

                byte[] tkn = new byte[tknRead.Count];
                for (int i = 0; i < tknRead.Count; i++)
                    tkn[i] = tknRead[i];

                List<byte> idRead = new List<byte>();

                while (readerID.BaseStream.Position != readerID.BaseStream.Length)
                {
                    idRead.Add(readerID.ReadByte());
                }

                byte[] id = new byte[idRead.Count];
                for (int i = 0; i < idRead.Count; i++)
                    id[i] = idRead[i];

                token = Crypto.decrypt(tkn, pass, salt);
                userID = Crypto.decrypt(id, pass, salt);
            }
        }
    }
}
