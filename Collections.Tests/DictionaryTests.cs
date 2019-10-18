using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Collections.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void CountWhenDictionaryIsEmptyShouldReturn0()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            Assert.Equal(0, testDict.Count);
        }

        [Fact]
        public void AddWhenDictionaryIsEmptyAndThereIsAvailableSpaceShouldAddKeyValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");

            Assert.Equal(1, testDict.Count);
        }

        [Fact]
        public void KeysWhenDictionaryIsEmptyShouldReturnEmptyCollection()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            ICollection<int> keysCollection = testDict.Keys;

            Assert.Equal(0, keysCollection.Count);
        }

        [Fact]
        public void KeysWhenDictionaryIsNotEmptyShouldReturnCollectionOfKeys()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            ICollection<int> keysCollection = testDict.Keys;

            Assert.Equal(3, keysCollection.Count);
            Assert.True(keysCollection.Contains(1));
            Assert.True(keysCollection.Contains(2));
            Assert.True(keysCollection.Contains(3));
        }
    }
}
