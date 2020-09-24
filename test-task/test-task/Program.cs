using System;
using System.IO;

namespace test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataTable painters = SQLiteConnector.get();
            Console.WriteLine(Directory.GetCurrentDirectory());
            //PgConnector.insert(painters);
        }
    }
}
