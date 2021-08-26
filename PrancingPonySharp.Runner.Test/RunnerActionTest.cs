using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    public class RunnerActionTest
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            RunnerAction ApplyChangeActualToText(string text)
            {
                return new RunnerAction(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            RunnerAction ThrowException()
            {
                return new RunnerAction(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                exception => throw exception));
        }
    }
}