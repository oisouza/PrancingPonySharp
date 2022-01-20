using System;
using System.Collections.Generic;
using Xunit;

namespace PrancingPonySharp.QueueExtensions.Test
{
    public class QueueExtensionsTest
    {
        [Fact]
        public void ShouldQueueEnumerable()
        {
            var expected = new Queue<string>(new[]
            {
                "one", "two", "three", "four"
            });
            var actual = new Queue<string>(new[]
            {
                "one"
            });
            actual.EnqueueEnumerable(new[]
            {
                "two", "three", "four"
            });
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldRemoveFirstTwoNumbersOfQueue()
        {
            var expected = new Queue<int>(new[]
            {
                3, 4
            });
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            actual.Dequeue(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnFirstTwoNumbersOfQueue()
        {
            var expected = new[]
            {
                1, 2
            };
            var queue = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = queue.Dequeue(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldRemoveEverythingFromTheQueueEvenIfItAsksForMoreElements()
        {
            var expected = new Queue<int>(0);
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            actual.Dequeue(200000);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnEverythingFromTheQueueEvenIfItAsksForMoreElements()
        {
            var expected = new[]
            {
                1, 2, 3, 4
            };
            var queue = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = queue.Dequeue(200000);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotModifyTheQueueIfItPassesZero()
        {
            var expected = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            actual.Dequeue(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnAnEmptyEnumerableIfYouPassZero()
        {
            var expected = Array.Empty<int>();
            var queue = new Queue<int>(new[]
            {
                1, 2, 3, 4
            });
            var actual = queue.Dequeue(0);
            Assert.Equal(expected, actual);
        }
    }
}
