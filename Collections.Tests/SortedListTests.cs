using System;
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
        public void InsertWhenPosition0Number3ShouldThrowExceptionAndDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);

            Assert.Throws<InvalidOperationException>(() => listTest.Insert(0, 3));

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
        public void InsertWhenPosition2Number6ShouldThrowExceptionAndDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(5);
            listTest.Add(2);
            listTest.Add(3);

            Assert.Throws<InvalidOperationException>(() => listTest.Insert(2, 6));

            Assert.Equal(3, listTest.Count);
            Assert.Equal(2, listTest[0]);
            Assert.Equal(3, listTest[1]);
            Assert.Equal(5, listTest[2]);
        }

        [Fact]
        public void InsertWhenPosition1Number4ShouldThrowExceptionAndDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            Assert.Throws<InvalidOperationException>(() => listTest.Insert(1, 4));

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number4ShouldSetTheNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            listTest[0] = 4;

            Assert.Equal(3, listTest.Count);
            Assert.Equal(4, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number5ShouldSetTheNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            listTest[0] = 5;

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number6ShouldSetTheNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            listTest[0] = 6;

            Assert.Equal(3, listTest.Count);
            Assert.Equal(6, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number7ShouldThrowExceptionAndDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            Assert.Throws<InvalidOperationException>(() => listTest[0] = 7);

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber5ShouldThrowExceptionAndDoNothing()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            Assert.Throws<InvalidOperationException>(() => listTest[2] = 5);

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber6ShouldSetTheNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            listTest[2] = 6;

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(6, listTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber7ShouldSetTheNumber()
        {
            SortedList<int> listTest = new SortedList<int>();
            listTest.Add(6);
            listTest.Add(7);
            listTest.Add(5);

            listTest[2] = 7;

            Assert.Equal(3, listTest.Count);
            Assert.Equal(5, listTest[0]);
            Assert.Equal(6, listTest[1]);
            Assert.Equal(7, listTest[2]);
        }
    }
}
