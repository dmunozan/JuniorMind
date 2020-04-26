using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Common
{
    public class SocketCommunication : ISocket
    {
        const int DataSizeLength = 4;
        const int Port = 1111;
        private Socket socket;
        private EndPoint endPoint;

        public SocketCommunication(string mode)
        {
            CheckNullElement(mode);

            if (mode != "server" && mode != "client")
            {
                throw new ArgumentException("Modes allowed are server or client", nameof(mode));
            }

            if (mode != "server")
            {
                return;
            }

            SetServerSocket();
        }

        public SocketCommunication(Socket newSocket)
        {
            socket = newSocket;
        }

        public bool Connected
        {
            get { return socket.Connected; }
        }

        public ISocket Accept()
        {
            return new SocketCommunication(socket.Accept());
        }

        public void Close()
        {
            socket.Close();
        }

        public void Connect()
        {
            socket.Connect(endPoint);
        }

        public void Disconnect(bool reuseSocket)
        {
            socket.Disconnect(reuseSocket);
        }

        public void Listen(int backlog)
        {
            socket.Listen(backlog);
        }

        public string Receive()
        {
            byte[] bytesToReceive = new byte[DataSizeLength];
            int bytes = 0;
            string trimmedReceivedData = "";

            socket.Receive(bytesToReceive, DataSizeLength, 0);
            int dataSize = BitConverter.ToInt32(bytesToReceive);

            bytesToReceive = new byte[dataSize];

            do
            {
                bytes += socket.Receive(bytesToReceive, dataSize, 0);
                trimmedReceivedData += Encoding.UTF8.GetString(bytesToReceive, 0, bytes);
            }
            while (bytes < dataSize);

            return trimmedReceivedData;
        }

        public void Send(string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] dataSize = BitConverter.GetBytes(dataBytes.Length);
            byte[] bytesToSend = new byte[dataBytes.Length + DataSizeLength];

            dataSize.CopyTo(bytesToSend, 0);
            dataBytes.CopyTo(bytesToSend, DataSizeLength);

            socket.Send(bytesToSend);
        }

        public void SetSocket()
        {
            SetClientSocket();
        }

        public void Shutdown(SocketShutdown how)
        {
            socket.Shutdown(how);
        }

        public void SocketDispose()
        {
            socket.Dispose();
        }

        private void SetClientSocket()
        {
            string host = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                endPoint = new IPEndPoint(address, Port);

                Socket tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(endPoint);

                if (tempSocket.Connected)
                {
                    socket = tempSocket;
                    break;
                }

                tempSocket.Dispose();
            }
        }

        private void SetServerSocket()
        {
            string host = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                endPoint = new IPEndPoint(address, Port);

                Socket tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Bind(endPoint);

                if (tempSocket.IsBound)
                {
                    socket = tempSocket;
                    break;
                }

                tempSocket.Dispose();
            }
        }

        private void CheckNullElement(object obj)
        {
            if (obj != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(obj));
        }
    }
}
