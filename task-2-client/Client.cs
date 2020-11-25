using System;
using WebSocket = WebSocketSharp.WebSocket;
using System.Text.Json;

namespace task_2
{
    class Client
    {
        static void Main(string[] args)
        {
            //JsonSerializer.Serialize
            using (var ws = new WebSocket("ws://localhost:8080/"))
            {
                ws.OnOpen += (sender, e) => Console.WriteLine("Connected to server.");
                ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);
                ws.Connect();

                while (true)
                {
                    string msg = Console.ReadLine();
                    ws.Send(msg);
                }
            }
        }
    }
}
