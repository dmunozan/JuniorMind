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

        [Fact]
        public void IdWhenSetShouldSetId()
        {
            TestResults result = new TestResults("A");

            result.Id = "B";

            Assert.Equal("B", result.Id);
        }
    }
}
