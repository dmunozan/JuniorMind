﻿using System;
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
        public void ToReadOnlyWhenAnyShouldSetIsReadOnlyAsTrue()
        {
            Dictionary<int, string> testDict = new Dictionary<int, string>(5);

            testDict.ToReadOnly();

            Assert.True(testDict.IsReadOnly);
        }
    }
}
