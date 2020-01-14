﻿using Xunit;

namespace LINQ.Tests
{
    public class TestResultsTests
    {
        [Fact]
        public void IdWhenGetShouldReturnId()
        {
            TestResults result = new TestResults("A", "Adam");

            Assert.Equal("A", result.Id);
        }

        [Fact]
        public void IdWhenSetShouldSetId()
        {
            TestResults result = new TestResults("A", "Adam");

            result.Id = "B";

            Assert.Equal("B", result.Id);
        }

        [Fact]
        public void FamilyIdWhenGetShouldReturnFamilyId()
        {
            TestResults result = new TestResults("A", "Adam");

            Assert.Equal("Adam", result.FamilyId);
        }

        [Fact]
        public void FamilyIdWhenSetShouldSetFamilyId()
        {
            TestResults result = new TestResults("A", "Adam");

            result.FamilyId = "Brown";

            Assert.Equal("Brown", result.FamilyId);
        }
    }
}
