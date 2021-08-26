using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerFuncTE2Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            RunnerFunc<string, InvalidCastException, ApplicationException> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(
                    () => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ReturnTextWithTomato(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleApplicationExceptionWithFuncInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new ApplicationException());
            }

            Assert.Throws<ApplicationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
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

            RunnerFunc<string, InvalidCastException, ApplicationException> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(
                    () => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithActionInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleApplicationExceptionWithActionInHandler()
        {
            RunnerFunc<string, InvalidCastException, ApplicationException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException>(() =>
                    throw new ApplicationException());
            }

            Assert.Throws<ApplicationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                new Action<Exception>(exception => throw exception)));
        }
    }
}