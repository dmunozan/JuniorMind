using Common;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ChatClient
{
    public class ChatClientSide
    {
        const string SEP = "<sep>";
        const string EOF = "<eof>";
        private readonly ISocket socket;
        private readonly IReader dataReader;
        private readonly List<string> chatMessages = new List<string>();
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
                newUserName = GetData("Introduce your user name: ");

                newUserNameLength = newUserName.Length;

                socket.SetSocket();

                socket.Send(newUserName + SEP + "logon" + SEP + "NoLastMessage" + EOF);

                serverReply = socket.Receive().Replace(EOF, "");

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket.SocketDispose();

                Console.WriteLine(serverReply);
            }

            lastMessage = serverReply;

            chatMessages.Add(serverReply);

            return newUserName;
        }

        public void ProcessChat()
        {
            string message;
            do
            {
                message = GetData(userName + ": ");

                if (message != "exit")
                {
                    socket.SetSocket();

                    SendMessage(message);
                    ReceiveNewMessages(message);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket.SocketDispose();
                }
            }
            while (message != "exit");
        }

        public void ReceiveNewMessages(string sentMessage)
        {
            string messageToCompare = userName + ": " + sentMessage;
            string serverReply;

            do
            {
                serverReply = socket.Receive().Replace(EOF, "");
                chatMessages.Add(serverReply);
            }
            while (serverReply != messageToCompare);

            Console.Clear();
            PrintChatMessages();

            lastMessage = serverReply;
        }

        public void SendMessage(string message)
        {
            socket.Send(userName + SEP + message + SEP + lastMessage + EOF);
        }

        public void Start()
        {
            CheckNullElement(socket);

            CheckNullElement(dataReader);

            userName = LogOn();

            ProcessChat();

            Console.WriteLine("Closing client");
        }

        private void CheckNullElement(object obj)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj), "Not allowed null element.");
        }

        private string GetData(string textToShow)
        {
            string message;
            bool notValid;

            do
            {
                message = dataReader.Read(textToShow);

                notValid = string.IsNullOrEmpty(message) || message.Contains(SEP) || message.Contains(EOF);

                if (notValid)
                {
                    Console.WriteLine(message + " not allowed.");
                }
            }
            while (notValid);

            return message;
        }

        private void PrintChatMessages()
        {
            foreach (string str in chatMessages)
            {
                Console.WriteLine(str);
            }
        }
    }
}
