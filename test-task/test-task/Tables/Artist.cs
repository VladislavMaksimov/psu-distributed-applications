using System;
using System.Collections.Generic;
using System.Text;

namespace test_task.Tables
{
    class Artist
    {
        string name;
        string surname;
        string second_name;
        Country country;
        Movement movement;
        List<Picture> pictures = new List<Picture>();
        List<Exposition> expositions = new List<Exposition>();

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
        }

        public string Second_name
        {
            get
            {
                return second_name;
            }
        }

        public List<Picture> Pictures
        {
            get
            {
                return pictures;
            }
        }

        public Country Country
        {
            get
            {
                return country;
            }
        }

        public Movement Movement
        {
            get
            {
                return movement;
            }
        }

        public List<Exposition> Expositions
        {
            get
            {
                return expositions;
            }
        }

        public Artist(string name, string surname, string second_name, Country country, Movement movement, Picture picture, Exposition exposition)
        {
            this.name = name;
            this.surname = surname;
            this.second_name = second_name;
            this.country = country;
            this.movement = movement;
            this.pictures.Add(picture);
            this.expositions.Add(exposition);
        }
    }
}
