using System;
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
    }
}
