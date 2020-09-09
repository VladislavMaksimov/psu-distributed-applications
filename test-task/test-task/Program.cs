using System;

namespace test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataTable painters = SQLiteConnector.get();
            PgConnector.insert(painters);
        }
    }
}
