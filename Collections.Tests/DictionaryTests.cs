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

            ICollection<string> valuesCollection = testDict.Values;

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
        public void IndexerWhenSetAndIsReadOnlyShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            testDict.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testDict[3] = "d");

            Assert.Equal("c", testDict[3]);
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
        public void AddWhenKeyAlreadyExistShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");

            Assert.Throws<ArgumentException>(() => testDict.Add("a", "b"));

            Assert.Equal("a", testDict["a"]);
        }

        [Fact]
        public void AddWhenThereIsNoAvailableSpaceShouldExtendDictionaryAndAddKeyValue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(2);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.Equal(3, testDict.Count);

            ICollection<int> keysCollection = testDict.Keys;

            Assert.Equal(3, keysCollection.Count);
            Assert.True(keysCollection.Contains(1));
            Assert.True(keysCollection.Contains(2));
            Assert.True(keysCollection.Contains(3));
        }

        [Fact]
        public void AddWhenIsReadOnlyShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(2);

            testDict.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testDict.Add(3, "c"));

            Assert.Equal(0, testDict.Count);
        }

        [Fact]
        public void ClearShouldSetCountTo0AndSetPointers()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            testDict.Clear();

            Assert.Equal(0, testDict.Count);

            ICollection<int> keysCollection = testDict.Keys;

            Assert.Equal(0, keysCollection.Count);

            ICollection<string> valuesCollection = testDict.Values;

            Assert.Equal(0, valuesCollection.Count);
        }

        [Fact]
        public void ClearWhenIsReadOnlyShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            testDict.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testDict.Clear());

            Assert.Equal(3, testDict.Count);
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), testDict);
            Assert.Contains(new KeyValuePair<int, string>(2, "b"), testDict);
            Assert.Contains(new KeyValuePair<int, string>(3, "c"), testDict);
        }

        [Fact]
        public void ContainsWhenNoExistShouldReturnFalse()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.False(testDict.Contains(new KeyValuePair<int, string>(3, "d")));
        }

        [Fact]
        public void ContainsWhenKeyIsNullShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");
            testDict.Add("b", "b");
            testDict.Add("c", "c");

            Assert.Throws<ArgumentNullException>(() => testDict.Contains(new KeyValuePair<string, string>(null, "a")));
        }

        [Fact]
        public void ContainsKeyWhenExistShouldReturnTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.True(testDict.ContainsKey(1));
            Assert.True(testDict.ContainsKey(2));
            Assert.True(testDict.ContainsKey(3));
        }

        [Fact]
        public void ContainsKeyWhenNoExistShouldReturnFalse()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.False(testDict.ContainsKey(4));
        }

        [Fact]
        public void ContainsKeyWhenNullShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");
            testDict.Add("b", "b");
            testDict.Add("c", "c");

            Assert.Throws<ArgumentNullException>(() => testDict.ContainsKey(null));
        }

        [Fact]
        public void ContainsValueWhenExistShouldReturnTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.True(testDict.ContainsValue("a"));
            Assert.True(testDict.ContainsValue("b"));
            Assert.True(testDict.ContainsValue("c"));
        }

        [Fact]
        public void ContainsValueWhenNoExistShouldReturnFalse()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.False(testDict.ContainsValue("d"));
        }

        [Fact]
        public void CopyToWhenPairsFitsShouldCopyPairs()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[4];

            testDict.CopyTo(destinationArray, 0);

            Assert.Contains(destinationArray[0], testDict);
            Assert.Contains(destinationArray[1], testDict);
            Assert.Contains(destinationArray[2], testDict);
        }

        [Fact]
        public void CopyToWhenNullShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = null;

            Assert.Throws<ArgumentNullException>(() => testDict.CopyTo(destinationArray, 0));

            Assert.Null(destinationArray);
        }

        [Fact]
        public void CopyToWhenIndexIsNegativeShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => testDict.CopyTo(destinationArray, -1));
        }

        [Fact]
        public void CopyToWhenIndexIsGreaterThanDestinationArrayLengthShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => testDict.CopyTo(destinationArray, 5));
        }

        [Fact]
        public void CopyToWhenDestinationArrayLengthIsSmallerThanCountShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[2];

            Assert.Throws<ArgumentException>(() => testDict.CopyTo(destinationArray, 0));
        }

        [Fact]
        public void CopyToWhenDestinationArrayAvailableSpaceIsSmallerThanCountShouldThrowException()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[5];

            Assert.Throws<ArgumentException>(() => testDict.CopyTo(destinationArray, 4));
        }

        [Fact]
        public void CopyToWhenDestinationArrayIsOfTheSameSizeShouldCopyTheElements()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            KeyValuePair<int, string>[] destinationArray = new KeyValuePair<int, string>[3];

            testDict.CopyTo(destinationArray, 0);

            Assert.Equal(testDict[destinationArray[0].Key], destinationArray[0].Value);
            Assert.Equal(testDict[destinationArray[1].Key], destinationArray[1].Value);
            Assert.Equal(testDict[destinationArray[2].Key], destinationArray[2].Value);
        }

        [Fact]
        public void RemoveWhenKeyExistShouldReturnTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.True(testDict.Remove(2));

            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "b"), testDict);
        }

        [Fact]
        public void RemoveWhenKeyNoExistShouldReturnFalse()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.False(testDict.Remove(4));

            Assert.Equal(3, testDict.Count);
        }

        [Fact]
        public void RemoveWhenNullShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");
            testDict.Add("b", "b");
            testDict.Add("c", "c");

            Assert.Throws<ArgumentNullException>(() => testDict.Remove(null));
        }

        [Fact]
        public void RemoveWhenIsReadOnlyShouldThrowException()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>(5);

            testDict.Add("a", "a");
            testDict.Add("b", "b");
            testDict.Add("c", "c");

            testDict.ToReadOnly();

            Assert.Throws<NotSupportedException>(() => testDict.Remove("a"));
        }

        [Fact]
        public void RemoveWhenPairExistShouldReturnTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.Add(1, "a");
            testDict.Add(2, "b");
            testDict.Add(3, "c");

            Assert.True(testDict.Remove(new KeyValuePair<int, string>(2, "b")));

            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "b"), testDict);
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
