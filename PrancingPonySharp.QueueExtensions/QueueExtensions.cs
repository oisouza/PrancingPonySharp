using System;
using System.Collections;
using System.Collections.Generic;

namespace PrancingPonySharp.QueueExtensions
{
    public static class QueueExtensions
    {
        /// <summary>
        ///     Adds an enumerable to the end of the Queue<T>.
        /// </summary>
        public static void EnqueueEnumerable<T>(this Queue<T> queue, IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                queue.Enqueue(value);
        }

        /// <summary>
        ///     Removes and returns the quantity of objects at the beginning of the Queue<T>.
        /// </summary>
        public static IEnumerable<T> Dequeue<T>(this Queue<T> queue, int quantity)
        {
            ValidateQuantityToAddToCollection(quantity, queue);
            var dequeuedList = new List<T>(quantity);
            for (var index = 0; index < quantity; index++)
                dequeuedList.Add(queue.Dequeue());
            return dequeuedList;
        }

        private static void ValidateQuantityToAddToCollection(int quantity, ICollection collection)
        {
            if (collection.Count < quantity || quantity < 0)
                throw new IndexOutOfRangeException($"The length is {collection.Count} but the quantity is {quantity}.");
        }
    }
}
