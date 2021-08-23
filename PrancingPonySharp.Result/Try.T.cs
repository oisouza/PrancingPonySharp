using System;

namespace PrancingPonySharp.Try
{
    public readonly struct Try<T>
    {
        private Func<T> Function { get; }

        public Try(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailureHandle(Func<Exception, T> caseDefault)
        {
            try
            {
                return Function();
            }
            catch (Exception exception)
            {
                return caseDefault(exception);
            }
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
        /// </summary>
        public void RunOrFailureHandle(Action<Exception> caseDefault)
        {
            try
            {
                Function();
            }
            catch (Exception exception)
            {
                caseDefault(exception);
            }
        }
    }
}