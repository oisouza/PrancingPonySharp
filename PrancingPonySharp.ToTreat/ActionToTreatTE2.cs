using System;

namespace PrancingPonySharp.ToTreat
{
    public readonly struct ActionToTreat<TE1, TE2>
        where TE1 : Exception
        where TE2 : Exception
    {
        private Action Function { get; }

        public ActionToTreat(Action function)
        {
            Function = function;
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
        /// </summary>
        public void RunOrFailure(Action<TE1> caseFailure1, Action<TE2> caseFailure2,
            Action<Exception> caseFailureDefault)
        {
            try
            {
                Function();
            }
            catch (TE1 exception)
            {
                caseFailure1(exception);
            }
            catch (TE2 exception)
            {
                caseFailure2(exception);
            }
            catch (Exception exception)
            {
                caseFailureDefault(exception);
            }
        }
    }
}