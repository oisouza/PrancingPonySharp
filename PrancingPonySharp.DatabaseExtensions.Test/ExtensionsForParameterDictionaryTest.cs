using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Moq;
using PrancingPonySharp.DatabaseExtensions.Test.Mock;
using Xunit;

namespace PrancingPonySharp.DatabaseExtensions.Test
{
    public class ExtensionsForParameterDictionaryTest
    {
        [Fact]
        public void ShouldConvertTheDictionaryIntoIEnumerableOfIDbDataParameter()
        {
            var dbDataParameterMock = new Mock<IDbDataParameter>();
            dbDataParameterMock.SetupProperty(x => x.Value);
            dbDataParameterMock.SetupProperty(x => x.ParameterName);
            var dbCommandMock = new Mock<IDbCommand>();
            var dataParameterCollectionMockObject = new DataParameterCollectionMockObject();
            dbCommandMock.SetupGet(x => x.Parameters)
                .Returns(dataParameterCollectionMockObject);
            dbCommandMock.Setup(x =>
                x.CreateParameter()).Returns(dbDataParameterMock.Object);
            var parameterDictionary = new Dictionary<string, object>
            {
                {"x", 1},
                {"y", 2}
            };
            var expected = parameterDictionary.Select(parameter =>
            {
                var dataParameter = dbCommandMock.Object.CreateParameter();
                var (key, value) = parameter;
                dataParameter.ParameterName = key;
                dataParameter.Value = value;
                return dataParameter;
            });
            Assert.Equal(expected, parameterDictionary.ConvertToParameters(dbCommandMock.Object));
        }
        
        [Fact]
        public void ShouldThrowAnNullReferenceExceptionWithTheCorrectMessageWhenPassingNullAsIDbCommandToConvertToParameters()
        {
            var dbDataParameterMock = new Mock<IDbDataParameter>();
            dbDataParameterMock.SetupProperty(x => x.Value);
            dbDataParameterMock.SetupProperty(x => x.ParameterName);
            var dbCommandMock = new Mock<IDbCommand>();
            var dataParameterCollectionMockObject = new DataParameterCollectionMockObject();
            dbCommandMock.SetupGet(x => x.Parameters)
                .Returns(dataParameterCollectionMockObject);
            dbCommandMock.Setup(x =>
                x.CreateParameter()).Returns(dbDataParameterMock.Object);
            var parameterDictionary = new Dictionary<string, object>
            {
                {"x", 1},
                {"y", 2}
            };
            var exception = Assert.Throws<NullReferenceException>(() => 
                parameterDictionary.ConvertToParameters(null));
            Assert.Equal("Attempt to use invalid command: It is not possible to use null variables as IDbCommand.",
                exception.Message);
        }
    }
}
