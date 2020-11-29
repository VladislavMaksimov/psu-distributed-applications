using System;
using System.Collections.Generic;
using System.Text;

namespace task_2.Tables
{
    class Artist
    {
        string name;
        string surname;
        string second_name;
        Country country;
        Movement movement;
        Picture picture;
        Exposition exposition;

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

        public Picture Picture
        {
            get
            {
                return picture;
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

        public Exposition Exposition
        {
            get
            {
                return exposition;
            }
        }

        public Artist(string name, string surname, string second_name, Country country, Movement movement, Picture picture, Exposition exposition)
        {
            this.name = name;
            this.surname = surname;
            this.second_name = second_name;
            this.country = country;
            this.movement = movement;
            this.picture = picture;
            this.exposition = exposition;
        }
    }
}
