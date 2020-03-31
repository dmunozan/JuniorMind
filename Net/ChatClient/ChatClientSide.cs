using Common;
using System;

namespace ChatClient
{
    public class ChatClientSide
    {
        private readonly ISocket socket;

        public ChatClientSide(ISocket newSocket)
        {
            socket = newSocket;
        }

        public string LogOn(string userName = null)
        {
            userName ??= ReadData("Introduce your user name:");

            socket.Send(userName + "<sep>logon<sep>NoLastMessage");

            string serverReply = socket.Receive();

            Console.WriteLine(serverReply);

            return userName;
        }

        private string ReadData(string textToShow)
        {
            Console.WriteLine(textToShow);
            return Console.ReadLine();
        }
    }
}
