using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PrancingPonySharp.DatabaseExtensions
{
    public static class ExtensionsForParameterDictionary
    {
        public static IEnumerable<IDbDataParameter> ConvertToParameters(
            this IDictionary<string, object> parameterDictionary, IDbCommand command)
        {
            if (command is null)
            {
                const string exceptionMessage = "Attempt to use invalid command: It is not possible to use null variables as IDbCommand.";
                throw new NullReferenceException(exceptionMessage);
            };
            return parameterDictionary.Select(parameter => 
            {
                var dataParameter = command.CreateParameter();
                dataParameter.ParameterName = parameter.Key;
                dataParameter.Value = parameter.Value;
                return dataParameter;
            });
        }
    }
}
