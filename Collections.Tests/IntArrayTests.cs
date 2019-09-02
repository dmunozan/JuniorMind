using System;
using Xunit;

namespace Collections.Tests
{
    public class IntArrayTests
    {
        [Fact]
        public void ContainsWhenNumberAndArrayIsEmptyShouldReturnFalse()
        {
            IntArray arrayTest = new IntArray();

            Assert.False(arrayTest.Contains(5));
        }

        [Fact]
        public void AddWhenNumberAndArrayIsEmptyShouldContainNumber()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(5);

            Assert.True(arrayTest.Contains(5));
        }

        [Fact]
        public void CountWhenEmptyArrayShouldReturn0()
        {
            IntArray arrayTest = new IntArray();

            Assert.Equal(0, arrayTest.Count());
        }

        [Fact]
        public void CountWhenEmptyArrayAndAddElementShouldReturnNumberOfElements()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            Assert.Equal(3, arrayTest.Count());
        }

        [Fact]
        public void ElementWhen1ShouldReturnNumberInPosition1()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            Assert.Equal(5, arrayTest.Element(1));
        }

        [Fact]
        public void SetElementWhenIndex1AndNumber3ShouldReturn3ForElement1()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.SetElement(1, 3);

            Assert.Equal(3, arrayTest.Element(1));
        }

        [Fact]
        public void SetElementWhenIndexOutOfBoundsShouldDoNothing()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.SetElement(6, 3);

            Assert.False(arrayTest.Contains(3));
        }

        [Fact]
        public void IndexOfWhen5ShouldReturn1()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            Assert.Equal(1, arrayTest.IndexOf(5));
        }

        [Fact]
        public void IndexOfWhen6ShouldReturnMinus1()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            Assert.Equal(-1, arrayTest.IndexOf(6));
        }

        [Fact]
        public void InsertWhenNumber3AndPoistion0ShouldReturn3ForElement0()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.Insert(0, 3);

            Assert.Equal(3, arrayTest.Element(0));
        }

        [Fact]
        public void InsertWhenPoistionOutOfBoundsShouldDoNothing()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.Insert(6, 3);

            Assert.False(arrayTest.Contains(3));
        }

        [Fact]
        public void ClearWhenAnyArrayShouldReturn0ForCount()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.Clear();

            Assert.Equal(0, arrayTest.Count());
        }

        [Fact]
        public void RemoveWhen5AndOnlyOne5ShouldReturnFalseForContains()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.Remove(5);

            Assert.False(arrayTest.Contains(5));
        }

        [Fact]
        public void RemoveWhen5AndMoreThanOne5ShouldReturnTrueForContainsAnd2ForIndexOf()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);
            arrayTest.Add(5);

            arrayTest.Remove(5);

            Assert.True(arrayTest.Contains(5));
            Assert.Equal(2, arrayTest.IndexOf(5));
        }

        [Fact]
        public void RemoveWhenNoElementShouldDoNothing()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.Remove(3);

            Assert.Equal(3, arrayTest.Count());
        }

        [Fact]
        public void RemoveAtWhenPosition2ShouldDelete1ReturnFalseForContainsAnd2ForCount()
        {
            IntArray arrayTest = new IntArray();
            arrayTest.Add(4);
            arrayTest.Add(5);
            arrayTest.Add(1);

            arrayTest.RemoveAt(2);

            Assert.False(arrayTest.Contains(1));
            Assert.Equal(2, arrayTest.Count());
        }
    }
}
