using System;
using System.Collections.Generic;
using System.Text;

namespace test_task.Tables
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

        public static bool operator == (Directory d1, Directory d2)
        {
            if (d1.name == d2.name)
                return true;
            else
                return false;
        }

        public static bool operator != (Directory d1, Directory d2)
        {
            if (d1.name != d2.name)
                return true;
            else
                return false;
        }
    }
}
