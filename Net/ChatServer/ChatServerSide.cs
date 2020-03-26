﻿using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ChatServer
{
    public class ChatServerSide
    {
        private readonly Hashtable users = new Hashtable();
        private readonly ISocket socket;
        private readonly List<string> chatMessages = new List<string>();

        public ChatServerSide()
        {
            socket = null;
        }

        public ChatServerSide(ISocket newSocket)
        {
            socket = newSocket;
        }

        public void AddUser(string user)
        {
            if (user == "")
            {
                throw new ArgumentException("Empty string not allowed as user name", nameof(user));
            }

            users.Add(user, user);
        }

        public string CheckMessage(string trimmedReceivedData)
        {
            CheckNullElement(trimmedReceivedData);

            const int userName = 0;
            const int sentMessage = 1;
            const int lastMessage = 2;
            const int piecesOfData = 3;

            string[] data = trimmedReceivedData.Split("<sep>");

            if (data.Length != piecesOfData)
            {
                throw new ArgumentException("The received data should follow this format: 'userName<sep>sentMessage<sep>lastMessageReceived'", nameof(trimmedReceivedData));
            }

            if (data[sentMessage] == "")
            {
                throw new ArgumentException("The message part cannot be an empty string", nameof(trimmedReceivedData));
            }

            if (IsNewUser(data[userName]))
            {
                AddUser(data[userName]);

                socket.Send("server: You joined the chat.");
            }
            else
            {
                chatMessages.Add(data[userName] + ": " + data[sentMessage]);

                SendNewMessages(data[lastMessage]);
            }

            return data[1];
        }

        public bool IsNewUser(string user)
        {
            return !users.ContainsKey(user);
        }

        public void SendNewMessages(string lastMessage)
        {
            CheckNullElement(lastMessage);

            if (lastMessage == "")
            {
                throw new ArgumentException("Empty string not allowed", nameof(lastMessage));
            }

            int lastMessageReceived = chatMessages.LastIndexOf(lastMessage);

            for (int i = lastMessageReceived + 1; i < chatMessages.Count; i++)
            {
                socket.Send(chatMessages[i]);
            }
        }

        public void Start()
        {
            CheckNullElement(socket);

            string trimmedReceivedData = "";
            while (trimmedReceivedData != "close server")
            {
                Console.WriteLine("Waiting for connections...");
                socket.Listen(1);
                ISocket connectedSocket = socket.Accept();
                Console.WriteLine("Connection accepted.");
                trimmedReceivedData = CheckMessage(connectedSocket.Receive());
                Console.WriteLine("Closing connection.");
                try
                {
                    connectedSocket.Shutdown(SocketShutdown.Both);
                    connectedSocket.Close();
                    connectedSocket.SocketDispose();
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Socket error: " + e.ErrorCode);
                }
            }

            Console.WriteLine("Closing server.");
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
    }
}
