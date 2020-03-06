using System;
using System.Net;
using System.Net.Sockets;
using Xunit;

namespace Common.Tests
{
    public class SocketCommunicationTests
    {
        [Fact]
        public void SetSocketWhenModeIsNotValidShouldThrowException()
        {
            SocketCommunication testSocket = new SocketCommunication("server");

            Assert.Throws<ArgumentException>(() => testSocket.SetSocket("invalid"));
        }

        [Fact]
        public void SetSocketWhenModeIsNullShouldThrowException()
        {
            SocketCommunication testSocket = new SocketCommunication("server");

            Assert.Throws<ArgumentNullException>(() => testSocket.SetSocket(null));
        }

        [Fact]
        public void ServerSocketValidationWhenValidSocketAndEndPointShouldReturnTrue()
        {
            SocketCommunication testSocket = new SocketCommunication("server");

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 1111);

            Socket tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            Assert.True(testSocket.ServerSocketValidation(tempSocket, endPoint));

            tempSocket.Close();
            tempSocket.Dispose();
        }
    }
}
