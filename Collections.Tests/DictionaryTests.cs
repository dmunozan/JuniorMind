﻿using Xunit;

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
    }
}
