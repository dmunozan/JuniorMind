﻿using System.Net.Sockets;

namespace Common
{
    public class MockSocketCommunication : ISocket
    {
        public MockSocketCommunication()
        {
        }

        public bool ServerIsWaiting { get; set; }

        public ISocket Accept()
        {
            return this;
        }

        public void Close()
        {
        }

        public void Listen(int backlog)
        {
            ServerIsWaiting = true;
        }

        public string Receive()
        {
            return "close server";
        }

        public void Send(string data)
        {
            throw new System.NotImplementedException();
        }

        public void Shutdown(SocketShutdown how)
        {
        }

        public void SocketDispose()
        {
        }
    }
}
