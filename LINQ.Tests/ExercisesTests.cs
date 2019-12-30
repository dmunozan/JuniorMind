using System;
using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class ExercisesTests
    {
        [Fact]
        public void NumberOfVocalsWhenEmptyStringShouldReturn0()
        {
            Exercises testExercise = new Exercises();
            
            Assert.Equal(0, testExercise.NumberOfVocals(""));
        }

        [Fact]
        public void NumberOfVocalsWhenNoEmptyStringShouldReturnNumberOfVocals()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(5, testExercise.NumberOfVocals("This is a test string"));
        }

        [Fact]
        public void NumberOfVocalsWhenNullStringShouldThrowException()
        {
            Exercises testExercise = new Exercises();

            Assert.Throws<ArgumentNullException>(() => testExercise.NumberOfVocals(null));
        }

        [Fact]
        public void NumberOfConsonantsWhenEmptyStringShouldReturn0()
        {
            Exercises testExercise = new Exercises();

            Assert.Equal(0, testExercise.NumberOfConsonants(""));
        }
    }
}
