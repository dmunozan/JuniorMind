using Xunit;

namespace LINQ.Tests
{
    public class FeatureTests
    {
        [Fact]
        public void IdWhenGetShouldReturnFeatureId()
        {
            Feature testFeature = new Feature(1);

            Assert.Equal(1, testFeature.Id);
        }

        [Fact]
        public void IdWhenSetShouldSetFeatureId()
        {
            Feature testFeature = new Feature(1);

            testFeature.Id = 2;

            Assert.Equal(2, testFeature.Id);
        }
    }
}
