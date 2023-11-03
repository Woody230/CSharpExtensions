using System.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic.Dictionary;

/// <inheritdoc/>
public sealed class ExtendedDictionary<TKey, TValue> : ExtensibleDictionary<TKey, TValue, ExtendedDictionary<TKey, TValue>> where TKey: notnull
{
    public ExtendedDictionary(): base()
    {
    }

    public ExtendedDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
    }
}
