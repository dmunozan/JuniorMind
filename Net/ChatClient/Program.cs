using Common;
using System;

namespace ChatClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Entry point");

            SocketCommunication socket = new SocketCommunication("client");

            DataReader dataReader = new DataReader();

            ChatClientSide client = new ChatClientSide(socket, dataReader);

            client.Start();
        }
    }
}
