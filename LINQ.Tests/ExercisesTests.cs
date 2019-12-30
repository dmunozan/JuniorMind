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
    }
}
