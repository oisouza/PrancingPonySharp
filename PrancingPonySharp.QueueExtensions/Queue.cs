using System;
using System.Collections.Generic;

namespace PrancingPonySharp.QueueExtensions
{
    public class Queue<T> : System.Collections.Generic.Queue<T>
    {
        public Queue()
        {
        }

        public Queue(IEnumerable<T> enumerable) : base(enumerable)
        {
        }

        /// <summary>
        ///     Adds each value of an enumerable to the end of the Queue<T>.
        /// </summary>
        public void EnqueueEnumerable(IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                Enqueue(value);
        }

        /// <summary>
        ///     Dequeues a given amount of values at the beginning of the Queue<T> and returns them as a enumerable.
        /// </summary>
        public IEnumerable<T> DequeueEnumerable(int quantity)
        {
            if (Count < quantity || quantity < 0)
            {
                var exceptionMessage =
                    $"Attempted to dequeue an invalid amount of values: The queue's length is {Count} but the amount expected to dequeue is {quantity}.";
                throw new IndexOutOfRangeException(exceptionMessage);
            }
            var dequeuedList = new List<T>(quantity);
            for (var index = 0; index < quantity; index++)
                dequeuedList.Add(Dequeue());
            return dequeuedList;
        }
    }
}
