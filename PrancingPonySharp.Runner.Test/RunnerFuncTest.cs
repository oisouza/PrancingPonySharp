using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    public class RunnerFuncTest
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            RunnerFunc<string> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            RunnerFunc<string> ReturnTextWithTomato(string text)
            {
                return new RunnerFunc<string>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            RunnerFunc<string> ThrowException()
            {
                return new RunnerFunc<string>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                exception => throw exception));
        }

        [Fact]
        public void ShouldChangeTheActualToTomatoWithActionInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            RunnerFunc<string> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            RunnerFunc<string> ThrowException()
            {
                return new RunnerFunc<string>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                new Action<Exception>(exception => throw exception)));
        }
    }
}