using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedSet<T>: ExtensibleSet<T, ExtendedSet<T>>
{
    public ExtendedSet(ISet<T> set): base(set)
    {
    }

    public ExtendedSet(): base()
    {
    }


    #region Operators
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, IEnumerable<T> other) => @this.AddAll(other);
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, T item) => @this.Add(item);
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, T item) => @this.Remove(item);
    #endregion Operators
}
