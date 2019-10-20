using System;
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
        public void CountWhenDictionaryIsNotEmptyShouldReturnNumberOfElements()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.Equal(3, testDict.Count);
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

        [Fact]
        public void ValuesWhenDictionaryIsEmptyShouldReturnEmptyCollection()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            ICollection<int> valuesCollection = testDict.Keys;

            Assert.Equal(0, valuesCollection.Count);
        }

        [Fact]
        public void ValuesWhenDictionaryIsNotEmptyShouldReturnCollectionOfValues()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            ICollection<string> valuesCollection = testDict.Values;

            Assert.Equal(3, valuesCollection.Count);
            Assert.True(valuesCollection.Contains("a"));
            Assert.True(valuesCollection.Contains("b"));
            Assert.True(valuesCollection.Contains("c"));
        }

        [Fact]
        public void IndexerWhenGetAndKeyExistShouldReturnAssociatedValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.Equal("a", testDict[1]);
        }

        [Fact]
        public void IndexerWhenGetAndKeyNoExistShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            string value = null;

            Assert.Throws<KeyNotFoundException>(() => value = testDict[4]);

            Assert.Null(value);
        }

        [Fact]
        public void IndexerWhenSetAndKeyExistShouldModifyAssociatedValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            testDict[1] = "d";

            Assert.Equal("d", testDict[1]);
        }

        [Fact]
        public void IndexerWhenSetAndKeyNoExistShouldAddNewPairKeyValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            testDict[4] = "d";

            Assert.Equal("d", testDict[4]);
        }

        [Fact]
        public void IsReadOnlyWhenNewDictionaryShouldReturnFalse()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            Assert.False(testDict.IsReadOnly);
        }

        [Fact]
        public void AddWhenDictionaryIsEmptyAndThereIsAvailableSpaceShouldAddKeyValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");

            Assert.Equal(1, testDict.Count);
        }

        [Fact]
        public void AddWhenValueIsNullShouldAddKeyValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, null);

            Assert.Null(testDict[1]);
        }

        [Fact]
        public void AddWhenKeyIsNullShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            Assert.Throws<ArgumentNullException>(() => testDict.Add(null, "a"));

            Assert.Equal(0, testDict.Count);
        }

        [Fact]
        public void ToReadOnlyWhenAnyShouldSetIsReadOnlyAsTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.ToReadOnly();

            Assert.True(testDict.IsReadOnly);
        }
    }
}
