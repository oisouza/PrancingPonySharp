using System;

namespace PrancingPonySharp.Runner
{
    public readonly struct RunnerFunc<T>
    {
        private Func<T> Function { get; }

        public RunnerFunc(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailure(Func<Exception, T> caseFailureDefault)
        {
            try
            {
                return Function();
            }
            catch (Exception exception)
            {
                return caseFailureDefault(exception);
            }
        }

        /// <summary>
        ///     RunnerAction to run the method or handle the exception.
        /// </summary>
        public void RunOrFailure(Action<Exception> caseFailureDefault)
        {
            try
            {
                Function();
            }
            catch (Exception exception)
            {
                caseFailureDefault(exception);
            }
        }
    }
}