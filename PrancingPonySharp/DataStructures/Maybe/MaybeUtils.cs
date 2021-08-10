using System;

namespace PrancingPonySharp.DataStructures.Maybe
{
    public static class MaybeUtils
    {
        public static Maybe<T> Wrap<T>(this T value)
        {
            return value;
        }

        public static T TryUnwrap<T>(this Maybe<T> ifValue, Exception exception = null)
        {
            return ifValue.Matches(
                value => value,
                () => throw (exception ?? new InvalidOperationException(
                    $"Accessed Maybe<T>. Value when IsValue is false. Use Maybe<T>.{nameof(UnwrapOr)} instead of Maybe<T>.Value")));
        }

        public static T UnwrapOr<T>(this Maybe<T> ifValue, T or)
        {
            return ifValue.Matches(
                value => value,
                () => or);
        }

        public static void TryApplyFunction<T>(this Maybe<T> ifValue, Action<T> function, Exception exception = null)
        {
            ifValue.Matches(
                function,
                () =>
                {
                    if (exception == null)
                        throw new InvalidOperationException(
                            $"Apply a function on Value failed because value is null, try using Maybe<T>.{nameof(Maybe<T>.Matches)}");
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
