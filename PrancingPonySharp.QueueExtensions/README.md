# Extensions to Queue in .NET

Some methods that improve the use of `Queue<T>` in .NET.

# Extension methods
* ### EnqueueEnumerable

Adds each value of an enumerable to the end of the Queue<T>.

`static void EnqueueEnumerable<T>(this Queue<T> queue, IEnumerable<T> enumerable)`

_Example_
 ```
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
```
* ### Dequeue

Dequeues a given amount of values at the beginning of the Queue<T> and returns them as a enumerable.

`static IEnumerable<T> Dequeue<T>(this Queue<T> queue, int quantity)`

_Example_
 ```
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
```

# Questions?

The best place to be you use to learn about QueueExtensions is the [test folder of the QueueExtensions](https://github.com/eduardosilva218/PrancingPonySharp/tree/main/PrancingPonySharp.QueueExtensions.Test)
