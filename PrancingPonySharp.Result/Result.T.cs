using System;

namespace PrancingPonySharp.Result
{
    public readonly struct Result<T>
    {
        private Func<T> Function { get; }

        public Result(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailureHandle(Func<Exception, T> failure)
        {
            try
            {
                return Function();
            }
            catch (Exception exception)
            {
                return failure(exception);
            }
        }

        /// <summary>
        ///     Return T or identify if there is an exception.
        /// </summary>
        public void RunOrFailureHandle(Action<Exception> failure)
        {
            try
            {
                Function();
            }
            catch (Exception exception)
            {
                failure(exception);
            }
        }
    }
}