using System;
using System.Net;
using System.Net.Sockets;
using Xunit;

namespace Common.Tests
{
    public class SocketCommunicationTests
    {
        [Fact]
        public void ConstructorWhenModeIsNotValidShouldThrowException()
        {
            SocketCommunication testSocket;

            Assert.Throws<ArgumentException>(() => testSocket = new SocketCommunication("invalid"));
        }

        [Fact]
        public void ConstructortWhenModeIsNullShouldThrowException()
        {
            SocketCommunication testSocket;

            Assert.Throws<ArgumentNullException>(() => testSocket = new SocketCommunication((string)null));
        }
    }
}
