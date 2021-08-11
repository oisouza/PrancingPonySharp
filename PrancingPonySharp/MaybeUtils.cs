using System;

namespace PrancingPonySharp.DataStructures.Maybe
{
    public static class MaybeUtils
    {
        public static Maybe<T> Wrap<T>(this T value)
        {
            return value;
        }

        public static T UnwrapOrThrowException<T>(this Maybe<T> ifValue, Exception exception = null)
        {
            var value = ifValue.Matches(
                wrappedValue => wrappedValue,
                () => throw (exception ?? new InvalidOperationException(
                    $"Maybe<T> is null. Try using Maybe<T>.{nameof(UnwrapOr)} to have no exceptions and put a value by default.")));

            return value;
        }

        public static T UnwrapOr<T>(this Maybe<T> ifValue, T defaultValue)
        {
            var value = ifValue.Matches(
                wrappedValue => wrappedValue,
                () => defaultValue);

            return value;
        }

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

        public static void ApplyFunctionOrDoNothing<T>(this Maybe<T> ifValue, Action<T> function)
        {
            ifValue.Matches(
                function,
                () => { });
        }
    }
}
