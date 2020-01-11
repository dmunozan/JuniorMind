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
    }
}
