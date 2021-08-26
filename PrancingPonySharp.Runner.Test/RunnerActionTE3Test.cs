using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerActionTE3Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException> ApplyChangeActualToText(
                string text)
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException> ThrowException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException>(() =>
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
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException> ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException>(() =>
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