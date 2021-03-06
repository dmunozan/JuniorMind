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

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
        }

        [Fact]
        public void CheckMessageWhenEmptySecondArgumentShouldThrowException()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep><sep>lastMessageReceived<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Throws<ArgumentException>(() => server.CheckMessage(mockSocket));
        }

        [Fact]
        public void CheckMessageWhenInvalidFormatShouldThrowException()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string invalidFormatData = "userName_sentMessage_lastMessage";

            mockSocket.TextToReceive = invalidFormatData;

            Assert.Single(invalidFormatData.Split("<sep>"));
            Assert.Throws<InvalidOperationException>(() => server.CheckMessage(mockSocket));
        }

        [Fact]
        public void CheckMessageWhenNewUserAndUserNameAlreadyExistShouldRequestForNewUserName()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep>sentMessage<sep>NotExistingText<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.True(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("userName"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("server: userName joined the chat.<eof>", item));

            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("server: userName already exist, choose a different user name.<eof>", item));
        }

        [Fact]
        public void CheckMessageWhenNewUserShouldAddUser()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.True(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("userName"));
        }

        [Fact]
        public void CheckMessageWhenNewUserShouldSendOnlyGreetingMessage()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string initialTestMessage = "someUser<sep>Initial message<sep>testLastMessageReceived<eof>";

            mockSocket.TextToReceive = initialTestMessage;

            server.CheckMessage(mockSocket);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("server: someUser joined the chat.<eof>", item));

            string testMessage = "someUser<sep>Initial message<sep>server: someUser joined the chat.<eof>";

            mockSocket.TextToReceive = testMessage;

            Assert.False(server.IsNewUser("someUser"));
            Assert.Equal(3, testMessage.Split("<sep>").Length);
            Assert.True(testMessage.IndexOf("<eof>") > -1);
            Assert.Equal("Initial message", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("someUser"));

            Assert.Collection(mockSocket.SentMessages,
                            item => Assert.Equal("server: someUser joined the chat.<eof>", item),
                            item => Assert.Equal("someUser: Initial message<eof>", item));

            string trimmedReceivedData = "newUser<sep>sentMessage<sep>lastMessageReceived<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.True(server.IsNewUser("newUser"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("newUser"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("server: someUser joined the chat.<eof>", item),
                item => Assert.Equal("someUser: Initial message<eof>", item),
                item => Assert.Equal("server: newUser joined the chat.<eof>", item));
        }

        [Fact]
        public void CheckMessageWhenNoEOFTagShouldThrowException()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            string trimmedReceivedData = "userName<sep>sentMessage<sep>lastMessageReceived";

            mockSocket.TextToReceive = trimmedReceivedData;

            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.False(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Throws<InvalidOperationException>(() => server.CheckMessage(mockSocket));
        }

        [Fact]
        public void CheckMessageWhenNoNewUserShouldAddMessageToChatAndSendNewMessages()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.SentMessages.Add("Initial message");

            string trimmedReceivedData = "userName<sep>sentMessage<sep>server: userName joined the chat.<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            server.CheckMessage(mockSocket);

            Assert.False(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("userName"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item));
        }

        [Fact]
        public void CheckMessageWhenNullMessageShouldThrowException()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.TextToReceive = null;

            Assert.Throws<InvalidOperationException>(() => server.CheckMessage(mockSocket));
        }

        [Fact]
        public void CheckMessageWhenNullSocketShouldThrowException()
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
        public void SendNewMessagesWhenMessageNoExistShouldThrowException()
        {
            MockSocketCommunication socket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(socket);

            Assert.Throws<ArgumentException>(() => server.SendNewMessages(socket, -1));
        }

        [Fact]
        public void SendNewMessagesWhenNullSocketShouldThrowException()
        {
            ChatServerSide server = new ChatServerSide();

            Assert.Throws<ArgumentNullException>(() => server.SendNewMessages(null, 0));
        }

        [Fact]
        public void SendNewMessagesWhenThereAreNewMessagesShouldSendThoseMessages()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.SentMessages.Add("Initial message");

            string trimmedReceivedData = "userName<sep>sentMessage<sep>server: userName joined the chat.<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            server.CheckMessage(mockSocket);

            Assert.False(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("userName"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item));

            server.SendNewMessages(mockSocket, 0);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item));
        }

        [Fact]
        public void SendNewMessagesWhenThereAreNoNewMessagesShouldDoNothing()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.SentMessages.Add("Initial message");

            string trimmedReceivedData = "userName<sep>sentMessage<sep>server: userName joined the chat.<eof>";

            mockSocket.TextToReceive = trimmedReceivedData;

            server.CheckMessage(mockSocket);

            Assert.False(server.IsNewUser("userName"));
            Assert.Equal(3, trimmedReceivedData.Split("<sep>").Length);
            Assert.True(trimmedReceivedData.IndexOf("<eof>") > -1);
            Assert.Equal("sentMessage", server.CheckMessage(mockSocket));
            Assert.False(server.IsNewUser("userName"));

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item));

            server.SendNewMessages(mockSocket, 2);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("Initial message", item),
                item => Assert.Equal("server: userName joined the chat.<eof>", item),
                item => Assert.Equal("userName: sentMessage<eof>", item));
        }

        [Fact]
        public void StartWhenNotNullSocketShouldWaitForIncomingConnection()
        {
            MockSocketCommunication mockSocket = new MockSocketCommunication();

            ChatServerSide server = new ChatServerSide(mockSocket);

            mockSocket.TextToReceive = "testUser<sep>testMessage<sep>lastMessageReceived<eof>";

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

            mockSocket.TextToReceive = "testUser<sep>testMessage<sep>lastMessageReceived<eof>";

            server.Start();

            Assert.Equal("testUser<sep>testMessage<sep>lastMessageReceived<eof>", mockSocket.TrimmedReceivedData);
        }
    }
}
