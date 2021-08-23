using Xunit;

namespace PrancingPonySharp.Maybe.Test
{
    public class MaybeStructTest
    {
        [Fact]
        public void MatchesShouldReturnAnErrorInStringIfNameIsNull()
        {
            Maybe<string> maybeName = null;
            var actual = maybeName.Matches(
                name => name,
                () => "is null value");
            Assert.Equal("is null value", actual);
        }

        [Fact]
        public void MatchesShouldReturnAnStringWithNameIfNameIsNotNull()
        {
            Maybe<string> maybeName = "eduardo";
            var actual = maybeName.Matches(
                name => name,
                () => "is null value");
            Assert.Equal("eduardo", actual);
        }

        [Fact]
        public void ShouldHaveChangedTheVariableSuccessToFalseIfNullValue()
        {
            Maybe<string> maybeName = null;
            var actual = true;
            maybeName.Matches(
                _ => { actual = true; },
                () => { actual = false; });
            Assert.False(actual);
        }

        [Fact]
        public void ShouldHaveChangedTheVariableSuccessToTrueIfNotNullValue()
        {
            Maybe<string> maybeName = "eduardo";
            var actual = false;
            maybeName.Matches(
                _ => { actual = true; },
                () => { actual = false; });
            Assert.True(actual);
        }

        [Fact]
        public void ShouldBeTrueIfItHasANoValue()
        {
            Maybe<string> maybeName = null;
            var actual = !maybeName.IsValue && maybeName.IsNull;
            Assert.True(actual);
        }

        [Fact]
        public void ShouldBeTrueIfItHasAValue()
        {
            Maybe<string> maybeName = "eduardo";
            var actual = maybeName.IsValue && !maybeName.IsNull;
            Assert.True(actual);
        }
    }
}