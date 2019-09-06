using System;
using Xunit;

namespace Collections.Tests
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);

            Assert.Equal(1, arrayTest.Count);
        }

        [Fact]
        public void AddWhenOneNumberShouldReturnCount2AndBeSorted()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);

            Assert.Equal(2, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(5, arrayTest[1]);
        }

        [Fact]
        public void InsertWhenPosition0Number1ShouldReturnCount3AndBeSorted()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);

            arrayTest.Insert(0, 1);

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(1, arrayTest[0]);
            Assert.Equal(2, arrayTest[1]);
            Assert.Equal(5, arrayTest[2]);
        }

        [Fact]
        public void InsertWhenPosition0Number3ShouldDoNothing()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);

            arrayTest.Insert(0, 3);

            Assert.Equal(2, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(5, arrayTest[1]);
        }

        [Fact]
        public void InsertWhenPosition2Number4ShouldInsertNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);
            arrayTest.Add(3);

            arrayTest.Insert(2, 4);

            Assert.Equal(4, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(3, arrayTest[1]);
            Assert.Equal(4, arrayTest[2]);
            Assert.Equal(5, arrayTest[3]);
        }

        [Fact]
        public void InsertWhenPosition2Number5ShouldInsertNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);
            arrayTest.Add(3);

            arrayTest.Insert(2, 5);

            Assert.Equal(4, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(3, arrayTest[1]);
            Assert.Equal(5, arrayTest[2]);
            Assert.Equal(5, arrayTest[3]);
        }

        [Fact]
        public void InsertWhenPosition2Number6ShouldDoNothing()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(5);
            arrayTest.Add(2);
            arrayTest.Add(3);

            arrayTest.Insert(2, 6);

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(2, arrayTest[0]);
            Assert.Equal(3, arrayTest[1]);
            Assert.Equal(5, arrayTest[2]);
        }

        [Fact]
        public void InsertWhenPosition1Number4ShouldDoNothing()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest.Insert(1, 4);

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number4ShouldSetTheNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[0] = 4;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(4, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number5ShouldSetTheNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[0] = 5;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number6ShouldSetTheNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[0] = 6;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(6, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenPosition0Number7ShouldDoNothing()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[0] = 7;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber5ShouldDoNothing()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[2] = 5;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber6ShouldSetTheNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[2] = 6;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(6, arrayTest[2]);
        }

        [Fact]
        public void IndexerSetWhenLastPositionNumber7ShouldSetTheNumber()
        {
            SortedIntArray arrayTest = new SortedIntArray();
            arrayTest.Add(6);
            arrayTest.Add(7);
            arrayTest.Add(5);

            arrayTest[2] = 7;

            Assert.Equal(3, arrayTest.Count);
            Assert.Equal(5, arrayTest[0]);
            Assert.Equal(6, arrayTest[1]);
            Assert.Equal(7, arrayTest[2]);
        }
    }
}
