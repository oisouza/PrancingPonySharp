using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class ActionToTreatTE3Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException> ApplyChangeActualToText(
                string text)
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException>(() =>
                    ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException> ThrowException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArithmeticException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException>(() =>
                    throw new ArithmeticException());
            }

            Assert.Throws<ArithmeticException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArgumentException()
        {
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException>(() =>
                    throw new ArgumentException());
            }

            Assert.Throws<ArgumentException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                exception => throw exception));
        }
    }
}