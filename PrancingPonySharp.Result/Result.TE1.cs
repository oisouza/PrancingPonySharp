using System;

namespace PrancingPonySharp.Result
{
    public readonly struct Result<T, TE1> where TE1 : Exception
    {
        private T Value { get; }

        private TE1 Exception { get; }

        public bool IsValue { get; }

        public bool IsException => !IsValue;

        public static implicit operator Result<T, TE1>(Func<T> functionToGetValue)
        {
            try
            {
                return new Result<T, TE1>(functionToGetValue(), true, null);
            }
            catch (TE1 exception)
            {
                return new Result<T, TE1>(default, false, exception);
            }
        }

        public Result(T value, bool isValue, TE1 exception)
        {
            Value = value;
            IsValue = isValue;
            Exception = exception;
        }

        /// <summary>
        ///     Accepts two delegates that return the type passed, one to handle if the value exists, the other if it is exception.
        /// </summary>
        public TR Matches<TR>(Func<T, TR> success, Func<TE1, TR> failure)
        {
            return IsValue ? success(Value) : failure(Exception);
        }

        /// <summary>
        ///     Accepts two delegates with no return, one to handle if the value exists and other if not.
        /// </summary>
        public void Matches(Action<T> success, Action<TE1> failure)
        {
            if (IsValue)
                success(Value);
            else
                failure(Exception);
        }
    }
}