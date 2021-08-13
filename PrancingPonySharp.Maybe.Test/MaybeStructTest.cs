﻿using Xunit;

namespace PrancingPonySharp.Maybe.Test
{
    public class MaybeStructTest
    {
        [Fact]
        public void MatchesShouldReturnAnErrorInStringIfNameIsNull()
        {
            Maybe<string> ifName = null;

            var actual = ifName.Matches(
                name => name,
                () => "is null value");

            Assert.Equal("is null value", actual);
        }

        [Fact]
        public void MatchesShouldReturnAnStringWithNameIfNameIsNotNull()
        {
            Maybe<string> ifName = "eduardo";

            var actual = ifName.Matches(
                name => name,
                () => "is null value");

            Assert.Equal("eduardo", actual);
        }

        [Fact]
        public void ShouldHaveChangedTheVariableSuccessToFalseIfNullValue()
        {
            Maybe<string> ifName = null;

            var actual = true;

            ifName.Matches(
                _ => { actual = true; },
                () => { actual = false; });

            Assert.False(actual);
        }

        [Fact]
        public void ShouldHaveChangedTheVariableSuccessToTrueIfNotNullValue()
        {
            Maybe<string> ifName = "eduardo";

            var actual = false;

            ifName.Matches(
                _ => { actual = true; },
                () => { actual = false; });

            Assert.True(actual);
        }

        [Fact]
        public void ShouldBeTrueIfItHasANoValue()
        {
            Maybe<string> ifName = null;

            var actual = !ifName.IsValue && ifName.IsNull;

            Assert.True(actual);
        }

        [Fact]
        public void ShouldBeTrueIfItHasAValue()
        {
            Maybe<string> ifName = "eduardo";

            var actual = ifName.IsValue && !ifName.IsNull;

            Assert.True(actual);
        }
    }
}