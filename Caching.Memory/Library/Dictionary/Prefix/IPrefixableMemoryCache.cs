﻿using System.Diagnostics.CodeAnalysis;

namespace Woody230.Caching.Memory;

/// <summary>
/// Represents a memory cache with a prefixed key. 
/// </summary>
public interface IPrefixableMemoryCache<TKey, TValue>: IGenericMemoryCache<TKey, TValue>
{
}