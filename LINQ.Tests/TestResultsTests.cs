using Xunit;

namespace LINQ.Tests
{
    public class TestResultsTests
    {
        [Fact]
        public void IdWhenGetShouldReturnId()
        {
            TestResults result = new TestResults("A", "Adam", 1);

            Assert.Equal("A", result.Id);
        }

        [Fact]
        public void IdWhenSetShouldSetId()
        {
            TestResults result = new TestResults("A", "Adam", 1);

            result.Id = "B";

            Assert.Equal("B", result.Id);
        }

        [Fact]
        public void FamilyIdWhenGetShouldReturnFamilyId()
        {
            TestResults result = new TestResults("A", "Adam", 1);

            Assert.Equal("Adam", result.FamilyId);
        }

        [Fact]
        public void FamilyIdWhenSetShouldSetFamilyId()
        {
            TestResults result = new TestResults("A", "Adam", 1);

            result.FamilyId = "Brown";

            Assert.Equal("Brown", result.FamilyId);
        }

        [Fact]
        public void ScoreWhenGetShouldReturnScore()
        {
            TestResults result = new TestResults("A", "Adam", 1);

            Assert.Equal(1, result.Score);
        }
    }
}
