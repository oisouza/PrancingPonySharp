using System;

namespace PrancingPonySharp.Runner
{
    public readonly struct RunnerFunc<T, TE1, TE2, TE3, TE4>
        where TE1 : Exception
        where TE2 : Exception
        where TE3 : Exception
        where TE4 : Exception
    {
        private Func<T> Function { get; }

        public RunnerFunc(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        ///     Return T or identify if there is an exception returning T.
        /// </summary>
        public T RunOrFailure(Func<TE1, T> caseFailure1, Func<TE2, T> caseFailure2, Func<TE3, T> caseFailure3,
            Func<TE4, T> caseFailure4,
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
            catch (TE3 exception)
            {
                return caseFailure3(exception);
            }
            catch (TE4 exception)
            {
                return caseFailure4(exception);
            }
            catch (Exception exception)
            {
                return caseFailureDefault(exception);
            }
        }

        /// <summary>
        ///     Try to run the method or handle the exception.
        /// </summary>
        public void RunOrFailure(Action<TE1> caseFailure1, Action<TE2> caseFailure2, Action<TE3> caseFailure3,
            Action<TE4> caseFailure4,
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
            catch (TE3 exception)
            {
                caseFailure3(exception);
            }
            catch (TE4 exception)
            {
                caseFailure4(exception);
            }
            catch (Exception exception)
            {
                caseFailureDefault(exception);
            }
        }
    }
}