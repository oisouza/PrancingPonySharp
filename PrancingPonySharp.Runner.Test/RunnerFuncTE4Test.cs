using System;
using Xunit;

namespace PrancingPonySharp.Runner.Test
{
    // ReSharper disable once InconsistentNaming
    public class RunnerFuncTE4Test
    {
        [Fact]
        public void ShouldChangeTheActualToTomatoWithFuncInHandler()
        {
            var actual = string.Empty;

            string ChangeActualToText(string text)
            {
                return actual = text;
            }

            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>
                ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ReturnTextWithTomato(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() => text + "tomato");
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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

            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ApplyChangeActualToText(string text)
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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
            RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException> ThrowException()
            {
                return new RunnerFunc<string, InvalidCastException, ApplicationException, AccessViolationException, ArgumentNullException>(() =>
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