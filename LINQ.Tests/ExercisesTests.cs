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
    }
}
