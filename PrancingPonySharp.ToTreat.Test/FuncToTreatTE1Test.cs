using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class FuncToTreatTE1Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            FuncToTreat<string, InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string, InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException> ReturnTextWithTomato(string text)
            {
                return new FuncToTreat<string, InvalidCastException>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException>(() =>
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

            FuncToTreat<string, InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string, InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                new Action<Exception>(exception => throw exception)));
        }
    }
}