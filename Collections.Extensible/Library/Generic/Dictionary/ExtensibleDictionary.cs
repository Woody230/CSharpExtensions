using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <typeparam name="TCollection">The type of the implementation of the interface.</typeparam>
public abstract class ExtensibleDictionary<TKey, TValue, TCollection>: ExtensibleCollection<KeyValuePair<TKey, TValue>, TCollection>, IExtensibleDictionary<TKey, TValue, TCollection> , IDictionary<TKey, TValue>
    where TCollection: ExtensibleDictionary<TKey, TValue, TCollection>
    where TKey: notnull
{
    private readonly IDictionary<TKey, TValue> _dictionary;

    public ExtensibleDictionary(IDictionary<TKey, TValue> dictionary): base(dictionary)
    {
        _dictionary = dictionary;
    }

    public ExtensibleDictionary(): this(new Dictionary<TKey, TValue>())
    {
    }

    #region Delegation
    public ICollection<TKey> Keys => _dictionary.Keys;

    public ICollection<TValue> Values => _dictionary.Values;

    public TValue this[TKey key] { get => _dictionary[key]; set => _dictionary[key] = value; }

    public void Add(TKey key, TValue value)
    {
        _dictionary.Add(key, value);
    }

    public bool ContainsKey(TKey key)
    {
        return _dictionary.ContainsKey(key);
    }

    public bool Remove(TKey key)
    {
        return _dictionary.Remove(key);
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        return _dictionary.TryGetValue(key, out value);
    }
    #endregion Delegation
}
