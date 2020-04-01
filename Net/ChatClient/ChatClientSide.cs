using Common;
using System;

namespace ChatClient
{
    public class ChatClientSide
    {
        private readonly ISocket socket;
        private readonly IReader dataReader;

        public ChatClientSide(ISocket newSocket, IReader newDataReader)
        {
            socket = newSocket;
            dataReader = newDataReader;
        }

        public string LogOn()
        {
            string userName = dataReader.Read("Introduce your user name:");

            socket.Send(userName + "<sep>logon<sep>NoLastMessage");

            string serverReply = socket.Receive();

            Console.WriteLine(serverReply);

            return userName;
        }
    }
}
