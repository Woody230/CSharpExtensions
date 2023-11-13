![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Caching.Memory)](https://www.nuget.org/packages/Woody230.Caching.Memory)

# Caching.Memory
 
Extensions for a Microsoft.Extensions.Caching.Memory.MemoryCache.

## Caches

| Name | Description | 
| --- | --- |
| GenericMemoryCache | A typed wrapper around the Microsoft.Extensions.Caching.Memory.MemoryCache. |
| PrefixedMemoryCache | Adds a prefix to string keys. |
| StringifiedMemoryCache | The key can be any type, but the underlying key stored to the memory cache is converted to a string. |