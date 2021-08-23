# About the implementation of maybe in this project 

The implementation of [maybe](https://www.nuget.org/packages/PrancingPonySharp.Maybe) in this project aims to encapsulate values to prevent null references from happening.

`struct Maybe<T>`

_Example_

```string name = null``` 

if you try to use this as if it were a string, you'll have a null reference problem. And many developers tend to forget cases like that.

**But how to solve this?**

According to Tony Hoare himself, the null problem is not itself, but its implementation, which does not force the programmer to deal with it if it is null, causing problems at runtime. Therefore, part of the behavior of the Haskell option of Rust and Maybe of Haskell was mimicked to create a simple data structure, that would force the programmer to handle the null case if he wanted to use the encapsulated value, thus avoiding the problem as much as possible.

So encapsulate the string in maybe and the only way to use it now is to go through the match methods, which avoid the null reference.

```Maybe<string> maybeName = null```

If you try to use this you will be forced to uncap and therefore treat if it is null.

```
maybeName.Matches(
  a: name => Console.WriteLine(name), 
  or: () => Console.WriteLine("is null value"))
```
_or_
```
Console.WriteLine(maybeName.Matches(
  a: name => name, 
  or: () => "is null value");
```

# Methods of Maybe Struct
* ### Matches

Accepts two delegates that return the type passed, one to handle if the value exists, the other if it is null.

`TR Matches<TR>(Func<T, TR> a, Func<TR> or)`

Or do the same, but with no return.

`void Matches(Action<T> a, Action or)`

_Example_
 ```
maybeName.Matches(
  a: name => Console.WriteLine(name), 
  or: () => Console.WriteLine("is null value"))
```
_or_
```
Console.WriteLine(maybeName.Matches<string>(
  a: name => name, 
  or: () => "is null value");
```
  
# Related methods
* ### Wrap

Wrap an T data and return a Maybe Struct.

`static Maybe<T> Wrap<T>(this T value)`

_Example_
```
string name = "Eduardo";
Maybe<string> maybeName = name.Wrap();
```

* ### UnwrapOrThrowException

UnwrapOrThrowException tries to unwrap the value encapsulated or throw an Exception. By default the exception is an InvalidOperationException with the message.
Or choose the exception for the error in the method parameter.

`static T UnwrapOrThrowException<T>(this Maybe<T> ifValue, Exception exception = null)`

_Example_
```
try{
   Maybe<string> maybeName = null;
   var name = maybeName.UnwrapOrThrowException() // throw exception, because maybeName is null
}
catch(InvalidOperationException){
    ...
}
```
_or_
```
try{
   Maybe<string> maybeName = "Eduardo";
   var name = maybeName.UnwrapOrThrowException() // return "Eduardo", because maybeName is not null
}
catch(InvalidOperationException){
    ...
}
```

* ### UnwrapOr
UnwrapOr the encapsulated value or return the parameter value.

`static T UnwrapOr<T>(this Maybe<T> ifValue, T defaultValue)`

_Example_
```
Maybe<string> maybeName = "Eduardo";
var nameOrStringEmpty = maybeName.UnwrapOr(defaultValue: string.Empty);
```

* ### ApplyFunctionIfItHasValueOrThrowException
Apply a function on the value and if it is null throws an exception.

`static void ApplyFunctionIfItHasValueOrThrowException<T>(this Maybe<T> ifValue, Action<T> functionIfItHasValue,
            Exception exception = null`

_Example_
```
try{
   Maybe<string> maybeName = null;
   maybeName.ApplyFunctionIfItHasValueOrThrowException(
    functionIfItHasValue: (name) => Console.Write(name)); // throw exception, because maybeName is null
}
catch(InvalidOperationException){
    ...
}
```
_or_
```
try{
   Maybe<string> maybeName = "Eduardo";
   maybeName.ApplyFunctionIfItHasValueOrThrowException(
    functionIfItHasValue: (name) => Console.Write(name)); // write in console "Eduardo", because maybeName is not null
}
catch(InvalidOperationException){
    ...
}
```

* ### ApplyFunctionOrDoNothing
Apply a function to the value and if it is null it does nothing.

`static void ApplyFunctionOrDoNothing<T>(this Maybe<T> ifValue, Action<T> function)`

_Example_
```
try{
   Maybe<string> maybeName = null;
   maybeName.ApplyFunctionOrDoNothing(
    functionIfItHasValue: (name) => Console.Write(name)); // does nothing, because maybeName is null
}
catch(InvalidOperationException){
    ...
}
```
_or_
```
try{
   Maybe<string> canName = "Eduardo";
   maybeName.ApplyFunctionOrDoNothing(
    functionIfItHasValue: (name) => Console.Write(name)); // did nothing, because maybeName is not null
}
catch(InvalidOperationException){
    ...
}
```

# References and inspirations
- Null References: The Billion Dollar Mistake - Tony Hoare
- Option RustLang doc
- Maybe Haskell doc
- Optional Java doc
- ElemarJR.FunctionalCSharp
