﻿using System.Net.Sockets;
using Common;

namespace ChatServer
{
    public class ChatServer : ISocket
    {
        public string ReceiveData(Socket socket)
        {
            throw new System.NotImplementedException();
        }

        public void SendData(Socket socket, string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
