![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Collections)](https://www.nuget.org/packages/Woody230.Collections)

# Collections

Extensions for the System.Collections namespace.

## Generic

| Type | Method Name |
| --- | --- | 
| ICollection`<T>` | AddAll |
| ICollection`<T>` | RemoveAll |
| IEnumerable`<T>` | ForEach |
| IEnumerable`<T>` | ForEachIndexed |
| IEnumerable`<T>` | WithIndex |
| ICollection`<T>` | ContainsAll |
| IEnumerable`<T>` | IsNullOrEmpty |
| IEnumerable`<T>` | IsNotNullOrEmpty |
| IEnumerable`<T>` | WhereNot |
| IEnumerable`<T>` | WhereNull |
| IEnumerable`<T>` | WhereNotNull |
| IEnumerable`<T>` | WhereDefault |
| IEnumerable`<T>` | WhereNotDefault |
| IEnumerable`<T>` | WhereInstanceOf |
| IEnumerable`<T>` | None |
| IEnumerable`<T>` | JoinToString |

## Dictionary

| Type | Method Name |
| --- | --- | 
| IEnumerable`<(TKey, TValue)>` | ToDictionary |
| IDictionary`<TKey, TValue>` | RemoveKeys |
| IDictionary`<TKey, TValue>` | RemoveKey |
| IDictionary`<TKey, TValue>` | Put |
| IDictionary`<TKey, TValue>` | PutAll |
| IDictionary`<TKey, TValue>` | SelectKeys |
| IDictionary`<TKey, TValue>` | SelectValues |

## Lookup

| Type | MethodName |
| --- | --- |
| IEnumerable<IGrouping`<TKey, TValue>`> | ToLookup |
| IDictionary`<TKey, IEnumerable<TValue>>` | ToLookup |

## Grouping

| Type | Method Name |
| --- | --- |
| IEnumerable`<TValue>` | ToGrouping |