using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    // ReSharper disable once InconsistentNaming
    public class FuncToTreatTE4Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>
                ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(
                    () => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldReturnTheActualConcatenatedWithTomatoWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ReturnTextWithTomato(string text)
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() => text + "tomato");
            }

            var actual = ReturnTextWithTomato("concatenated with ").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception);
            Assert.Equal("concatenated with tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleApplicationExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new ApplicationException());
            }

            Assert.Throws<ApplicationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleAccessViolationExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new AccessViolationException());
            }

            Assert.Throws<AccessViolationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                exception => throw exception));
        }

        [Fact]
        public void ShouldHandleArgumentNullExceptionWithFuncInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new ArgumentNullException());
            }

            Assert.Throws<ArgumentNullException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
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

            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ApplyChangeActualToText(string text)
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(
                    () => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception));
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleInvalidCastExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new InvalidCastException());
            }

            Assert.Throws<InvalidCastException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleApplicationExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new ApplicationException());
            }

            Assert.Throws<ApplicationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception)));
        }


        [Fact]
        public void ShouldHandleAccessViolationExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new AccessViolationException());
            }

            Assert.Throws<AccessViolationException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception)));
        }

        [Fact]
        public void ShouldHandleArgumentNullExceptionWithActionInHandler()
        {
            FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new FuncToTreat<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
                    throw new ArgumentNullException());
            }

            Assert.Throws<ArgumentNullException>(() => ThrowException().RunOrFailure(
                invalidCastException => throw invalidCastException,
                applicationException => throw applicationException,
                accessViolationException => throw accessViolationException,
                argumentNullException => throw argumentNullException,
                new Action<Exception>(exception => throw exception)));
        }
    }
}