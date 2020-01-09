using System;
using Xunit;

namespace LINQ.Tests
{
    public class ExercisesTests
    {
        [Fact]
        public void NumberOfLettersWhenEmptyStringShouldReturn0ConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 0), testExercise.NumberOfLetters(""));
        }

        [Fact]
        public void NumberOfLettersWhenNoEmptyStringShouldReturnNumberOfConsonantsAndVowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((12, 5), testExercise.NumberOfLetters("This is a test string"));
        }

        [Fact]
        public void NumberOfLettersWhenOnlyConsonantsShouldReturnNumberOfConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((12, 0), testExercise.NumberOfLetters("Ths s tst strng"));
        }

        [Fact]
        public void NumberOfLettersWhenOnlyVowelsShouldReturn0ConsonantsAndNumberOfVowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 5), testExercise.NumberOfLetters("a, e, i, o, u!!!."));
        }

        [Fact]
        public void NumberOfLettersWhenNullStringShouldReturn0ConsonantsAnd0Vowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal((0, 0), testExercise.NumberOfLetters(null));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.FirstNotRepeatedChar(""));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenNotEmptyStringShouldReturnFirstNotRepeatedChar()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal('h', testExercise.FirstNotRepeatedChar("This Is A Test String!"));
        }

        [Fact]
        public void FirstNotRepeatedCharWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.FirstNotRepeatedChar(null));
        }

        [Fact]
        public void ConvertToIntWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt(""));
        }

        [Fact]
        public void ConvertToIntWhenValidCharsShouldReturnEquivalentNumber()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(1, testExercise.ConvertToInt("1"));
        }

        [Fact]
        public void ConvertToIntWhenValidNegativeSymbolShouldReturnEquivalentNumber()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(-1, testExercise.ConvertToInt("-1"));
        }

        [Fact]
        public void ConvertToIntWhenInvalidCharsShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt("one"));
        }

        [Fact]
        public void ConvertToIntWhenInvalidNegativeSymbolShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<FormatException>(() => testExercise.ConvertToInt("1-"));
        }

        [Fact]
        public void ConvertToIntWhenHigherThanIntShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<OverflowException>(() => testExercise.ConvertToInt("2147483648"));
        }

        [Fact]
        public void ConvertToIntWhenLowerThanIntShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<OverflowException>(() => testExercise.ConvertToInt("-2147483649"));
        }

        [Fact]
        public void ConvertToIntWhenNullShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.ConvertToInt(null));
        }

        [Fact]
        public void MostRepeatedCharWhenEmptyStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<InvalidOperationException>(() => testExercise.MostRepeatedChar(""));
        }

        [Fact]
        public void MostRepeatedCharWhenNotEmptyStringShouldReturnMostRepeatedChar()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(' ', testExercise.MostRepeatedChar("This Is A Test String!"));
        }

        [Fact]
        public void MostRepeatedCharWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.MostRepeatedChar(null));
        }

        [Fact]
        public void PalindromeGeneratorWhenEmptyStringShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.PalindromeGenerator(""));
        }

        [Fact]
        public void PalindromeGeneratorWhenNotEmptyStringShouldReturnSequenceOfPalindromes()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.PalindromeGenerator("aabaac"),
                item => Assert.Equal("a", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("b", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("c", item),
                item => Assert.Equal("aa", item),
                item => Assert.Equal("aa", item),
                item => Assert.Equal("aba", item),
                item => Assert.Equal("aabaa", item));
        }

        [Fact]
        public void PalindromeGeneratorWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.PalindromeGenerator(null));
        }

        [Fact]
        public void SubarraysOfKWhenArrayIsEmptyShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.SubarraysOfK(new int[] { }, 9));
        }

        [Fact]
        public void SubarraysOfKWhenArrayIsNotEmptyShouldReturnSubarraysOfKThatAddKOrLess()
        {
            Exercises testExercise = new Exercises();

            Assert.Collection(testExercise.SubarraysOfK(new int[] { 1, 2, 3 }, 5),
                item => Assert.Equal(new int[] { 1 }, item),
                item => Assert.Equal(new int[] { 2 }, item),
                item => Assert.Equal(new int[] { 3 }, item),
                item => Assert.Equal(new int[] { 1, 2 }, item),
                item => Assert.Equal(new int[] { 2, 3 }, item));
        }

        [Fact]
        public void SubarraysOfKWhenNullArrayShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.SubarraysOfK(null, 0));
        }

        [Fact]
        public void SummationOfNWhenNIs0ShouldReturnEmptySequence()
        {
            Exercises testExercise = new Exercises();

            Assert.Empty(testExercise.SummationOfN(0, 0));
        }
    }
}
