using Woody230.Collections.Generic.Lookup;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents extensions for a <see cref="IGrouping{TKey, TElement}"/>.
/// </summary>
public static class GroupingExtensions
{
    /// <summary>
    /// Wraps the <paramref name="values"/> as a <see cref="IGrouping{TKey, TElement}"/> for <paramref name="key"/>.
    /// </summary>
    public static IGrouping<TKey, TValue> ToGrouping<TKey, TValue>(this IEnumerable<TValue> values, TKey key)
    {
        return new Grouping<TKey, TValue>(key, values);
    }
}
