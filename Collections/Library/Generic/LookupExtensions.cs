using Woody230.Collections.Generic.Lookup;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for a <see cref="ILookup{TKey, TValue}"/>.
/// </summary>
public static class LookupExtensions
{
    /// <summary>
    /// Wraps the <paramref name="groupings"/> as a <see cref="ILookup{TKey, TElement}"/>.
    /// </summary>
    public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings) where TKey : notnull
    {
        return new GroupedLookup<TKey, TValue>(groupings);
    }

    /// <summary>
    /// Wraps the <paramref name="dictionary"/> as a <see cref="ILookup{TKey, TElement}"/>.
    /// </summary>
    public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IDictionary<TKey, IEnumerable<TValue>> dictionary) where TKey : notnull
    {
        var groupings = dictionary.Select(pair => new Grouping<TKey, TValue>(pair.Key, pair.Value));
        return new GroupedLookup<TKey, TValue>(groupings);
    }
}
