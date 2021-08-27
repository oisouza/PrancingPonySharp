using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class ActionToTreatTE2Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            ActionToTreat<InvalidCastException, ArithmeticException> ApplyChangeActualToText(string text)
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException> ThrowException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArithmeticException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException>(() =>
                    throw new ArithmeticException());
            }

            Assert.Throws<ArithmeticException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                exception => throw exception));
        }
    }
}