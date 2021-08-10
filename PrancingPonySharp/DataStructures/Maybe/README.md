# About the implementation of maybe in this project 

The implementation of maybe in this project aims to encapsulate values to prevent null references from happening.

`struct Maybe<T>`

* Example

```string name = null``` 

if you try to use this as if it were a string, you'll have a null reference problem. And many developers tend to forget cases like that.

**But how to solve this?**

According to Tony Hoare himself, the null problem is not itself, but its implementation, which does not force the programmer to deal with it if it is null, causing problems at runtime. Therefore, part of the behavior of the Haskell option of Rust and Maybe of Haskell was mimicked to create a simple data structure, that would force the programmer to handle the null case if he wanted to use the encapsulated value, thus avoiding the problem as much as possible.

So encapsulate the string in maybe and the only way to use it now is to go through the match methods, which avoid the null reference.

```Maybe<string> ifName = null```

If you try to use this you will be forced to uncap and therefore treat if it is null.

```
ifName.Matches(
  a: name => Console.WriteLine(name), 
  or: () => Console.WriteLine("is null value"))
```
or
```
Console.WriteLine(ifName.Matches<string>(
  a: name => name, 
  or: () => "is null value");
```

# Methods of Maybe Struct
### Matches

Accepts two delegates that return the type passed, one to handle if the value exists, the other if it is null.

`TR Matches<TR>(Func<T, TR> a, Func<TR> or)`

Or do the same, but with no return.

`void Matches(Action<T> a, Action or)`

Example
 ```
ifName.Matches(
  a: name => Console.WriteLine(name), 
  or: () => Console.WriteLine("is null value"))
```
or
```
Console.WriteLine(ifName.Matches<string>(
  a: name => name, 
  or: () => "is null value");
```
  
# Related methods
### Wrap

Wrap an T data and return a Maybe Struct.

`static Maybe<T> Wrap<T>(this T value)`

Example
```
string name = "Eduardo";
Maybe<string> ifName = name.Wrap();
```

### TryUnwrap

TryUnwrap tries to unwrap the value encapsuled or throw an Exception. By default the exception is an InvalidOperationException with the message 

```
Accessed Maybe<T>. Value when IsValue is false. Use Maybe<T>.UnwrapOr instead of Maybe<T>.Value
```
or choose the exception for the error in the method parameter.

`static T TryUnwrap<T>(this Maybe<T> ifValue, Exception exception = null)`

Example
```
try{
   Maybe<string> ifName = null;
   var name = ifName.TryUnwrap() // throw exception, because ifName is null
}
catch(InvalidOperationException){
    ...
}
```
```
try{
   Maybe<string> ifName = "Eduardo";
   var name = ifName.TryUnwrap() // return "Eduardo"
}
catch(InvalidOperationException){
    ...
}
```

### UnwrapOr
Unwrap the encapsulated value or return the parameter value.

`static T UnwrapOr<T>(this Maybe<T> ifValue, T or)`

Example
```
Maybe<string> ifName = "Eduardo";
var nameOrStringEmpty = ifName.UnwrapOr(string.Empty);
```

# References 
- Null References: The Billion Dollar Mistake - Tony Hoare
- Option RustLang doc
- Maybe Haskell doc
- Optional Java doc
- ElemarJR.FunctionalCSharp
