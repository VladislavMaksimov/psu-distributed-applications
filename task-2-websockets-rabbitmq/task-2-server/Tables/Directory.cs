using System;
using System.Collections.Generic;
using System.Text;

namespace task_2.Tables
{
    abstract class Directory
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Directory(string name)
        {
            this.name = name;
        }
    }
}
