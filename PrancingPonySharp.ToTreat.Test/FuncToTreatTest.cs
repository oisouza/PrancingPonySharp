using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    public class FuncToTreatTest
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            FuncToTreat<string> ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            FuncToTreat<string> ReturnTextWithTomato(string text)
            {
                return new FuncToTreat<string>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            FuncToTreat<string> ThrowException()
            {
                return new FuncToTreat<string>(() =>
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

            FuncToTreat<string> ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            FuncToTreat<string> ThrowException()
            {
                return new FuncToTreat<string>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                new Action<Exception>(exception => throw exception)));
        }
    }
}