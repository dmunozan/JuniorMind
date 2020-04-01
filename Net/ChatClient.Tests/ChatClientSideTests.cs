using Common;
using Xunit;

namespace ChatClient.Tests
{
    public class ChatClientSideTests
    {
        [Fact]
        public void LogOnWhenValidUserNameShouldLogOnAndReceiveGreetingMessage()
        {
            MockClientSocket mockSocket = new MockClientSocket();

            mockSocket.TextToReceive = "server: userName joined the chat.";

            MockDataReader dataReader = new MockDataReader();

            dataReader.TextToRead = "userName";

            ChatClientSide client = new ChatClientSide(mockSocket, dataReader);

            Assert.Equal("userName", client.LogOn());

            Assert.Collection(mockSocket.SentMessages,
                item => Assert.Equal("userName<sep>logon<sep>NoLastMessage", item));
        }
    }
}