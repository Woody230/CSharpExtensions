using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleList<T> : IExtensibleCollection<T>, IList<T>
{
    #region Operators
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return @this;
    }
    public static IExtensibleList<T> operator +(IExtensibleList<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleList<T> operator -(IExtensibleList<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}