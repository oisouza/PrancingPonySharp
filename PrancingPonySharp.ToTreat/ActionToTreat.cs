using System;

namespace PrancingPonySharp.ToTreat
{
    public readonly struct ActionToTreat
    {
        private Action Function { get; }

        public ActionToTreat(Action function)
        {
            Function = function;
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
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