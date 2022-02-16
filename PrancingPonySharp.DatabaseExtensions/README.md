# DatabaseExtensions

Helpers for working with databases.

# Extensions methods of IDbCommand
* ### AddParameters

Adds a `IEnumerable<IDbDataParameter>` to the `IDbCommand`.

`static void AddParameters(this IDbCommand command, IEnumerable<IDbDataParameter> parameters)`

_Example_
 ```
dbCommandMock.Object.AddParameters(
new Dictionary<string, object>
{
    {"x", 1},
    {"y", 2}
}.ConvertToParameters(dbCommandMock.Object));
```

# Extensions methods of IDictionary<string, object>
* ### ConvertToParameters

Convert a `IDictionary<string, object>` to the `IEnumerable<IDbDataParameter>`.

`static IEnumerable<IDbDataParameter> ConvertToParameters(this IDictionary<string, object> parameterDictionary, IDbCommand command)`

_Example_
 ```
var parameterDictionary = new Dictionary<string, object>
{
    {"x", 1},
    {"y", 2}
};
var expected = parameterDictionary.Select(parameter =>
{
    var dataParameter = dbCommandMock.Object.CreateParameter();
    var (key, value) = parameter;
    dataParameter.ParameterName = key;
    dataParameter.Value = value;
    return dataParameter;
});
Assert.Equal(expected, parameterDictionary.ConvertToParameters(dbCommandMock.Object));
```
