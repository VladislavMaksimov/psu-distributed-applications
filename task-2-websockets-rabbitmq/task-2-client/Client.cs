using System;
using WebSocket = WebSocketSharp.WebSocket;
using System.Text.Json;
using DataTable = System.Data.DataTable;
using DataRow = System.Data.DataRow;
using DbStringMsg = task_2_messages.DbStringMsg;
using System.Collections.Generic;

namespace task_2
{
    class Client
    {
        static public List<DbStringMsg> createDbStringMsgList(DataTable table)
        {
            List<DbStringMsg> dbStringMsgs = new List<DbStringMsg>();

            foreach (DataRow row in table.Rows)
            {
                string surname = row["surname"].ToString();
                string name = row["name"].ToString();
                string second_name = row["second_name"].ToString();
                string country = row["country"].ToString();
                string picture = row["picture"].ToString();
                string movement = row["movement"].ToString();
                string exposition = row["exposition"].ToString();

                DbStringMsg dbStrMsg = new DbStringMsg(surname, name, second_name, country, picture, movement, exposition);
                dbStringMsgs.Add(dbStrMsg);
            }
            
            return dbStringMsgs;
        }

        static void Main(string[] args)
        {
            DataTable painters = SQLiteConnector.get();
            List<DbStringMsg> dbStringMsgs = createDbStringMsgList(painters);

            using (var ws = new WebSocket("ws://localhost:8080/"))
            {
                ws.OnOpen += (sender, e) => Console.WriteLine("Connected to server.");
                ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);
                ws.Connect();

                foreach (var dbStringMsg in dbStringMsgs)
                {
                    string msg = JsonSerializer.Serialize<DbStringMsg>(dbStringMsg);
                    ws.Send(msg);
                }

                Console.ReadKey(true);
                ws.Close();
            }
        }
    }
}
