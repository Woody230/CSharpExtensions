namespace Woody230.Collections.Extensible.Generic;

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
}
