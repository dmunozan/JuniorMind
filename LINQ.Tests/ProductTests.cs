using Xunit;

namespace LINQ.Tests
{
    public class ProductTests
    {
        [Fact]
        public void NameWhenGetShouldReturnProductName()
        {
            Product testProduct = new Product("apricot", 8);

            Assert.Equal("apricot", testProduct.Name);
        }
    }
}
