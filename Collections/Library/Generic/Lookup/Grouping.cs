using System.Collections;

namespace Woody230.Collections.Generic.Lookup;

/// <summary>
/// Represents a grouping of the <paramref name="key"/> to the <paramref name="values"/>
/// </summary>
internal sealed class Grouping<TKey, TValue>(TKey key, IEnumerable<TValue> values) : IGrouping<TKey, TValue>
{
    /// <inheritdoc/>
    public TKey Key { get; } = key;

    /// <inheritdoc/>
    public IEnumerator<TValue> GetEnumerator() => values.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
