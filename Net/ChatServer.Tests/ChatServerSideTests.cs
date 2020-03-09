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
    }
}
