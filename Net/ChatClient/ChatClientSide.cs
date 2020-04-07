using Common;
using System;
using System.Net.Sockets;

namespace ChatClient
{
    public class ChatClientSide
    {
        const string Sep = "<sep>";
        private readonly ISocket socket;
        private readonly IReader dataReader;
        private string userName;
        private string lastMessage;

        public ChatClientSide(ISocket newSocket, IReader newDataReader)
        {
            socket = newSocket;
            dataReader = newDataReader;
        }

        public string LogOn()
        {
            const int toIgnore = 8;
            int newUserNameLength = 0;
            string serverReply = "server: exist";
            string newUserName = "";

            while (serverReply.Substring(toIgnore + newUserNameLength).Contains("exist"))
            {
                newUserName = dataReader.Read("Introduce your user name: ");

                if (string.IsNullOrEmpty(newUserName) || newUserName.Contains("<sep>"))
                {
                    Console.WriteLine(newUserName + " user name not allowed.");
                }
                else
                {
                    newUserNameLength = newUserName.Length;

                    if (!socket.Connected)
                    {
                        socket.Connect();
                    }

                    socket.Send(newUserName + "<sep>logon<sep>NoLastMessage");

                    serverReply = socket.Receive();

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Disconnect(true);

                    Console.WriteLine(serverReply);
                }
            }

            lastMessage = serverReply;

            return newUserName;
        }

        public string SendMessage()
        {
            socket.Connect();

            string message = dataReader.Read(userName + ": ");

            socket.Send(userName + Sep + message + Sep + lastMessage);

            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(true);

            return message;
        }

        public void Start()
        {
            CheckNullElement(socket);

            CheckNullElement(dataReader);

            userName = LogOn();
        }

        private void CheckNullElement(object obj)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj), "Not allowed null element.");
        }
    }
}
