using Common;
using System;
using Xunit;

namespace ChatServer.Tests
{
    public class ChatServerSideTests
    {
        [Fact]
        public void AddUserWhenNewUserShouldAddUserToHashTable()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.True(server.IsNewUser("newUser"));

            server.AddUser("newUser");

            Assert.False(server.IsNewUser("newUser"));
        }

        [Fact]
        public void AddUserWhenAlreadyExistingUserShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            server.AddUser("newUser");

            Assert.Throws<ArgumentException>(() => server.AddUser("newUser"));
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
        public void CheckMessageWhenAnyShouldHaveValidFormat()
        {
            ChatServerSide server = new ChatServerSide();

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
        }

        [Fact]
        public void CheckMessageWhenNewUserShouldAddUser()
        {
            ChatServerSide server = new ChatServerSide();

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            Assert.True(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
            Assert.False(server.IsNewUser("userName"));
        }

        [Fact]
        public void CheckMessageWhenNoNewUserShouldAddMessageToChatAndSendNewMessages()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.SentMessages.Add("Initial message");

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            server.AddUser("userName");

            Assert.False(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
            Assert.False(server.IsNewUser("userName"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("userName: sentMessage", item));
        }

        [Fact]
        public void IsNewUserWhenUserNoExistShouldReturnTrue()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.True(server.IsNewUser("newUser"));
        }

        [Fact]
        public void IsNewUserWhenUserExistShouldReturnFalse()
        {
            ChatServerSide server = new ChatServerSide();

            server.AddUser("newUser");
            
            Assert.False(server.IsNewUser("newUser"));
        }

        [Fact]
        public void StartWhenNotNullSocketShouldWaitForIncomingConnection()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            server.Start();

            Assert.True(mockSocket.ServerIsWaiting);
        }

        [Fact]
        public void StartWhenNullSocketShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide(null);

            Assert.Throws<ArgumentNullException>(() => server.Start());
        }

        [Fact]
        public void TrimmedReceivedDataWhenStartShouldContainReceivedMessage()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.TextToReceive = "Test message";

            server.Start();

            Assert.Equal("Test message", mockSocket.TrimmedReceivedData);
        }
    }
}
