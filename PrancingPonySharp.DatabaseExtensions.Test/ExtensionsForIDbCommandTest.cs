using System;
using System.Collections.Generic;
using System.Data;
using Moq;
using PrancingPonySharp.DatabaseExtensions.Test.Mock;
using Xunit;

namespace PrancingPonySharp.DatabaseExtensions.Test
{
    public class ExtensionsForIDbCommandTest
    {
        [Fact]
        public void ShouldBeAddParametersInIDbCommand()
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
            var expected = new Dictionary<string, object>
            {
                {"x", 1},
                {"y", 2},
                {"z", 3}
            };
            dbCommandMock.Object.AddParameters(expected.ConvertToParameters(dbCommandMock.Object));
            Assert.Equal(expected, dataParameterCollectionMockObject.Parameters);
        }
        
        [Fact]
        public void ShouldBeAddTwoParametersInIDbCommand()
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
            const int expected = 2;
            dbCommandMock.Object.AddParameters(
                new Dictionary<string, object>
                {
                    {"x", 1},
                    {"y", 2}
                }.ConvertToParameters(dbCommandMock.Object));
            Assert.Equal(expected, dataParameterCollectionMockObject.Parameters.Count);
        }
        
        [Fact]
        public void ShouldThrowAnNullReferenceExceptionWithTheCorrectMessageWhenPassingNullAsParametersToAddParameters()
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
            var exception = Assert.Throws<NullReferenceException>(() => 
                dbCommandMock.Object.AddParameters(null));
            Assert.Equal("Attempt to add invalid parameters: It is not possible to add null variables as parameters.",
                exception.Message);
        }
    }
}
