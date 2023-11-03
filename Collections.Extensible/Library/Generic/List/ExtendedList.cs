using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedList<T>: ExtensibleList<T, ExtendedList<T>>
{
    public ExtendedList(IList<T> list) : base(list)
    {
    }

    public ExtendedList(): base()
    {
    }

    #region Operators
    public static ExtendedList<T> operator +(ExtendedList<T> @this, IEnumerable<T> other) => @this.AddAll(other);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, IEnumerable<T> other) => @this.RemoveAll(other);
    public static ExtendedList<T> operator +(ExtendedList<T> @this, T item) => @this.Add(item);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, T item) => @this.Remove(item);
    #endregion Operators
}
