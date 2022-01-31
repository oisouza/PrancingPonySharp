using System;
using Xunit;

namespace PrancingPonySharp.QueueExtensions.Test
{
    public class LimitedQueueTest
    {
        [Fact]
        public void
            ShouldThrowAnIndexOutOfRangeExceptionIfTryingToQueueEnumeratorThatWillExceedLimitedQueueLimitWithCorrectMessage()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3
            }, 4);
            var enumerableToAdd = new[] {4, 5};
            var exception = Assert.Throws<IndexOutOfRangeException>(
                () => actual.EnqueueEnumerable(enumerableToAdd));
            Assert.Equal(
                $"Attempted to enqueue an invalid amount of values: The amount of remaining space in the queue is {actual.RemainingSpace}, if enqueue the amount of {enumerableToAdd.Length} will exceed the limit of {actual.Limit}.",
                exception.Message);
        }

        [Fact]
        public void
            ShouldThrowAnIndexOutOfRangeExceptionIfTryingToQueueItemThatWillExceedLimitedQueueLimitWithCorrectMessage()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4);
            const int item = 5;
            var exception = Assert.Throws<IndexOutOfRangeException>(
                () => actual.Enqueue(item));
            Assert.Equal(
                $"Attempted to enqueue an invalid amount of values: The amount of remaining space in the queue is {actual.RemainingSpace}, if enqueue the amount of {1} will exceed the limit of {actual.Limit}.",
                exception.Message);
        }

        [Fact]
        public void ShouldEnqueueEnumeratorIfThereIsRemainingSpace()
        {
            var expected = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4);
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2
            }, 4);
            var enumerableToAdd = new[] {3, 4};
            actual.EnqueueEnumerable(enumerableToAdd);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnqueueItemIfThereIsRemainingSpace()
        {
            var expected = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4);
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3
            }, 4);
            const int item = 4;
            actual.Enqueue(item);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LimitedQueueShouldBeFull()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4);
            Assert.True(actual.Full);
        }

        [Fact]
        public void LimitedQueueShouldntBeFull()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2
            }, 4);
            Assert.False(actual.Full);
        }

        [Fact]
        public void RemainingSpaceOfLimitedQueueShouldBeTwo()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2
            }, 4);
            const int expected = 2;
            Assert.Equal(expected, actual.RemainingSpace);
        }

        [Fact]
        public void RemainingSpaceOfLimitedQueueShouldBeZero()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4);
            const int expected = 0;
            Assert.Equal(expected, actual.RemainingSpace);
        }

        [Fact]
        public void LimitOfLimitedQueueShouldBeFour()
        {
            var actual = new LimitedQueue<int>(new[]
            {
                1, 2, 3, 4
            }, 4u);
            const int expected = 4;
            Assert.Equal(expected, actual.Limit);
        }
    }
}
