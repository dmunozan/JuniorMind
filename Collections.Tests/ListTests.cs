using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Tests
{
    public class ListTests
    {
        [Fact]
        public void CountWhenEmptyShouldReturn0()
        {
            List<int> listTest = new List<int>();

            Assert.Equal(0, listTest.Count);
        }
    }
}
