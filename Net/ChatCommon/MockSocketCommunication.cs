using System.Collections.Generic;
using System.Net.Sockets;

namespace Common
{
    public class MockSocketCommunication : ISocket
    {
        public List<string> SentMessages = new List<string>();

        public MockSocketCommunication()
        {
        }

        public bool ServerIsWaiting { get; set; }

        public string TextToReceive { get; set; }

        public string TrimmedReceivedData { get; set; } = "";

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
            if (TrimmedReceivedData == "")
            {
                TrimmedReceivedData = TextToReceive;
            }

            return TextToReceive;
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
            TextToReceive = "testUser<sep>close server<sep>server: testUser joined the chat.";
        }
    }
}
