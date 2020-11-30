using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using task_2.Tables;

namespace task_2_server
{
    class PgConnector
    {
        static string connection = new NpgsqlConnectionStringBuilder()
        {
            Host = "localhost",
            Username = "postgres",
            Password = "1234",
            Database = "artists"
        }.ConnectionString;

        static NpgsqlCommand command;

        // Проверяет существование записи в справочнике
        static bool IsThatDirectoryStringExists(Directory directory)
        {
            using (var conn = new NpgsqlConnection(connection))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return true;
                }

                string table = "";
                // В зависимости от того, запись какого справочника передана, добавляется название таблицы
                if (directory is Country)
                    table = "countries";

                if (directory is Exposition)
                    table = "expositions";

                if (directory is Movement)
                    table = "movements";

                if (directory is Picture)
                    table = "pictures";

                // Проверка происходит по количеству (если >0, то запись есть)
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"SELECT COUNT(0) FROM " + table + " WHERE name = @name"
                };
                command.Parameters.AddWithValue("@name", directory.Name);

                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                conn.Close();

                if (count > 0)
                    return true;
                else
                    return false;
            }
        }

        // Проверяет существование записи в таблице художников
        static bool IsThatArtistExists(Artist artist)
        {
            using (var conn = new NpgsqlConnection(connection))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return true;
                }

                // Проверка производится по количеству записей (ФИО художника считается уникальным)
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"SELECT COUNT(0) FROM artists WHERE name = @name AND surname = @surname
                                    AND second_name = @second_name"
                };
                command.Parameters.AddWithValue("@name", artist.Name);
                command.Parameters.AddWithValue("@surname", artist.Surname);
                command.Parameters.AddWithValue("@second_name", artist.Second_name);

                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                conn.Close();

                if (count > 0)
                    return true;
                else
                    return false;
            }
        }

        // Проверяет существование записи в таблице-связке
        static bool IsThatConnectionExists(Artist artist)
        {
            using (var conn = new NpgsqlConnection(connection))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return true;
                }

                // Проверка производится по количеству записей
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"SELECT COUNT(0) FROM artists_expo WHERE id_artist = 
                            (SELECT id FROM artists WHERE name = @name AND surname = @surname AND second_name = @second_name) 
                            AND id_expo = (SELECT id FROM expositions WHERE name = @exposition)"
                };
                command.Parameters.AddWithValue("@name", artist.Name);
                command.Parameters.AddWithValue("@surname", artist.Surname);
                command.Parameters.AddWithValue("@second_name", artist.Second_name);
                command.Parameters.AddWithValue("@exposition", artist.Exposition.Name);

                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                conn.Close();

                if (count > 0)
                    return true;
                else
                    return false;
            }
        }

        // Добавляет запись в один из справочников
        static void InsertIntoDirectory(Directory directory, NpgsqlConnection conn)
        {
            if (!IsThatDirectoryStringExists(directory))
            {
                string table = "";
                if (directory is Country)
                    table = "countries";
                if (directory is Exposition)
                    table = "expositions";
                if (directory is Movement)
                    table = "movements";

                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"INSERT INTO " + table +" VALUES (DEFAULT, @directory)"
                };
                command.Parameters.AddWithValue("@directory", directory.Name);

                command.ExecuteNonQuery();
            }
        }

        // Добавляет запись в таблицу художников
        static void InsertArtist(Artist artist, NpgsqlConnection conn)
        {
            if (!IsThatArtistExists(artist))
            {
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"INSERT INTO artists VALUES (DEFAULT, @surname, @name, @secondName,
                                    (SELECT DISTINCT id FROM countries c WHERE c.name = @country),
                                    (SELECT DISTINCT id FROM movements m WHERE m.name = @movement))"
                };
                command.Parameters.AddWithValue("@name", artist.Name);
                command.Parameters.AddWithValue("@surname", artist.Surname);
                command.Parameters.AddWithValue("@secondName", artist.Second_name);
                command.Parameters.AddWithValue("@country", artist.Country.Name);
                command.Parameters.AddWithValue("@movement", artist.Movement.Name);

                command.ExecuteNonQuery();
            }
        }

        // Добавляет запись в таблицу картин
        static void InsertPicture(Artist artist, NpgsqlConnection conn)
        {
            if (!IsThatDirectoryStringExists(artist.Picture))
            {
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"INSERT INTO pictures VALUES (DEFAULT, @picture,
                                        (SELECT id FROM artists WHERE name = @name AND surname = @surname AND second_name = @second_name))"
                };
                command.Parameters.AddWithValue("@picture", artist.Picture.Name);
                command.Parameters.AddWithValue("@name", artist.Name);
                command.Parameters.AddWithValue("@surname", artist.Surname);
                command.Parameters.AddWithValue("@second_name", artist.Second_name);

                command.ExecuteNonQuery();
            }
        }

        // Добавляет запись в таблицу связку артистов с экспозициями
        static void ConnectArtistWithExpo(Artist artist, NpgsqlConnection conn)
        {
            if (!IsThatConnectionExists(artist))
            {
                command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"INSERT INTO artists_expo VALUES
                                ((SELECT id FROM artists WHERE name = @name AND surname = @surname AND second_name = @second_name),
                                (SELECT id FROM expositions WHERE name = @exposition)) ON CONFLICT DO NOTHING"
                };
                command.Parameters.AddWithValue("@name", artist.Name);
                command.Parameters.AddWithValue("@surname", artist.Surname);
                command.Parameters.AddWithValue("@second_name", artist.Second_name);
                command.Parameters.AddWithValue("@exposition", artist.Exposition.Name);

                command.ExecuteNonQuery();
            }
        }

        // Добавляет записи из пришедшего на сервер сообщения
        public static void InsertData(Artist artist)
        {
            using (var conn = new NpgsqlConnection(connection))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                // Добавляет страну в справочник
                InsertIntoDirectory(artist.Country, conn);
                // Добавляет движение в справочник
                InsertIntoDirectory(artist.Movement, conn);
                // Добавляет экспозицию в справочник
                InsertIntoDirectory(artist.Exposition, conn);

                InsertArtist(artist, conn);

                InsertPicture(artist, conn);

                ConnectArtistWithExpo(artist, conn);

                conn.Close();
            }
        }
    }
}