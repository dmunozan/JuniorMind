using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Common
{
    public class SocketCommunication : ISocket
    {
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

            if (mode == "server")
            {
                SetServerSocket();
            }
            else
            {
                SetClientSocket();
            }
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

        public void Shutdown(SocketShutdown how)
        {
            socket.Shutdown(how);
        }

        public void SocketDispose()
        {
            socket.Dispose();
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
