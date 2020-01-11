using System.Collections.Generic;
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

        [Fact]
        public void QuantityWhenSetShouldSetProductQuantity()
        {
            Product testProduct = new Product("apricot", 8);

            testProduct.Quantity = 4;

            Assert.Equal(4, testProduct.Quantity);
        }

        [Fact]
        public void FeaturesWhenGetShouldReturnProductFeatures()
        {
            Feature testFeature = new Feature(1);

            List<Feature> featureList = new List<Feature>();

            featureList.Add(testFeature);

            Product testProduct = new Product("apricot", 8, featureList);

            Assert.Equal(featureList, testProduct.Features);
        }
    }
}
