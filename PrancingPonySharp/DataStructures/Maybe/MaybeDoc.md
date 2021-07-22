# About the implementation of maybe in this project
The implementation of maybe in this project aims to encapsulate values to prevent null references from happening.

* Example

`string name = null` 
if you try to use this as if it were a string, you'll have a null reference problem. And many developers tend to forget cases like that.
* But how to solve this? 
According to Tony Hoare himself, the null problem is not itself, but its implementation, which does not force the programmer to deal with it if it is null, causing problems at runtime. Therefore, part of the behavior of the Haskell option of Rust and Maybe of Haskell was mimicked to create a simple data structure that would force the programmer to handle the null case if he wanted to use the encapsulated value, thus avoiding the problem as much as possible.

So encapsulate the string in maybe and the only way to use it now is to go through the match methods, which avoid the null reference.
`Maybe<string> maybeName = null`
If you try to use this you will be forced to uncap and therefore treat if it is null.
`maybeName.Match(just: name => Console.WriteLine(name), nothing: () => Console.WriteLine("is null value"))`
or
`Console.WriteLine(maybeName.Match<string>(just: name => name, nothing: () => "is null value");`

# References 
- Null References: The Billion Dollar Mistake - Tony Hoare
- Option rust doc
- Haskell Maybe doc
