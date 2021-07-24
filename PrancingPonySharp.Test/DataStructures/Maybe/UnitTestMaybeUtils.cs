using System.Collections.Generic;
using PrancingPonySharp.DataStructures.Maybe;
using PrancingPonySharp.Test.DataStructures.Model;
using Xunit;

namespace PrancingPonySharp.Test.DataStructures.Maybe
{
    public class UnitTestMaybeUtils
    {
        [Fact]
        public void ShouldRewrapAStringValuePassed()
        {
            Maybe<string> expected = "eduardo";

            const string name = "eduardo";

            var actual = name.Rewrap();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestDataToSeeIfYouAreRewrappingAModelTest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TestModel {TestValue = 662001}
                }
            };
        }

        [Theory]
        [MemberData(nameof(TestDataToSeeIfYouAreRewrappingAModelTest))]
        public static void ShouldRewrapATestModelPassed(TestModel testModel)
        {
            Maybe<TestModel> expected = testModel;

            var actual = testModel.Rewrap();

            Assert.Equal(expected, actual);
        }
    }
}
