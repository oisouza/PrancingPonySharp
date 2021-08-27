using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class ActionToTreatTE1Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            ActionToTreat<InvalidCastException> ApplyChangeActualToText(string text)
            {
                return new ActionToTreat<InvalidCastException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            ActionToTreat<InvalidCastException> ThrowException()
            {
                return new ActionToTreat<InvalidCastException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastException()
        {
            ActionToTreat<InvalidCastException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                exception => throw exception));
        }
    }
}