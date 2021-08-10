using System.Collections.Generic;
using PrancingPonySharp.DataStructures.Maybe;
using PrancingPonySharp.Test.DataStructures.Model;
using Xunit;

namespace PrancingPonySharp.Test.DataStructures.Maybe
{
    public class UnitTestMaybeUtils
    {
        [Fact]
        public void ShouldWrapAStringValuePassed()
        {
            Maybe<string> expected = "eduardo";

            const string name = "eduardo";

            var actual = name.Maybe();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestDataToSeeIfYouAreWrappingAModelTest()
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
        [MemberData(nameof(TestDataToSeeIfYouAreWrappingAModelTest))]
        public static void ShouldWrapATestModelPassed(TestModel testModel)
        {
            Maybe<TestModel> expected = testModel;

            var actual = testModel.Maybe();

            Assert.Equal(expected, actual);
        }
    }
}
