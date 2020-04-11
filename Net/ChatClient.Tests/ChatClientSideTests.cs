using Common;
using System;
using Xunit;

namespace ChatClient.Tests
{
    public class ChatClientSideTests
    {
        [Fact]
        public void LogOnWhenAlreadyExistingUserNameShouldReceiveErrorMessageAndRequestForNewUserName()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName already exist, choose a different user name.");
            mockSocket.ListToReceive.Add("server: newUserName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("newUserName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("newUserName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("newUserName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenEmptyStringShouldSendNothingShowErrorMessageAndRequestForNewUserName()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("");
            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("userName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenNullStringShouldSendNothingShowErrorMessageAndRequestForNewUserName()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add(null);
            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("userName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenUserNameContainsExistShouldLogOnAndReceiveGreetingMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: existUserName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("existUserName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("existUserName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("existUserName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenUserNameContainsSeparatorShouldSendNothingShowErrorMessageAndRequestForNewUserName()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("user<sep>Name");
            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("userName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenValidUserNameShouldLogOnReceiveGreetingMessageAndDisconnect()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            Assert.Equal("userName", client.LogOn());

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void ProcessChatWhenAnyShouldSendMessageAndReceiveNewMessages()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("otherUser: Unrelated message.");
            mockSocket.ListToReceive.Add("userName: Hello!");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("Hello!");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>Hello!<sep>server: userName joined the chat.", item));

            Assert.Collection(mockSocket.ReceivedMessages,
                item => Assert.Equal("server: userName joined the chat.", item),
                item => Assert.Equal("otherUser: Unrelated message.", item),
                item => Assert.Equal("userName: Hello!", item));
        }

        [Fact]
        public void ProcessChatWhenExitShouldCloseClient()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("otherUser: Unrelated message.");
            mockSocket.ListToReceive.Add("userName: Hello!");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("Hello!");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>Hello!<sep>server: userName joined the chat.", item));

            Assert.Collection(mockSocket.ReceivedMessages,
                item => Assert.Equal("server: userName joined the chat.", item),
                item => Assert.Equal("otherUser: Unrelated message.", item),
                item => Assert.Equal("userName: Hello!", item));

            Assert.True(mockSocket.Closed);
        }

        [Fact]
        public void ReceiveNewMessagesWhenValidSocketShouldReceiveNewMessagesShowThemToTheUserAndUpdateLastMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("otherUser: Unrelated message.");
            mockSocket.ListToReceive.Add("userName: Hello!");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("Hello!");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>Hello!<sep>server: userName joined the chat.", item));

            Assert.Collection(mockSocket.ReceivedMessages,
                item => Assert.Equal("server: userName joined the chat.", item),
                item => Assert.Equal("otherUser: Unrelated message.", item),
                item => Assert.Equal("userName: Hello!", item));
        }

        [Fact]
        public void SendMessageWhenEmptyStringShouldSendNothingShowErrorMessageAndRequestForNewMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("userName: valid message");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("");
            dataReader.ListToRead.Add("valid message");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>valid message<sep>server: userName joined the chat.", item));
        }

        [Fact]
        public void SendMessageWhenNullStringShouldSendNothingShowErrorMessageAndRequestForNewMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("userName: valid message");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add(null);
            dataReader.ListToRead.Add("valid message");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>valid message<sep>server: userName joined the chat.", item));
        }

        [Fact]
        public void SendMessageWhenMessageContainsSeparatorShouldSendNothingShowErrorMessageAndRequestForNewMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("userName: valid message");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("message<sep>with<sep>separator");
            dataReader.ListToRead.Add("valid message");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>valid message<sep>server: userName joined the chat.", item));
        }

        [Fact]
        public void SendMessageWhenValidMessageShouldConnectSendMessageToServerAndDisconnect()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("userName: Hello!");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("Hello!");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            client.Start();

            Assert.False(mockSocket.Connected);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>Hello!<sep>server: userName joined the chat.", item));
        }

        [Fact]
        public void StartWhenNullDataReaderShouldThrowException()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = null;

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.Throws<ArgumentNullException>(() => client.Start());
        }

        [Fact]
        public void StartWhenNullSocketShouldThrowException()
        {
            MockClientSocket mockSocket = null;

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.Throws<ArgumentNullException>(() => client.Start());
        }

        [Fact]
        public void StartWhenValidSocketAndDataReaderShouldLogOnAndProcessChat()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");
            mockSocket.ListToReceive.Add("otherUser: Unrelated message.");
            mockSocket.ListToReceive.Add("userName: Hello!");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");
            dataReader.ListToRead.Add("Hello!");
            dataReader.ListToRead.Add("exit");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.True(mockSocket.Connected);

            client.Start();

            Assert.False(mockSocket.Connected);
            Assert.True(mockSocket.Closed);

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item),
                item => Assert.Equal("userName<sep>Hello!<sep>server: userName joined the chat.", item));

            Assert.Collection(mockSocket.ReceivedMessages,
                item => Assert.Equal("server: userName joined the chat.", item),
                item => Assert.Equal("otherUser: Unrelated message.", item),
                item => Assert.Equal("userName: Hello!", item));
        }
    }
}