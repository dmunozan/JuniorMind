using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Common
{
    public class SocketCommunication : ISocket
    {
        private Socket socket;

        public SocketCommunication(string mode)
        {
            SetSocket(mode);
        }

        public string Receive()
        {
            const int ByteAllocation = 256;
            byte[] receivedBytes;
            string trimmedReceivedData = "";

            while (socket.Available != 0)
            {
                receivedBytes = new byte[ByteAllocation];
                socket.Receive(receivedBytes);
                trimmedReceivedData += Encoding.UTF8.GetString(receivedBytes).TrimEnd('\0');
            }

            return trimmedReceivedData;
        }

        public void Send(string data)
        {
            byte[] receivedBytes = Encoding.UTF8.GetBytes(data);
            socket.Send(receivedBytes);
        }

        private void SetSocket(string mode)
        {
            string host = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint endPoint = new IPEndPoint(address, 1111);
                Socket tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                if ((mode == "server" && ServerSocketValidation(tempSocket, endPoint)) || (mode == "client" && ClientSocketValidation(tempSocket, endPoint)))
                {
                    socket = tempSocket;
                    break;
                }

                tempSocket.Dispose();
            }
        }

        private bool ServerSocketValidation(Socket tempSocket, IPEndPoint endPoint)
        {
            tempSocket.Bind(endPoint);

            return tempSocket.IsBound;
        }

        private bool ClientSocketValidation(Socket tempSocket, IPEndPoint endPoint)
        {
            tempSocket.Connect(endPoint);

            return tempSocket.Connected;
        }
    }
}
