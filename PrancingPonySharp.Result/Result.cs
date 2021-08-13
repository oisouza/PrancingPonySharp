using System;

namespace PrancingPonySharp.Result
{
    public readonly struct Result<T, TE> where TE : Exception
    {
        private T Value { get; }

        private TE Exception { get; }

        public bool IsValue { get; }

        public bool IsException => !IsValue;

        public static implicit operator Result<T, TE>(Func<T> functionToGetValue)
        {
            try
            {
                return new Result<T, TE>(functionToGetValue(), true, null);
            }
            catch (TE exception)
            {
                return new Result<T, TE>(default, false, exception);
            }
        }

        public Result(T value, bool isValue, TE exception)
        {
            Value = value;
            IsValue = isValue;
            Exception = exception;
        }

        /// <summary>
        ///     Accepts two delegates that return the type passed, one to handle if the value exists, the other if it is exception.
        /// </summary>
        public TR Matches<TR>(Func<T, TR> success, Func<TE, TR> failure)
        {
            return IsValue ? success(Value) : failure(Exception);
        }

        /// <summary>
        ///     Accepts two delegates that return the type passed, one to handle if the value exists, the other if it is exception.
        /// </summary>
        public void Matches(Action<T> success, Action<TE> failure)
        {
            if (IsValue)
                success(Value);
            else
                failure(Exception);
        }
    }
}