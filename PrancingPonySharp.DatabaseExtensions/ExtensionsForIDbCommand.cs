using System;
using System.Collections.Generic;
using System.Data;

namespace PrancingPonySharp.DatabaseExtensions
{
    public static class ExtensionsForIDbCommand
    {
        /// <summary>
        ///     Adds a IEnumerable<IDbDataParameter> to the IDbCommand.
        /// </summary>
        public static void AddParameters(this IDbCommand command, IEnumerable<IDbDataParameter> parameters)
        {
            if (parameters is null)
            {
                const string exceptionMessage = "Attempt to add invalid parameters: It is not possible to add null variables as parameters.";
                throw new NullReferenceException(exceptionMessage);
            };
            foreach (var parameter in parameters) 
                command.Parameters.Add(parameter);
        }
    }
}
