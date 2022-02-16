# DatabaseExtensions

Helpers for working with databases.

# Extensions methods
* ### AddParameters

Adds a dictionary with parameters to the IDbCommand.

`static void AddParameters(this IDbCommand command, IDictionary<string, object> parameters)`

_Example_
 ```
IDbCommand command; (FbCommand, SqlCommand...)
var parameters = new Dictionary<string, object>
{
  {"id", 1},
  {"name", "Eduardo"},
  {"age", 20}
};
command.AddParameters(parameters);
```
