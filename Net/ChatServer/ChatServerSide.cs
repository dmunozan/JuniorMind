using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ChatServer
{
    public class ChatServerSide
    {
        const string EOF = "<eof>";

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

            const string SEP = "<sep>";

            string[] data = trimmedReceivedData?.Split(SEP);

            if (data == null || data.Length != piecesOfData || data[lastMessage].IndexOf(EOF) == -1)
            {
                throw new InvalidOperationException("The received data should follow this format: 'userName" + SEP + "sentMessage" + SEP + "lastMessageReceived" + EOF + "'");
            }

            CheckEmptyString(data[sentMessage]);

            if (IsNewUser(data[userName]))
            {
                AddUser(data[userName]);

                string message = "server: " + data[userName] + " joined the chat.";

                chatMessages.Add(message);

                connectedSocket.Send(message + EOF);
            }
            else
            {
                int indexOfLastMessage = chatMessages.LastIndexOf(data[lastMessage].Replace(EOF, ""));

                if (indexOfLastMessage == -1)
                {
                    connectedSocket.Send("server: " + data[userName] + " already exist, choose a different user name." + EOF);
                }
                else
                {
                    chatMessages.Add(data[userName] + ": " + data[sentMessage]);

                    SendNewMessages(connectedSocket, indexOfLastMessage);
                }
            }

            return data[1];
        }

        public bool IsNewUser(string user)
        {
            return !users.ContainsKey(user);
        }

        public void SendNewMessages(ISocket connectedSocket, int indexOfLastMessage)
        {
            CheckNullElement(connectedSocket);

            if (indexOfLastMessage == -1)
            {
                throw new ArgumentException("The message doesn't exist", nameof(indexOfLastMessage));
            }

            for (int i = indexOfLastMessage + 1; i < chatMessages.Count; i++)
            {
                connectedSocket.Send(chatMessages[i] + EOF);
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
