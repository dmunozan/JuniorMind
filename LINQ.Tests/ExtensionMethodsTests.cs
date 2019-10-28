using Xunit;

namespace LINQ.Tests
{
    public class ExtensionMethodsTests
    {
        [Fact]
        public void AllWhenAllTheElementsMeetTheConditionShouldReturnTrue()
        {
            ListCollection<int> testList = new ListCollection<int>();

            testList.Add(2);
            testList.Add(4);
            testList.Add(6);
            testList.Add(8);

            Assert.True(testList.All<int>(e => e % 2 == 0));
        }
    }
}
