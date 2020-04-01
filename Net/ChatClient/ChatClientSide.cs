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
            string serverReply = "exist";
            string userName = "";

            while (serverReply.IndexOf("exist") > -1)
            {
                userName = dataReader.Read("Introduce your user name:");

                socket.Send(userName + "<sep>logon<sep>NoLastMessage");

                serverReply = socket.Receive();

                Console.WriteLine(serverReply);
            }

            return userName;
        }
    }
}
