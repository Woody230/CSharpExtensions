namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IDictionary{TKey, TValue}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
public interface IExtensibleDictionary<TKey, TValue>: IExtensibleCollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
{
    /// <summary>
    /// Creates a new instance of the collection.
    /// </summary>
    public new IExtensibleDictionary<TKey, TValue> ShallowCopy();

    IExtensibleCollection<KeyValuePair<TKey, TValue>> IExtensibleCollection<KeyValuePair<TKey, TValue>>.ShallowCopy() => ShallowCopy();

    #region Operators
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.Plus(other);
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> other) => @this.Minus(other);
    public static IExtensibleDictionary<TKey, TValue> operator +(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item) => @this.Plus(item);
    public static IExtensibleDictionary<TKey, TValue> operator -(IExtensibleDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> item) => @this.Minus(item);
    #endregion Operators
}
