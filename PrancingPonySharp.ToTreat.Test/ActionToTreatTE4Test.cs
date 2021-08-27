using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class ActionToTreatTE4Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ApplyChangeActualToText(string text)
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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
            ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException, ContextMarshalException>
                ThrowInvalidCastException()
            {
                return new ActionToTreat<InvalidCastException, ArithmeticException, ArgumentException,
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