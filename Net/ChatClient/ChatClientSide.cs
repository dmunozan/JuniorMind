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
            const int toIgnore = 8;
            int userNameLength = 0;
            string serverReply = "server: exist";
            string userName = "";

            while (serverReply.Substring(toIgnore + userNameLength).Contains("exist"))
            {
                userName = dataReader.Read("Introduce your user name:");

                if (string.IsNullOrEmpty(userName) || userName.Contains("<sep>"))
                {
                    Console.WriteLine(userName + " user name not allowed.");
                }
                else
                {
                    userNameLength = userName.Length;

                    socket.Send(userName + "<sep>logon<sep>NoLastMessage");

                    serverReply = socket.Receive();

                    Console.WriteLine(serverReply);
                }
            }

            return userName;
        }
    }
}
