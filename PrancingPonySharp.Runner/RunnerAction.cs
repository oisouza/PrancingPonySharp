using System;

namespace PrancingPonySharp.Runner
{
    public readonly struct RunnerAction
    {
        private Action Function { get; }

        public RunnerAction(Action function)
        {
            Function = function;
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