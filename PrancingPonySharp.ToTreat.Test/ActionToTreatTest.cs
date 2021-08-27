using System;
using Xunit;

namespace PrancingPonySharp.ToTreat.Test
{
    public class ActionToTreatTest
    {
        [Fact]
        public void ShouldChangeTheActualToTomato()
        {
            var actual = string.Empty;

            void ChangeActualToText(string text)
            {
                actual = text;
            }

            ActionToTreat ApplyChangeActualToText(string text)
            {
                return new ActionToTreat(() => ChangeActualToText(text));
            }

            ApplyChangeActualToText("tomato").RunOrFailure(exception => throw exception);
            Assert.Equal("tomato", actual);
        }

        [Fact]
        public void ShouldHandleException()
        {
            ActionToTreat ThrowException()
            {
                return new ActionToTreat(() =>
                    throw new Exception());
            }

            Assert.Throws<Exception>(() => ThrowException().RunOrFailure(
                exception => throw exception));
        }
    }
}