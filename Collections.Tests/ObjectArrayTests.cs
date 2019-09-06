using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CountWhenEmptyArrayShouldReturn0()
        {
            ObjectArray arrayTest = new ObjectArray();

            Assert.Equal(0, arrayTest.Count);
        }

        [Fact]
        public void AddWhenEmptyArrayShouldReturnCount1()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add(4);

            Assert.Equal(1, arrayTest.Count);
        }

        [Fact]
        public void IndexOfWhenTextShouldReturn0()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.Equal(0, arrayTest.IndexOf("test"));
        }

        [Fact]
        public void IndexOfWhenNoExistsShouldReturnMinus1()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.Equal(-1, arrayTest.IndexOf("noTest"));
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            Assert.True(arrayTest.Contains("test"));
        }

        [Fact]
        public void ClearWhenAnyShouldReturnCount0()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.Equal(0, arrayTest.Count);
        }

        [Fact]
        public void IndexOfWhenNoExistAfterClearShouldReturnMinus1()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.Equal(-1, arrayTest.IndexOf("test"));
        }

        [Fact]
        public void ContainsWhenNoExistAfterClearShouldReturnFalse()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.False(arrayTest.Contains("test"));
        }

        [Fact]
        public void InsertWhenPosition0ShouldReturnElementOnIndex0()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.Insert(0, new int[4] {0, 1, 2, 3 });

            Assert.Equal(4, arrayTest.Count);
            Assert.Equal(new int[4] { 0, 1, 2, 3 }, arrayTest[0]);
            Assert.Equal(1, arrayTest[1]);
            Assert.Equal('2', arrayTest[2]);
            Assert.Equal("3", arrayTest[3]);
        }

        [Fact]
        public void InsertWhenPoistionOutOfBoundsShouldDoNothing()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.Insert(3, new int[4] { 0, 1, 2, 3 });

            Assert.Equal(3, arrayTest.Count);
            Assert.False(arrayTest.Contains(new int[4] { 0, 1, 2, 3 }));
            Assert.Equal(1, arrayTest[0]);
            Assert.Equal('2', arrayTest[1]);
            Assert.Equal("3", arrayTest[2]);
        }

        [Fact]
        public void RemoveAtWhenPostion0ShouldRemoveFirstElement()
        {
            ObjectArray arrayTest = new ObjectArray();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.RemoveAt(0);

            Assert.Equal(2, arrayTest.Count);
            Assert.False(arrayTest.Contains(1));
            Assert.Equal('2', arrayTest[0]);
            Assert.Equal("3", arrayTest[1]);
        }
    }
}
