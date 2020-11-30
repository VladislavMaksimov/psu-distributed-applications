using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Text.Json;
using MsgType = task_2_messages.MsgType;
using DbStringMsg = task_2_messages.DbStringMsg;
using DESDbStringMes = task_2_messages.DESDbStingMes;
using SendKeyMsg = task_2_messages.SendKeyMsg;
using task_2.Tables;

namespace task_2_server
{
    class Server
    {
        public class ServerBehavior : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                MsgType msgType = (MsgType)JsonDocument.Parse(e.Data).RootElement.GetProperty("type").GetInt32();

                if (msgType == MsgType.GetKey)
                {
                    Console.WriteLine("Client asks for public key");
                    SendKeyMsg sendKeyMsg = new SendKeyMsg(Decryptor.RSACreateKeys());
                    string serializedMsg = JsonSerializer.Serialize<SendKeyMsg>(sendKeyMsg);
                    Send(serializedMsg);
                }

                if (msgType == MsgType.DES)
                {
                    DESDbStringMes ecnryptedDbString = JsonSerializer.Deserialize<DESDbStringMes>(e.Data);
                    DESDbStringMes testEncDbString = JsonSerializer.Deserialize<DESDbStringMes>(e.Data); 
                    ecnryptedDbString.Key = Decryptor.RSAdecrypt(ecnryptedDbString.Key);
                    string serializedDbString = Decryptor.DESdecrypt(ecnryptedDbString);
                    DbStringMsg dbString = JsonSerializer.Deserialize<DbStringMsg>(serializedDbString);

                    Console.WriteLine(dbString.surname + ' ' + dbString.name + ' ' + dbString.second_name + ' ' +
                        dbString.country + ' ' + dbString.picture + ' ' + dbString.exposition);

                    Artist artist = new Artist(
                        dbString.name, dbString.surname, dbString.second_name,
                        new Country(dbString.country), new Movement(dbString.movement), new Picture(dbString.picture),
                        new Exposition(dbString.exposition)
                    );

                    PgConnector.InsertData(artist);

                    //Send("You just have sent \"" + e.Data + "\" to me.");
                }
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
