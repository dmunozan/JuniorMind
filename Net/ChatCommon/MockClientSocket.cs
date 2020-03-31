using System.Collections.Generic;
using System.Net.Sockets;

namespace Common
{
    public class MockClientSocket : ISocket
    {
        public List<string> SentMessages = new List<string>();

        public string TextToReceive { get; set; }

        public ISocket Accept()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Listen(int backlog)
        {
            throw new System.NotImplementedException();
        }

        public string Receive()
        {
            return TextToReceive;
        }

        public void Send(string data)
        {
            SentMessages.Add(data);
        }

        public void Shutdown(SocketShutdown how)
        {
            throw new System.NotImplementedException();
        }

        public void SocketDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
