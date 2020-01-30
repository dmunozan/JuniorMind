using Xunit;

namespace Net.Tests
{
    public class EchoServerTests
    {
        [Fact]
        public void ConstructorWhenAnyShouldReturnEchoServer()
        {
            Assert.NotNull(new EchoServer());
        }
    }
}
