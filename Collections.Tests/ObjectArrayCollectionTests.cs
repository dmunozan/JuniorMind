﻿using System;
using Xunit;

namespace Collections.Tests
{
    public class ObjectArrayCollectionTests
    {
        [Fact]
        public void CountWhenEmptyArrayShouldReturn0()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();

            Assert.Equal(0, arrayTest.Count);
        }

        [Fact]
        public void AddWhenEmptyArrayShouldReturnCount1()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(4);

            Assert.Equal(1, arrayTest.Count);
        }

        [Fact]
        public void IndexOfWhenTextShouldReturn0()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            Assert.Equal(0, arrayTest.IndexOf("test"));
        }

        [Fact]
        public void IndexOfWhenNoExistsShouldReturnMinus1()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            Assert.Equal(-1, arrayTest.IndexOf("noTest"));
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            Assert.True(arrayTest.Contains("test"));
        }

        [Fact]
        public void ClearWhenAnyShouldReturnCount0()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.Equal(0, arrayTest.Count);
        }

        [Fact]
        public void IndexOfWhenNoExistAfterClearShouldReturnMinus1()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.Equal(-1, arrayTest.IndexOf("test"));
        }

        [Fact]
        public void ContainsWhenNoExistAfterClearShouldReturnFalse()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add("test");

            arrayTest.Clear();

            Assert.False(arrayTest.Contains("test"));
        }

        [Fact]
        public void InsertWhenPosition0ShouldReturnElementOnIndex0()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
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
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
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
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.RemoveAt(0);

            Assert.Equal(2, arrayTest.Count);
            Assert.False(arrayTest.Contains(1));
            Assert.Equal('2', arrayTest[0]);
            Assert.Equal("3", arrayTest[1]);
        }

        [Fact]
        public void RemoveAtWhenPostionOutOfBoundsShouldDoNothing()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.RemoveAt(3);

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(1, arrayTest[0]);
            Assert.Equal('2', arrayTest[1]);
            Assert.Equal("3", arrayTest[2]);
        }

        [Fact]
        public void RemoveAtWhenLastPostionAndNoMoreSpaceShouldRemoveLastElement()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");
            arrayTest.Add(new int[] { 0, 1, 2 });

            arrayTest.RemoveAt(3);

            Assert.Equal(3, arrayTest.Count);
            Assert.False(arrayTest.Contains(new int[] { 0, 1, 2 }));
            Assert.Equal(1, arrayTest[0]);
            Assert.Equal('2', arrayTest[1]);
            Assert.Equal("3", arrayTest[2]);
        }

        [Fact]
        public void RemoveWhen1AndOnlyOne1ShouldReturnFalseForContains()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.Remove(1);

            Assert.False(arrayTest.Contains(1));
        }

        [Fact]
        public void RemoveWhen1AndMoreThanOne1ShouldReturnReturnTrueForContainsAnd2ForIndexOf()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");
            arrayTest.Add(1);

            arrayTest.Remove(1);

            Assert.True(arrayTest.Contains(1));
            Assert.Equal(2, arrayTest.IndexOf(1));
        }

        [Fact]
        public void RemoveWhenNoElementShouldDoNothing()
        {
            ObjectArrayCollection arrayTest = new ObjectArrayCollection();
            arrayTest.Add(1);
            arrayTest.Add('2');
            arrayTest.Add("3");

            arrayTest.Remove(2);

            Assert.Equal(3, arrayTest.Count);
        }
    }
}
