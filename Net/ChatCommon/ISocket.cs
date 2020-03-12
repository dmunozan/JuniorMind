using System.Net.Sockets;

namespace Common
{
    public interface ISocket
    {
        public ISocket Accept();

        public void Close();

        public void Listen(int backlog);

        public string Receive();

        public void Send(string data);

        public void Shutdown(SocketShutdown how);

        public void SocketDispose();
    }
}
