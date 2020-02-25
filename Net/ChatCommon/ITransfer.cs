using System.Net.Sockets;

namespace Common
{
    interface ITransfer
    {
        public string ReceiveData(Socket socket);

        public void SendData(Socket socket, string text);
    }
}
