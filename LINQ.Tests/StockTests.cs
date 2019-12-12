using Xunit;

namespace LINQ.Tests
{
    public class StockTests
    {
        [Fact]
        public void StockWhenAnyShouldCreateEmptyStock()
        {
            Stock test = new Stock();

            Assert.Empty(test);
        }
    }
}
