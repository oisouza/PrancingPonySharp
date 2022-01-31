using System;
using System.Collections.Generic;
using System.Linq;

namespace PrancingPonySharp.QueueExtensions
{
    public class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(IEnumerable<T> enumerable, uint limit) : base(enumerable)
        {
            Limit = (int) limit;
        }

        public int Limit { get; }

        public bool Full => Count == Limit;

        public int RemainingSpace => Limit - Count;

        /// <summary>
        ///     Adds each value of an enumerable to the end of the Queue<T> if you have remaining space.
        /// </summary>
        public new void EnqueueEnumerable(IEnumerable<T> enumerable)
        {
            VerifiyIfThrowEnqueueException(enumerable.Count());
            base.EnqueueEnumerable(enumerable);
        }

        /// <summary>
        ///     Adds an object to the end of the Queue. if you have remaining space.
        /// </summary>
        public new void Enqueue(T item)
        {
            const int quantityToAdd = 1;
            VerifiyIfThrowEnqueueException(quantityToAdd);
            base.Enqueue(item);
        }

        private void VerifiyIfThrowEnqueueException(int quantity)
        {
            if (quantity <= RemainingSpace)
                return;
            var exceptionMessage =
                $"Attempted to enqueue an invalid amount of values: The amount of remaining space in the queue is {RemainingSpace}, if enqueue the amount of {quantity} will exceed the limit of {Limit}.";
            throw new IndexOutOfRangeException(exceptionMessage);
        }
    }
}
