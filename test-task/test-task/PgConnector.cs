using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using test_task.Tables;

namespace test_task
{
    class PgConnector
    {
        static string connection = new NpgsqlConnectionStringBuilder()
        {
            Host = "localhost",
            //Port = 5432,
            Username = "postgres",
            Password = "1234",
            Database = "artists"
        }.ConnectionString;

        static NpgsqlCommand command;

        static void addOrUpdateArtist(HashSet<Artist> artists, Artist artist)
        {
            foreach(Artist exArtist in artists)
            {
                if (exArtist.Name == artist.Name && exArtist.Second_name == artist.Second_name && exArtist.Surname == artist.Surname)
                {
                    exArtist.Pictures.Add(artist.Pictures.First());
                    exArtist.Expositions.Add(artist.Expositions.First());
                    return;
                }
            }
            artists.Add(artist);
        }

        static void insertArtists(HashSet<Artist> artists)
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

                foreach (Artist artist in artists)
                {
                    command = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"INSERT INTO artists VALUES (DEFAULT, @name, @surname, @secondName, (SELECT DISTINCT id FROM countries c WHERE c.name = @country), (SELECT DISTINCT id FROM movements m WHERE m.name = @movement))"
                    };
                    command.Parameters.AddWithValue("@name", artist.Name);
                    command.Parameters.AddWithValue("@surname", artist.Surname);
                    command.Parameters.AddWithValue("@secondName", artist.Second_name);
                    command.Parameters.AddWithValue("@country", artist.Country.Name);
                    command.Parameters.AddWithValue("@movement", artist.Movement.Name);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    foreach (Picture picture in artist.Pictures)
                    {
                        command = new NpgsqlCommand
                        {
                            Connection = conn,
                            CommandText = @"UPDATE pictures SET (id_artist) = ((SELECT MAX(id) FROM artists)) WHERE name = @name"
                        };
                        command.Parameters.AddWithValue("@name", picture.Name);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    foreach (Exposition exposition in artist.Expositions)
                    {
                        command = new NpgsqlCommand
                        {
                                Connection = conn,
                                CommandText = @"INSERT INTO artists_expo VALUES((SELECT MAX(id) FROM artists),(SELECT DISTINCT id FROM expositions WHERE name = @name));"
                        };
                        command.Parameters.AddWithValue("@name", exposition.Name);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                conn.Close();
            }
        }

        static int getMaxKey<T>(Dictionary<int, T>.KeyCollection keys)
        {
            int maxKey = 0;
            foreach (int key in keys)
            {
                if (key > maxKey)
                    maxKey = key;
            }
            return maxKey;
        }

        static void insertDirectory(HashSet<string> dict, string table)
        {
            using (var conn = new NpgsqlConnection(connection))
            {
                try
                {
                    conn.Open();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                foreach (string name in dict) {
                    command = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"INSERT INTO " + table + @" VALUES (CASE WHEN(SELECT MAX(id) FROM " + table + @") is NULL THEN 0 ELSE (SELECT MAX(id)+1 FROM " + table + @" ) END, @name)"
                    };
                    command.Parameters.AddWithValue("@name", name);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                conn.Close();
            }
        }
     
        static void setDirectory(HashSet<string> dict, string value)
        {
            if (!dict.Contains(value))
                dict.Add(value);
        }

        static public void insert(DataTable data)
        {
            HashSet<string> countries = new HashSet<string>();
            HashSet<string> movements = new HashSet<string>();
            HashSet<string> pictures = new HashSet<string>();
            HashSet<string> expositions = new HashSet<string>();

            HashSet<Artist> artists = new HashSet<Artist>();

            foreach (DataRow row in data.Rows)
            { 
                Country country = new Country(row["country"].ToString());
                Exposition exposition = new Exposition(row["exposition"].ToString());
                Movement movement = new Movement(row["movement"].ToString());
                Picture picture = new Picture(row["picture"].ToString());

                string name = row["name"].ToString();
                string surname = row["surname"].ToString();
                string second_name = row["second_name"].ToString();

                setDirectory(countries, country.Name);
                setDirectory(movements, movement.Name);
                setDirectory(pictures, picture.Name);
                setDirectory(expositions, exposition.Name);

                Artist artist = new Artist(name, surname, second_name, country, movement, picture, exposition);
                addOrUpdateArtist(artists, artist);
            }

            insertDirectory(countries, "countries");
            insertDirectory(movements, "movements");
            insertDirectory(pictures, "pictures");
            insertDirectory(expositions, "expositions");

            insertArtists(artists);
        }

    }
}
