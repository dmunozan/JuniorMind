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

        [Fact]
        public void AddWhenEmptyShouldReturnCount1()
        {
            List<int> listTest = new List<int>();
            listTest.Add(4);

            Assert.Equal(1, listTest.Count);
        }

        [Fact]
        public void IndexOfTextShouldReturn0()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.Equal(0, listTest.IndexOf("test"));
        }

        [Fact]
        public void IndexOfWhenNoExistsShouldReturnMinus1()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.Equal(-1, listTest.IndexOf("noTest"));
        }

        [Fact]
        public void ContainsWhenExistShouldReturnTrue()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            Assert.True(listTest.Contains("test"));
        }

        [Fact]
        public void ClearWhenAnyShouldReturnCount0()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.Equal(0, listTest.Count);
        }

        [Fact]
        public void IndexOfWhenNoExistAfterClearShouldReturnMinus1()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.Equal(-1, listTest.IndexOf("test"));
        }

        [Fact]
        public void ContainsWhenNoExistAfterClearShouldReturnFalse()
        {
            List<string> listTest = new List<string>();
            listTest.Add("test");

            listTest.Clear();

            Assert.False(listTest.Contains("test"));
        }

        [Fact]
        public void InsertWhenPosition0ShouldReturnElementOnIndex0()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Insert(0, 4);

            Assert.Equal(4, listTest.Count);
            Assert.Equal(4, listTest[0]);
            Assert.Equal(1, listTest[1]);
            Assert.Equal(2, listTest[2]);
            Assert.Equal(3, listTest[3]);
        }

        [Fact]
        public void InsertWhenPoistionOutOfBoundsShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => listTest.Insert(3, 4));

            Assert.Equal(3, listTest.Count);
            Assert.False(listTest.Contains(4));
            Assert.Equal(1, listTest[0]);
            Assert.Equal(2, listTest[1]);
            Assert.Equal(3, listTest[2]);
        }

        [Fact]
        public void RemoveAtWhenPostion0ShouldRemoveFirstElement()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            listTest.RemoveAt(0);

            Assert.Equal(2, listTest.Count);
            Assert.False(listTest.Contains(1));
            Assert.Equal(2, listTest[0]);
            Assert.Equal(3, listTest[1]);
        }

        [Fact]
        public void RemoveAtWhenPostionOutOfBoundsShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => listTest.RemoveAt(3));
            
            Assert.Equal(3, listTest.Count);
            Assert.Equal(1, listTest[0]);
            Assert.Equal(2, listTest[1]);
            Assert.Equal(3, listTest[2]);
        }

        [Fact]
        public void RemoveAtWhenLastPostionAndNoMoreSpaceShouldRemoveLastElement()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);
            listTest.Add(4);

            listTest.RemoveAt(3);

            Assert.Equal(3, listTest.Count);
            Assert.False(listTest.Contains(4));
            Assert.Equal(1, listTest[0]);
            Assert.Equal(2, listTest[1]);
            Assert.Equal(3, listTest[2]);
        }

        [Fact]
        public void RemoveWhen1AndOnlyOne1ShouldReturnFalseForContains()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            listTest.Remove(1);

            Assert.False(listTest.Contains(1));
        }

        [Fact]
        public void RemoveWhen1AndMoreThanOne1ShouldReturnReturnTrueForContainsAnd2ForIndexOf()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);
            listTest.Add(1);

            listTest.Remove(1);

            Assert.True(listTest.Contains(1));
            Assert.Equal(2, listTest.IndexOf(1));
        }

        [Fact]
        public void RemoveWhenNoElementShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => listTest.Remove(4));

            Assert.Equal(3, listTest.Count);
        }

        [Fact]
        public void AddWhenNoMoreSpaceShouldIncreaseTheSizeAndAddTheElement()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);
            listTest.Add(4);
            listTest.Add(5);

            Assert.Equal(5, listTest.Count);
        }

        [Fact]
        public void InsertWhenNoMoreSpaceShouldIncreaseTheSizeAndInsertTheElement()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);
            listTest.Add(4);
            listTest.Insert(3, 5);

            Assert.Equal(5, listTest.Count);
        }

        [Fact]
        public void CopyToWhenArrayFitsShouldCopyArray()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[4];

            listTest.CopyTo(destinationArray, 0);

            Assert.Equal(listTest[0], destinationArray[0]);
            Assert.Equal(listTest[1], destinationArray[1]);
            Assert.Equal(listTest[2], destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenNullShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = null;

            Assert.Throws<ArgumentNullException>(() => listTest.CopyTo(destinationArray, 0));

            Assert.Null(destinationArray);
        }

        [Fact]
        public void CopyToWhenIndexIsNegativeShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => listTest.CopyTo(destinationArray, -1));

            Assert.Equal(0, destinationArray[0]);
            Assert.Equal(0, destinationArray[1]);
            Assert.Equal(0, destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenIndexIsGreaterThanDestinationArrayLengthShouldThrowExceptionAndDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[4];

            Assert.Throws<ArgumentOutOfRangeException>(() => listTest.CopyTo(destinationArray, 5));

            Assert.Equal(0, destinationArray[0]);
            Assert.Equal(0, destinationArray[1]);
            Assert.Equal(0, destinationArray[2]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayLengthIsSmallerThanCountShouldDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[2];

            listTest.CopyTo(destinationArray, 0);

            Assert.Equal(0, destinationArray[0]);
            Assert.Equal(0, destinationArray[1]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayAvailableSpaceIsSmallerThanCountShouldDoNothing()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[5];

            listTest.CopyTo(destinationArray, 4);

            Assert.Equal(0, destinationArray[4]);
        }

        [Fact]
        public void CopyToWhenDestinationArrayIsOfTheSameSizeShouldCopyTheElements()
        {
            List<int> listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(2);
            listTest.Add(3);

            int[] destinationArray = new int[3];

            listTest.CopyTo(destinationArray, 0);

            Assert.Equal(listTest[0], destinationArray[0]);
            Assert.Equal(listTest[1], destinationArray[1]);
            Assert.Equal(listTest[2], destinationArray[2]);
        }
    }
}
