using Common;
using System;
using Xunit;

namespace ChatServer.Tests
{
    public class ChatServerSideTests
    {
        [Fact]
        public void AddUserWhenNewUserShouldAddUserToHashTableAndReturnTrue()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.True(server.AddUser("newUser"));
        }

        [Fact]
        public void AddUserWhenAlreadyExistingUserShouldReturnFalse()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.True(server.AddUser("newUser"));
            Assert.False(server.AddUser("newUser"));
        }

        [Fact]
        public void AddUserWhenNullUserShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentNullException>(() => server.AddUser(null));
        }

        [Fact]
        public void AddUserWhenEmptyUserShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentException>(() => server.AddUser(""));
        }

        [Fact]
        public void StartWhenNotNullSocketShouldWaitForIncomingConnection()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            server.Start();

            Assert.True(mockSocket.ServerIsWaiting);
        }
    }
}
