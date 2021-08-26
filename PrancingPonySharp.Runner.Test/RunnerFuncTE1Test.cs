using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerFuncTE1Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            RunnerFunc<string, InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException> ReturnTextWithTomato(string text)
            {
                return new RunnerFunc<string, InvalidCastException>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
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

            RunnerFunc<string, InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            RunnerFunc<string, InvalidCastException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithActionInHandler()
        {
            RunnerFunc<string, InvalidCastException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception)));
        }
    }
}