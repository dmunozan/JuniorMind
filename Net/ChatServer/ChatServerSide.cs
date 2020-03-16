using Common;
using System;
using System.Collections;
using System.Net.Sockets;

namespace ChatServer
{
    public class ChatServerSide
    {
        private readonly Hashtable users = new Hashtable();
        private readonly ISocket socket;

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
            trimmedReceivedData ??= "";

            string[] data = trimmedReceivedData.Split("<sep>");

            AddUser(data[0]);

            return data[1];
        }

        public bool IsNewUser(string user)
        {
            return !users.ContainsKey(user);
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
                trimmedReceivedData = connectedSocket.Receive();
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
