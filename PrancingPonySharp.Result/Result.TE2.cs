using System;

namespace PrancingPonySharp.Result
{
    public readonly struct Result<T, TE, TE2> where TE : Exception where TE2 : Exception
    {
        private T Value { get; }

        private TE Exception { get; }

        private TE2 Exception2 { get; }

        public bool IsValue { get; }

        public bool IsException => !IsValue;

        public static implicit operator Result<T, TE, TE2>(Func<T> functionToGetValue)
        {
            try
            {
                return new Result<T, TE, TE2>(functionToGetValue(), true, null, null);
            }
            catch (TE exception)
            {
                return new Result<T, TE, TE2>(default, false, exception, null);
            }
            catch (TE2 exception)
            {
                return new Result<T, TE, TE2>(default, false, null, exception);
            }
        }

        public Result(T value, bool isValue, TE exception, TE2 exception2)
        {
            Value = value;
            IsValue = isValue;
            Exception = exception;
            Exception2 = exception2;
        }

        /// <summary>
        ///     Accepts three delegates that return the type passed, one to handle if the value exists.
        /// </summary>
        public TR Matches<TR>(Func<T, TR> success, Func<TE, TR> failure, Func<TE2, TR> failure2)
        {
            if (IsValue)
                return success(Value);
            if (Exception != null)
                return failure(Exception);

            return Exception2 != null ? failure2(Exception2) : default;
        }

        /// <summary>
        ///     Accepts three delegates with no return, one to handle if the value exists and other if not.
        /// </summary>
        public void Matches(Action<T> success, Action<TE> failure, Action<TE2> failure2)
        {
            if (IsValue)
                success(Value);
            else if (Exception != null)
                failure(Exception);
            else if (Exception2 != null)
                failure2(Exception2);
        }
    }
}