using System.Collections;

namespace Woody230.Collections.Generic.Lookup;

/// <summary>
/// Wraps the <paramref name="groupings"/> as a <see cref="ILookup{TKey, TElement}"/>.
/// </summary>
internal sealed class GroupedLookup<TKey, TValue>(IEnumerable<IGrouping<TKey, TValue>> groupings): ILookup<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, IGrouping<TKey, TValue>> _dictionary = groupings.ToDictionary(grouping => grouping.Key);

    /// <inheritdoc/>
    public IEnumerable<TValue> this[TKey key] => _dictionary.TryGetValue(key, out var grouping) ? grouping : [];

    /// <inheritdoc/>
    public int Count => _dictionary.Count;

    /// <inheritdoc/>
    public bool Contains(TKey key) => _dictionary.ContainsKey(key);

    /// <inheritdoc/>
    public IEnumerator<IGrouping<TKey, TValue>> GetEnumerator() => _dictionary.Values.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
