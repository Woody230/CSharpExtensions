using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <summary>
/// Represents a <see cref="ISet{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleSet<T> : IExtensibleCollection<T>, ISet<T>
{
    #region Operators
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return @this;
    }
    public static IExtensibleSet<T> operator +(IExtensibleSet<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }
    public static IExtensibleSet<T> operator -(IExtensibleSet<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}