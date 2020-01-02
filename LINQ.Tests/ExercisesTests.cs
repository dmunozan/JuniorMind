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

            Assert.Equal((0, 0), testExercise.NumberOfLetters(""));
        }
    }
}
