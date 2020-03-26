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
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
        }

        [Fact]
        public void CheckMessageWhenEmptySecondArgumentShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            string trimmedReceivedData = "userName<sep><sep>lastMessageReceived";

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Throws<ArgumentException>(() => server.CheckMessage(trimmedReceivedData));
        }

        [Fact]
        public void CheckMessageWhenInvalidFormatShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            string invalidFormatData = "userName_sentMessage_lastMessage";

            Assert.Single(invalidFormatData.Split("<sep>"));
            Assert.Throws<ArgumentException>(() => server.CheckMessage(invalidFormatData));
        }

        [Fact]
        public void CheckMessageWhenNewUserShouldAddUser()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            Assert.True(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
            Assert.False(server.IsNewUser("userName"));
        }

        [Fact]
        public void CheckMessageWhenNewUserShouldSendOnlyGreetingMessage()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string initialTestMessage = "someUser<sep>Initial message<sep>testLastMessageReceived";

            server.AddUser("someUser");

            Assert.False(server.IsNewUser("someUser"));
            Assert.Equal(3, initialTestMessage.Split("<sep>").Length);
            Assert.Empty(mockSocket.SentMessages);
            Assert.Equal("Initial message", server.CheckMessage(initialTestMessage));
            Assert.False(server.IsNewUser("someUser"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("someUser: Initial message", item));

            string trimmedReceivedData = "newUser<sep>sentMessage<sep>lastMessageReceived";

            Assert.True(server.IsNewUser("newUser"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.Equal("sentMessage", server.CheckMessage(trimmedReceivedData));
            Assert.False(server.IsNewUser("newUser"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("someUser: Initial message", item),
                item => Assert.Equal("server: You joined the chat.", item));
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
        public void CheckMessageWhenNullArgumentShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentNullException>(() => server.CheckMessage(null));
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
        public void SentNewMessagesWhenEmptyMessageShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentException>(() => server.SendNewMessages(""));
        }

        [Fact]
        public void SentNewMessagesWhenNullShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentNullException>(() => server.SendNewMessages(null));
        }

        [Fact]
        public void SentNewMessagesWhenThereAreNewMessagesShouldSendThoseMessages()
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

            server.SendNewMessages("LastMessageReceived");

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("userName: sentMessage", item),
                item => Assert.Equal("userName: sentMessage", item));
        }

        [Fact]
        public void SentNewMessagesWhenThereAreNoNewMessagesShouldDoNothing()
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

            server.SendNewMessages("userName: sentMessage");

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("userName: sentMessage", item));
        }

        [Fact]
        public void StartWhenNotNullSocketShouldWaitForIncomingConnection()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.TextToReceive = "testUser<sep>testMessage<sep>lastMessageReceived";

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

            mockSocket.TextToReceive = "testUser<sep>testMessage<sep>lastMessageReceived";

            server.Start();

            Assert.Equal("testUser<sep>testMessage<sep>lastMessageReceived", mockSocket.TrimmedReceivedData);
        }
    }
}
