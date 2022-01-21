using System;
using System.Collections.Generic;

namespace PrancingPonySharp.QueueExtensions
{
    public static class QueueExtensions
    {
        /// <summary>
        ///     Adds each value of an enumerable to the end of the Queue<T>.
        /// </summary>
        public static void EnqueueEnumerable<T>(this Queue<T> queue, IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                queue.Enqueue(value);
        }

        /// <summary>
        ///     Dequeues a given amount of values at the beginning of the Queue<T> and returns them as a enumerable.
        /// </summary>
        public static IEnumerable<T> Dequeue<T>(this Queue<T> queue, int quantity)
        {
            if (queue.Count < quantity || quantity < 0)
            {
                var exceptionMessage =
                    $"Attempted to dequeue an invalid amount of values: The queue's length is {queue.Count} but the amount expected to dequeue is {quantity}.";
                throw new IndexOutOfRangeException(exceptionMessage);
            }
            var dequeuedList = new List<T>(quantity);
            for (var index = 0; index < quantity; index++)
                dequeuedList.Add(queue.Dequeue());
            return dequeuedList;
        }
    }
}
