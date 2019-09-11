﻿using System;
using Xunit;

namespace Collections.Tests
{
    public class SortedListTests
    {
        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);

            Assert.Equal(1, listTest.Count);
        }

        [Fact]
        public void AddWhenOneNumberShouldReturnCount2AndBeSorted()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);

            Assert.Equal(2, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(5, listTest[1]);
        }

        [Fact]
        public void InsertWhenPosition0CharAShouldReturnCount3AndBeSorted()
        {
            SortedList<char> listTest = new SortedList<char>();
            listTest.Add('d');
            listTest.Add('b');

            listTest.Insert(0, 'a');

            Assert.Equal(3, listTest.Count);
            Assert.Equal('a', listTest[0]);
            Assert.Equal('b', listTest[1]);
            Assert.Equal('d', listTest[2]);
        }

        [Fact]
        public void InsertWhenPosition0Number3ShouldDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);

            listTest.Insert(0, 3);

            Assert.Equal(2, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(5, listTest[1]);
        }

        [Fact]
        public void InsertWhenPosition2Number4ShouldInsertNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(2, 4);

            Assert.Equal(4, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(3, listTest[1]);
            Assert.Equal(4, listTest[2]);
            Assert.Equal(5, listTest[3]);
        }

        [Fact]
        public void InsertWhenPosition2Number5ShouldInsertNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(2, 5);

            Assert.Equal(4, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(3, listTest[1]);
            Assert.Equal(5, listTest[2]);
            Assert.Equal(5, listTest[3]);
        }

        [Fact]
        public void InsertWhenPosition2Number6ShouldDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(2, 6);

            Assert.Equal(3, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(3, listTest[1]);
            Assert.Equal(5, listTest[2]);
        }
    }
}
