using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Text.Json;
using MsgType = task_2_messages.MsgType;
using DbStringMsg = task_2_messages.DbStringMsg;

namespace task_2_server
{
    class Server
    {
        public class ServerBehavior : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                MsgType msgType = (MsgType)JsonDocument.Parse(e.Data).RootElement.GetProperty("type").GetInt32();

                if (msgType == MsgType.DbString)
                {
                    DbStringMsg dbString = JsonSerializer.Deserialize<DbStringMsg>(e.Data);
                    Console.WriteLine(dbString.surname + ' ' + dbString.name + ' ' + dbString.second_name + ' ' +
                        dbString.country + ' ' + dbString.picture + ' ' + dbString.exposition);
                }

                Send("You just have sent \"" + e.Data + "\" to me.");
            }
        }

        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:8080");
            wssv.AddWebSocketService<ServerBehavior>("/");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}
