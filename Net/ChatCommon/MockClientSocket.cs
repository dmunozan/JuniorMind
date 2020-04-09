using System.Collections.Generic;
using System.Net.Sockets;

namespace Common
{
    public class MockClientSocket : ISocket
    {
        public List<string> SentMessages = new List<string>();

        public List<string> ReceivedMessages = new List<string>();

        public List<string> ListToReceive = new List<string>();
        private int index;

        public bool Connected { get; private set; } = true;

        public ISocket Accept()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Connect()
        {
            Connected = true;
        }

        public void Disconnect(bool reuseSocket)
        {
            Connected = false;
        }

        public void Listen(int backlog)
        {
            throw new System.NotImplementedException();
        }

        public string Receive()
        {
            string message = ListToReceive[index++];
            ReceivedMessages.Add(message);
            return message;
        }

        public void Send(string data)
        {
            SentMessages.Add(data);
        }

        public void Shutdown(SocketShutdown how)
        {
        }

        public void SocketDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
