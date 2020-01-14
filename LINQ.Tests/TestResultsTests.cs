using Xunit;

namespace LINQ.Tests
{
    public class TestResultsTests
    {
        [Fact]
        public void IdWhenGetShouldReturnId()
        {
            TestResults result = new TestResults("A");

            Assert.Equal("A", result.Id);
        }
    }
}
