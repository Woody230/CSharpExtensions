using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedDictionary<TKey, TValue> : ExtensibleDictionary<TKey, TValue> where TKey: notnull
{
    public ExtendedDictionary(): this(new Dictionary<TKey, TValue>())
    {
    }

    public ExtendedDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
    }

    public override ExtendedDictionary<TKey, TValue> ShallowCopy()
    {
        var dictionary = new Dictionary<TKey, TValue>(this);
        return new ExtendedDictionary<TKey, TValue>(dictionary);
    }

    #region Operators
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKeys(other);
        return copy;
    }
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKey(item);
        return copy;
    }
    #endregion Operators
}
