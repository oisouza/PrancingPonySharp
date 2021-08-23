using System;

namespace PrancingPonySharp.Try
{
    public readonly struct Try
    {
        private Action Function { get; }

        public Try(Action function)
        {
            Function = function;
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
