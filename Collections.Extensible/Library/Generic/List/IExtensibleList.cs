using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleList<T> : IExtensibleCollection<T>, IList<T>
{
    /// <summary>
    /// Creates a new instance of the collection.
    /// </summary>
    public new IExtensibleList<T> ShallowCopy();

    IExtensibleCollection<T> IExtensibleCollection<T>.ShallowCopy() => ShallowCopy();

    #region Operators
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveAll(other);
        return copy;
    }
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Remove(item);
        return copy;
    }
    #endregion Operators
}