# Class `Queue<T>`

A better `Queue<T>` class.

# New methods
* ### EnqueueEnumerable

Adds each value of an enumerable to the end of the Queue<T>.

`void EnqueueEnumerable(IEnumerable<T> enumerable)`

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
* ### DequeueEnumerable

Dequeues a given amount of values at the beginning of the Queue<T> and returns them as a enumerable.

`IEnumerable<T> DequeueEnumerable(int quantity)`

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
 actual.DequeueEnumerable(2);
 Assert.Equal(expected, actual);
```

# Class `LimitedQueue<T>`

One queue with limit with the same methods as this library's common Queue.

# Questions?

The best place to be you use to learn about QueueExtensions is the [test folder of the QueueExtensions](https://github.com/eduardosilva218/PrancingPonySharp/tree/main/PrancingPonySharp.QueueExtensions.Test)
