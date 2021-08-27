using System;

namespace PrancingPonySharp.ToTreat
{
    public readonly struct ActionToTreat<TE1>
        where TE1 : Exception
    {
        private Action Function { get; }

        public ActionToTreat(Action function)
        {
            Function = function;
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
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