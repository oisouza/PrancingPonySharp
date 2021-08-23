using System;
using System.Collections.Generic;
using Xunit;

namespace PrancingPonySharp.Maybe.Test
{
    public class MaybeUtilsTest
    {
        [Fact]
        public void ShouldWrapAStringValuePassed()
        {
            Maybe<string> expected = "eduardo";
            const string name = "eduardo";
            var actual = name.Wrap();
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestDataToSeeIfYouAreWrappingAModelTest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new ModelTest {TestValue = 662001}
                }
            };
        }

        [Theory]
        [MemberData(nameof(TestDataToSeeIfYouAreWrappingAModelTest))]
        public static void ShouldWrapATestModelPassed(ModelTest testModel)
        {
            Maybe<ModelTest> expected = testModel;
            var actual = testModel.Wrap();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldUnwrapAStringValueOfMaybe()
        {
            const string value = "actual value";
            Maybe<string> ifValue = value;
            Assert.Equal(value, ifValue.UnwrapOrThrowException());
        }

        [Fact]
        public void ShouldThrowAnInvalidOperationExceptionWhenTryingToUnwrapIfTheParameterExceptionIsNull()
        {
            const string value = null;
            Maybe<string> ifValue = value;
            Assert.Throws<InvalidOperationException>(() => ifValue.UnwrapOrThrowException());
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToUnwrapIfTheParameterExceptionIsException()
        {
            const string value = null;
            Maybe<string> ifValue = value;
            Assert.Throws<Exception>(() => ifValue.UnwrapOrThrowException(new Exception()));
        }

        [Fact]
        public void ShouldThrowAnArithmeticExceptionWhenTryingToUnwrapIfTheParameterExceptionIsArithmeticException()
        {
            const string value = null;
            Maybe<string> ifValue = value;
            Assert.Throws<ArithmeticException>(() => ifValue.UnwrapOrThrowException(new ArithmeticException()));
        }

        [Fact]
        public void ShouldReturnValueAfterUnwrappingAndIgnoreParameter()
        {
            const string value = "value";
            Maybe<string> ifValue = value;
            Assert.Equal(value, ifValue.UnwrapOr("ignored"));
        }

        [Fact]
        public void ShouldReturnValueParameterAfterUnwrappingIfValueIsNull()
        {
            const string valueExpected = "value of parameter";
            Maybe<string> ifValue = null;
            Assert.Equal(valueExpected, ifValue.UnwrapOr(valueExpected));
        }

        [Fact]
        public void ShouldApplyFunctionOfParameter()
        {
            Maybe<string> ifValue = "ignored";
            var condition = false;
            ifValue.ApplyFunctionIfItHasValueOrThrowException(_ => { condition = true; });
            Assert.True(condition);
        }

        [Fact]
        public void ShouldThrowAnInvalidOperationExceptionWhenTryingApplyFunctionIfTheParameterExceptionIsNull()
        {
            Maybe<string> ifValue = null;
            Assert.Throws<InvalidOperationException>(() => ifValue.ApplyFunctionIfItHasValueOrThrowException(_ => { }));
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingApplyFunctionIfTheParameterExceptionIsException()
        {
            Maybe<string> ifValue = null;
            Assert.Throws<Exception>(() =>
                ifValue.ApplyFunctionIfItHasValueOrThrowException(_ => { }, new Exception()));
        }

        [Fact]
        public void ShouldDoNothingAfterTryingToApplyAFunction()
        {
            Maybe<string> ifValue = null;
            var condition = false;
            ifValue.ApplyFunctionOrDoNothing(_ => { condition = true; });
            Assert.False(condition);
        }

        [Fact]
        public void ShouldApplyToFunction()
        {
            Maybe<string> ifValue = "ignored";
            var condition = false;
            ifValue.ApplyFunctionOrDoNothing(_ => { condition = true; });
            Assert.True(condition);
        }
    }
}