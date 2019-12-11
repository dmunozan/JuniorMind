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

        [Fact]
        public void NameWhenSetShouldSetProductName()
        {
            Product testProduct = new Product("apricot", 8);

            testProduct.Name = "orange";

            Assert.Equal("orange", testProduct.Name);
        }

        [Fact]
        public void QuantityWhenGetShouldReturnProductQuantity()
        {
            Product testProduct = new Product("apricot", 8);

            Assert.Equal(8, testProduct.Quantity);
        }
    }
}
