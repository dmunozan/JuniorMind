using System.Net.Sockets;

namespace Common
{
    public interface ITransfer
    {
        public string ReceiveData(Socket socket);

        public void SendData(Socket socket, string text);
    }
}
