using System.Collections.Generic;

namespace PrancingPonySharp.QueueExtensions
{
    public static class QueueExtensions
    {
        public static void EnqueueEnumerable<T>(this Queue<T> queue, IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                queue.Enqueue(value);
        }

        public static IEnumerable<T> Dequeue<T>(this Queue<T> queue, uint quantity)
        {
            var list = new List<T>((int) quantity);
            if (quantity is 0)
                return list;
            if (queue.Count < quantity)
                quantity = (uint) queue.Count;
            for (var index = 0; index < quantity; index++)
                list.Add(queue.Dequeue());
            return list;
        }
    }
}
