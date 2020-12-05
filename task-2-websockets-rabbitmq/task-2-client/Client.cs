using System;
using WebSocket = WebSocketSharp.WebSocket;
using System.Text.Json;
using DataTable = System.Data.DataTable;
using DataRow = System.Data.DataRow;
using DbStringMsg = task_2_messages.DbStringMsg;
using DESDbStringMes = task_2_messages.DESDbStingMes;
using GetKeyMsg = task_2_messages.GetKeyMsg;
using MsgType = task_2_messages.MsgType;
using System.Collections.Generic;

namespace task_2_client
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
                ws.OnMessage += (sender, e) =>
                {
                    MsgType msgType = (MsgType)JsonDocument.Parse(e.Data).RootElement.GetProperty("type").GetInt32();
                    if (msgType == MsgType.SendKey)
                    {
                        string publicKey = JsonDocument.Parse(e.Data).RootElement.GetProperty("key").ToString();
                        Encryptor.publicKey = publicKey;
                        Console.WriteLine("Server send public key: " + publicKey);

                        foreach (var dbStringMsg in dbStringMsgs)
                        {
                            string msg = JsonSerializer.Serialize<DbStringMsg>(dbStringMsg);
                            DESDbStringMes decMsg = Encryptor.DESencrypt(msg);
                            decMsg.Key = Encryptor.RSAencrypt(decMsg.Key);
                            msg = JsonSerializer.Serialize<DESDbStringMes>(decMsg);
                            ws.Send(msg);
                        }
                    }
                    else
                        Console.WriteLine(e.Data);
                };

                ws.Connect();
                string getKeyMsg = JsonSerializer.Serialize<GetKeyMsg>(new GetKeyMsg());
                ws.Send(getKeyMsg);
                Console.ReadKey(true);
                ws.Close();
            }
        }
    }
}
