﻿using Common;
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
                newUserName = GetData("Introduce your user name: ");

                newUserNameLength = newUserName.Length;

                if (!socket.Connected)
                {
                    socket.Connect();
                }

                socket.Send(newUserName + Sep + "logon" + Sep + "NoLastMessage");

                serverReply = socket.Receive();

                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(true);

                Console.WriteLine(serverReply);
            }

            lastMessage = serverReply;

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
                    socket.Connect();
                    SendMessage(message);
                    ReceiveNewMessages(message);
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Disconnect(true);
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
                serverReply = socket.Receive();
                Console.WriteLine(serverReply);
            }
            while (serverReply != messageToCompare);

            lastMessage = serverReply;
        }

        public void SendMessage(string message)
        {
            socket.Send(userName + Sep + message + Sep + lastMessage);
        }

        public void Start()
        {
            CheckNullElement(socket);

            CheckNullElement(dataReader);

            userName = LogOn();

            socket.Close();
            socket.SocketDispose();
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

                notValid = string.IsNullOrEmpty(message) || message.Contains(Sep);

                if (notValid)
                {
                    Console.WriteLine(message + " not allowed.");
                }
            }
            while (notValid);

            return message;
        }
    }
}
