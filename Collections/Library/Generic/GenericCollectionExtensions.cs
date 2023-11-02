using System;
using System.Collections.Generic;
using System.Linq;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for generic collections.
/// </summary>
public static class GenericCollectionExtensions
{
    /// <summary>
    /// Adds each item in the <paramref name="other"/> collection to <paramref name="this"/> collection.
    /// </summary>
    public static TCollection AddAll<T, TCollection>(this TCollection @this, IEnumerable<T> other) where TCollection : ICollection<T>
    {
        foreach (var item in other)
        {
            @this.Add(item);
        }

        return @this;
    }

    /// <summary>
    /// Removes each item in the <paramref name="other"/> collection from <paramref name="this"/> collection.
    /// </summary>
    public static TCollection RemoveAll<T, TCollection>(this TCollection @this, IEnumerable<T> other) where TCollection: ICollection<T>
    {
        foreach (var item in other)
        {
            @this.Remove(item);
        }

        return @this;
    }

    /// <summary>
    /// Applies the <paramref name="action"/> to each item in the collection.
    /// </summary>
    public static TEnumerable ForEach<T, TEnumerable>(this TEnumerable @this, Action<T> action) where TEnumerable : IEnumerable<T>
    {
        foreach (var item in @this)
        {
            action(item);
        }

        return @this;
    }

    /// <summary>
    /// Determines whether all items in the <paramref name="other"/> collection are contained in <paramref name="this"/> collection.
    /// </summary>
    public static bool ContainsAll<T, TCollection>(this TCollection @this, IEnumerable<T> other) where TCollection : ICollection<T>
    {
        return other.All(item => @this.Contains(item));
    }

    /// <summary>
    /// Determines whether <paramref name="this"/> collection is null or has no items.
    /// </summary>
    public static bool IsNullOrEmpty<T, TEnumerable>(this TEnumerable @this) where TEnumerable : IEnumerable<T>
    {
        return @this == null || !@this.Any();
    }

    /// <summary>
    /// Filters <paramref name="this"/> collection based on the <paramref name="filter"/> being false.
    /// </summary>
    /// <returns>A new collection with items that did not pass the <paramref name="filter"/>.</returns>
    public static IEnumerable<T> WhereNot<T, TEnumerable>(this TEnumerable @this, Func<T, bool> filter) where TEnumerable: IEnumerable<T>
    {
        return @this.Where(item => !filter(item));
    }
}
