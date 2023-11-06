using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents extensions for the <see cref="IExtensibleCollection{T}"/>.
/// </summary>
public static class ExtensibleCollectionExtensions
{
    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Adds each item in the <paramref name="other"/> collection to a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TEnumerable Plus<T, TEnumerable>(this TEnumerable @this, IEnumerable<T> other) where TEnumerable : IExtensibleCollection<T>
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return (TEnumerable)copy;
    }

    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Removes each item in the <paramref name="other"/> collection from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TEnumerable Minus<T, TEnumerable>(this TEnumerable @this, IEnumerable<T> other) where TEnumerable: IExtensibleCollection<T>
    {
        var copy = @this.ShallowCopy();
        copy.RemoveAll(other);
        return (TEnumerable)copy;
    }

    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Adds the <paramref name="item"/> to a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TEnumerable Plus<T, TEnumerable>(this TEnumerable @this, T item) where TEnumerable : IExtensibleCollection<T>
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return (TEnumerable)copy;
    }

    /// <summary>
    /// <para>INTENDED FOR OPERATOR OVERLOADING</para>
    /// Removes the <paramref name="item"/> from a copy of <paramref name="this"/> collection.
    /// </summary>
    public static TEnumerable Minus<T, TEnumerable>(this TEnumerable @this, T item) where TEnumerable: IExtensibleCollection<T>
    {
        var copy = @this.ShallowCopy();
        copy.Remove(item);
        return (TEnumerable)copy;
    }
}
