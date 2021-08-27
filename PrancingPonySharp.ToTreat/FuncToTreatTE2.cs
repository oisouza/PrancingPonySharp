using System;

namespace PrancingPonySharp.ToTreat
{
    public readonly struct FuncToTreat<T, TE1, TE2>
        where TE1 : Exception
        where TE2 : Exception
    {
        private Func<T> Function { get; }

        public FuncToTreat(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailure(Func<TE1, T> caseFailure1, Func<TE2, T> caseFailure2,
            Func<Exception, T> caseFailureDefault)
        {
            try
            {
                return Function();
            }
            catch (TE1 exception)
            {
                return caseFailure1(exception);
            }
            catch (TE2 exception)
            {
                return caseFailure2(exception);
            }
            catch (Exception exception)
            {
                return caseFailureDefault(exception);
            }
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