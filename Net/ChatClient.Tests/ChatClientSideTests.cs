using Common;
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

            Assert.Equal("newUserName", client.LogOn());

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

            Assert.Equal("userName", client.LogOn());

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }

        [Fact]
        public void LogOnWhenValidUserNameShouldLogOnAndReceiveGreetingMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.ListToReceive.Add("server: userName joined the chat.");

            MockDataReader dataReader = new MockDataReader();

            dataReader.ListToRead.Add("userName");

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.Equal("userName", client.LogOn());

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }
    }
}