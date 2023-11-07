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
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.Plus(other);
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.Minus(other);
    public static ExtendedDictionary<TKey, TValue> operator +(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item) => @this.Plus(item);
    public static ExtendedDictionary<TKey, TValue> operator -(ExtendedDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item) => @this.Minus(item);
    #endregion Operators
}
