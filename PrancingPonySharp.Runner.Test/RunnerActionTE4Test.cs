using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerActionTE4Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ApplyChangeActualToText(string text)
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastException()
        {
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArithmeticException()
        {
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() =>
                    throw new ArithmeticException());
            }

            Assert.Throws<ArithmeticException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArgumentException()
        {
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() =>
                    throw new ArgumentException());
            }

            Assert.Throws<ArgumentException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleContextMarshalException()
        {
            RunnerAction<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new RunnerAction<InvalidCastException, ArithmeticException, ArgumentException,
                    ContextMarshalException>(() =>
                    throw new ContextMarshalException());
            }

            Assert.Throws<ContextMarshalException>(() => ThrowInvalidCastException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                arithmeticException => throw arithmeticException,
                argumentException => throw argumentException,
                contextMarshalException => throw contextMarshalException,
                exception => throw exception));
        }
    }
}