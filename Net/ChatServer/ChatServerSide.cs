using Common;
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
            CheckEmptyString(user);

            users.Add(user, user);
        }

        public string CheckMessage(ISocket connectedSocket)
        {
            CheckNullElement(connectedSocket);

            string trimmedReceivedData = connectedSocket.Receive();

            const int userName = 0;
            const int sentMessage = 1;
            const int lastMessage = 2;
            const int piecesOfData = 3;

            string[] data = trimmedReceivedData?.Split("<sep>");

            if (data == null || data.Length != piecesOfData)
            {
                throw new InvalidOperationException("The received data should follow this format: 'userName<sep>sentMessage<sep>lastMessageReceived'");
            }

            CheckEmptyString(data[sentMessage]);

            if (IsNewUser(data[userName]))
            {
                AddUser(data[userName]);

                string message = "server: " + data[userName] + " joined the chat.";

                chatMessages.Add(message);

                connectedSocket.Send(message);
            }
            else
            {
                chatMessages.Add(data[userName] + ": " + data[sentMessage]);

                SendNewMessages(connectedSocket, data[lastMessage]);
            }

            return data[1];
        }

        public bool IsNewUser(string user)
        {
            return !users.ContainsKey(user);
        }

        public void SendNewMessages(ISocket connectedSocket, string lastMessage)
        {
            CheckNullElement(connectedSocket);

            CheckNullElement(lastMessage);

            CheckEmptyString(lastMessage);

            int lastMessageReceived = chatMessages.LastIndexOf(lastMessage);

            if (lastMessageReceived == -1)
            {
                throw new ArgumentException("The message doesn't exist", nameof(lastMessage));
            }

            for (int i = lastMessageReceived + 1; i < chatMessages.Count; i++)
            {
                connectedSocket.Send(chatMessages[i]);
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
                trimmedReceivedData = CheckMessage(connectedSocket);
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

        private void CheckEmptyString(string test)
        {
            if (test != "")
            {
                return;
            }

            throw new ArgumentException("Empty string not allowed", nameof(test));
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
