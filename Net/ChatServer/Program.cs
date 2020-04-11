using Common;
using System;

namespace ChatServer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Entry point");

            SocketCommunication socket = new SocketCommunication("server");

            ChatServerSide server = new ChatServerSide(socket);

            server.Start();
        }
    }
}
