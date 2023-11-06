using System.Diagnostics.CodeAnalysis;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
public abstract class ExtensibleDictionary<TKey, TValue>: ExtensibleCollection<KeyValuePair<TKey, TValue>>, IExtensibleDictionary<TKey, TValue>
{
    private readonly IDictionary<TKey, TValue> _dictionary;

    public ExtensibleDictionary(IDictionary<TKey, TValue> dictionary): base(dictionary)
    {
        _dictionary = dictionary;
    }

    public override abstract IExtensibleDictionary<TKey, TValue> ShallowCopy();

    #region Delegated
    public virtual bool ContainsKey(TKey key)
    {
        return _dictionary.ContainsKey(key);
    }

    public virtual bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    public virtual void Add(TKey key, TValue value)
    {
        _dictionary.Add(key, value);
    }

    public virtual bool Remove(TKey key)
    {
        return _dictionary.Remove(key);
    }

    public virtual ICollection<TKey> Keys => _dictionary.Keys;

    public virtual ICollection<TValue> Values => _dictionary.Values;

    public virtual TValue this[TKey key] { get => _dictionary[key]; set => _dictionary[key] = value; }

    #endregion Delegated
}
