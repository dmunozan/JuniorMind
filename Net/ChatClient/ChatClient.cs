﻿using System.Net.Sockets;
using Common;

namespace ChatClient
{
    public class ChatClient : ISocket
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
