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
    }
}
