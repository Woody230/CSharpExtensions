using System.Collections.Generic;
using Woody230.Collections.Generic;

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

    #region Operators
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.AddAll(other);
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.RemoveAll(other);
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Add(item);
        return @this;
    }
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}
