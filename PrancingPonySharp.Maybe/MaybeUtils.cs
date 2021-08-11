using System;

namespace PrancingPonySharp.Maybe
{
    public static class MaybeUtils
    {
        /// <summary>
        /// Wrap an T data and return a Maybe Struct.
        /// </summary>
        public static Maybe<T> Wrap<T>(this T value)
        {
            return value;
        }

        /// <summary>
        /// UnwrapOrThrowException tries to unwrap the value encapsulated or throw an Exception. By default the exception is an InvalidOperationException with the message. Or choose the exception for the error in the method parameter.
        /// </summary>
        public static T UnwrapOrThrowException<T>(this Maybe<T> ifValue, Exception exception = null)
        {
            var value = ifValue.Matches(
                wrappedValue => wrappedValue,
                () => throw (exception ?? new InvalidOperationException(
                    $"Maybe<T> is null. Try using Maybe<T>.{nameof(UnwrapOr)} to have no exceptions and put a value by default.")));

            return value;
        }

        /// <summary>
        /// UnwrapOr the encapsulated value or return the parameter value.
        /// </summary>
        public static T UnwrapOr<T>(this Maybe<T> ifValue, T defaultValue)
        {
            var value = ifValue.Matches(
                wrappedValue => wrappedValue,
                () => defaultValue);

            return value;
        }

        /// <summary>
        /// Apply a function on the value and if it is null throws an exception.
        /// </summary>
        public static void ApplyFunctionIfItHasValueOrThrowException<T>(this Maybe<T> ifValue, Action<T> functionIfItHasValue,
            Exception exception = null)
        {
            ifValue.Matches(
                functionIfItHasValue,
                () =>
                {
                    if (exception == null)
                        throw new InvalidOperationException(
                            $"Apply a functionIfItHasValue on Value failed because value is null. Try using {nameof(Maybe<T>.Matches)} to handle if null, or {nameof(ApplyFunctionOrDoNothing)} to do nothing if null.");
                    throw exception;
                });
        }

        /// <summary>
        /// Apply a function to the value and if it is null it does nothing.
        /// </summary>
        public static void ApplyFunctionOrDoNothing<T>(this Maybe<T> ifValue, Action<T> function)
        {
            ifValue.Matches(
                function,
                () => { });
        }
    }
}
