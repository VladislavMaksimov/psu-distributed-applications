using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_messages
{
    public class DbStringMsg
    {
        public MsgType type { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string second_name { get; set; }
        public string country { get; set; }
        public string picture { get; set; }
        public string movement { get; set; }
        public string exposition { get; set; }

        public DbStringMsg(string surname, string name, string second_name, string country, string picture, string movement, string exposition)
        {
            this.surname = surname;
            this.name = name;
            this.second_name = second_name;
            this.country = country;
            this.picture = picture;
            this.movement = movement;
            this.exposition = exposition;
            this.type = MsgType.DbString;
        }

        public DbStringMsg() { }
    }
}
