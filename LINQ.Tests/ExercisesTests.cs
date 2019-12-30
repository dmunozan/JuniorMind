using Xunit;

namespace LINQ.Tests
{
    public class ExercisesTests
    {
        [Fact]
        public void NumberOfVowelsWhenEmptyStringShouldReturn0()
        {
            Exercises testExercise = new Exercises();
            
            Assert.Equal(0, testExercise.NumberOfVowels(""));
        }

        [Fact]
        public void NumberOfVowelsWhenNoEmptyStringShouldReturnNumberOfVowels()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(5, testExercise.NumberOfVowels("This is a test string"));
        }

        [Fact]
        public void NumberOfVowelsWhenNullStringShouldReturn0()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(0, testExercise.NumberOfVowels(null));
        }

        [Fact]
        public void NumberOfConsonantsWhenEmptyStringShouldReturn0()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(0, testExercise.NumberOfConsonants(""));
        }

        [Fact]
        public void NumberOfConsonantsWhenNoEmptyStringShouldReturnNumberOfConsonants()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(12, testExercise.NumberOfConsonants("This is a test string."));
        }
    }
}
