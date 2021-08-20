using System;

namespace PrancingPonySharp.Result
{
    public readonly struct Result<T>
    {
        private T Value { get; }

        private Exception Exception { get; }

        public bool IsValue { get; }

        public bool IsException => !IsValue;

        public static implicit operator Result<T>(Func<T> functionToGetValue)
        {
            try
            {
                return new Result<T>(functionToGetValue(), true, null);
            }
            catch (Exception exception)
            {
                return new Result<T>(default, false, exception);
            }
        }

        public Result(T value, bool isValue, Exception exception)
        {
            Value = value;
            IsValue = isValue;
            Exception = exception;
        }

        /// <summary>
        ///     Accepts two delegate that return the type passed, one to handle if the value exists, the other if it is exception.
        /// </summary>
        public TR Matches<TR>(Func<T, TR> success, Func<Exception, TR> failure)
        {
            return IsValue ? success(Value) : failure(Exception);
        }

        /// <summary>
        ///     Accepts two delegate with no return, one to handle if the value exists and other if not.
        /// </summary>
        public void Matches(Action<T> success, Action<Exception> failure)
        {
            if (IsValue)
                success(Value);
            else
                failure(Exception);
        }
    }
}