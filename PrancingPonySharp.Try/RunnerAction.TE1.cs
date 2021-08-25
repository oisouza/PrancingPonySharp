using System;

namespace PrancingPonySharp.Runner
{
    public readonly struct RunnerAction<TE1>
        where TE1 : Exception
    {
        private Action Function { get; }

        public RunnerAction(Action function)
        {
            Function = function;
        }

        /// <summary>
        ///     RunnerAction to run the method or handle the exception.
        /// </summary>
        public void RunOrFailure(Action<TE1> caseFailure1, Action<Exception> caseFailureDefault)
        {
            try
            {
                Function();
            }
            catch (TE1 exception)
            {
                caseFailure1(exception);
            }
            catch (Exception exception)
            {
                caseFailureDefault(exception);
            }
        }
    }
}