using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerActionTE2Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            RunnerAction<InvalidCastException, ArithmeticException> ApplyChangeActualToText(string text)
            {
                return new RunnerAction<InvalidCastException, ArithmeticException>(() => ChangeActualToText(text));
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
            RunnerAction<InvalidCastException, ArithmeticException> ThrowException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException>(() =>
                    throw new ArithmeticException());
            }

            Assert.Throws<ArithmeticException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                exception => throw exception));
        }
    }
}