using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Data.SQLite;

namespace task_2_client
{
    class SQLiteConnector
    {
        static string dbFileName = "bad-db.db";
        static SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
        static public DataTable get()
        {
            DataTable dTable = new DataTable();

            try
            {
                m_dbConn.Open();
                
                string sqlQuery = "SELECT * FROM bad_table";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);

                adapter.Fill(dTable);

                m_dbConn.Close();
            }
            catch (SQLiteException ex)
            {
               Console.WriteLine(ex.Message);
            }

            return dTable;
        }

    }
}