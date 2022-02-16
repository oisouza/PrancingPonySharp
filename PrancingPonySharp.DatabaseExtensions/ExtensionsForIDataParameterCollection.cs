using System;
using System.Collections.Generic;
using System.Data;

namespace PrancingPonySharp.DatabaseExtensions
{
    public static class ExtensionsForIDataParameterCollection
    {
        /// <summary>
        ///     Adds a dictionary with parameters to the IDbCommand.
        /// </summary>
        public static void AddParameters(this IDbCommand command, 
            IDictionary<string, object> parameters)
        {
            if (parameters is null)
            {
                const string exceptionMessage = "Attempt to add invalid parameters: It is not possible to add null variables as parameters.";
                throw new NullReferenceException(exceptionMessage);
            };
            foreach (var parameter in parameters)
            {
                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = parameter.Key;
                dataParameter.Value = parameter.Value;
                command.Parameters.Add(dataParameter);
            }
        }
    }
}
