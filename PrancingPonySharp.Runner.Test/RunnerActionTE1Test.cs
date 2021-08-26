using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerActionTE1Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            RunnerAction<InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new RunnerAction<InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            RunnerAction<InvalidCastException> ThrowException()
            {
                return new RunnerAction<InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastException()
        {
            RunnerAction<InvalidCastException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }
    }
}