﻿using System;
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

        public void SetSocket(string mode)
        {
            CheckNullElement(mode);

            if (mode != "server" && mode != "client")
            {
                throw new ArgumentException("Modes allowed are server or client", nameof(mode));
            }

            string host = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(host);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint endPoint = new IPEndPoint(address, 1111);

                Socket tempSocket = null;

                try
                {
                    tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    if ((mode == "server" && ServerSocketValidation(tempSocket, endPoint)) || (mode == "client" && ClientSocketValidation(tempSocket, endPoint)))
                    {
                        socket = tempSocket;
                        break;
                    }
                }
                finally
                {
                    tempSocket.Dispose();
                }
            }
        }

        public bool ServerSocketValidation(Socket tempSocket, IPEndPoint endPoint)
        {
            if (tempSocket == null)
            {
                return false;
            }

            tempSocket.Bind(endPoint);

            return tempSocket.IsBound;
        }

        public bool ClientSocketValidation(Socket tempSocket, IPEndPoint endPoint)
        {
            if (tempSocket == null)
            {
                return false;
            }

            tempSocket.Connect(endPoint);

            return tempSocket.Connected;
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