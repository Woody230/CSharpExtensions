using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents extensions for the <see cref="IExtensibleDictionary{TKey, TValue}"/>.
/// </summary>
public static class ExtensibleDictionaryExtensions
{
    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Removes each key value pair in the <paramref name="other"/> collection from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TDictionary Minus<TKey, TValue, TDictionary>(this TDictionary @this, IEnumerable<KeyValuePair<TKey, TValue>> other) where TDictionary : IExtensibleDictionary<TKey, TValue>
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKeys(other);
        return (TDictionary)copy;
    }

    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Removes the <paramref name="item"/> from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TDictionary Minus<TKey, TValue, TDictionary>(this TDictionary @this, KeyValuePair<TKey, TValue> item) where TDictionary : IExtensibleDictionary<TKey, TValue>
    {
        var copy = @this.ShallowCopy();
        copy.RemoveKey(item);
        return (TDictionary)copy;
    }
}
