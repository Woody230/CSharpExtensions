using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedDictionary<TKey, TValue> : ExtensibleDictionary<TKey, TValue> where TKey: notnull
{
    public ExtendedDictionary(): base(new Dictionary<TKey, TValue>())
    {
    }

    public ExtendedDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
    }

    #region Operators
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other)
    {
        @this.RemoveKeys(other);
        return @this;
    }
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return @this;
    }
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.RemoveKey(item);
        return @this;
    }
    #endregion Operators
}
