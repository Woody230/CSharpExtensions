![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Collections.Extensible)](https://www.nuget.org/packages/Woody230.Collections.Extensible)

# Collections.Extensible

Custom collections extending System.Collections.

## Custom Collections

| Name | Description |
| --- | --- |
| ExtendedDictionary | Wrapper of an IDictionary`<TKey, TValue>`. |
| LenientDictionary | Replaces existing values when adding duplicates instead of throwing an exception. |
| ExtendedList | Wrapper of an IList`<T>`. | 
| ExtendedSet | Wrapper of an ISet`<T>`. |

## Operators
The interfaces and implementations of the custom collections have `+` and `-` operators to add or remove items from another collection or to add or remove a single item.

```c#
var merged = new ExtendedList<int>() { 5, 8, 13 } + new ExtendedList<int>() { 9, 13, 17 };

// new ExtendedList<int>() { 5, 8, 13, 9, 13, 17 }
```