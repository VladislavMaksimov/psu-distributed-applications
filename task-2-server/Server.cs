using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace task_2_server
{
    class Server
    {
        public class ServerBehavior : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
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
