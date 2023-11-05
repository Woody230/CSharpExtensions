using System.Collections.Generic;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedList<T>: ExtensibleList<T>
{
    public ExtendedList(IList<T> list) : base(list)
    {
    }

    public ExtendedList(): base()
    {
    }

    #region Operators
    public static ExtendedList<T> operator +(ExtendedList<T> @this, IEnumerable<T> other)
    {
        @this.AddAll(other);
        return @this;
    }
    public static ExtendedList<T> operator -(ExtendedList<T> @this, IEnumerable<T> other)
    {
        @this.RemoveAll(other);
        return @this;
    }
    public static ExtendedList<T> operator +(ExtendedList<T> @this, T item)
    {
        @this.Add(item);
        return @this;
    }
    public static ExtendedList<T> operator -(ExtendedList<T> @this, T item)
    {
        @this.Remove(item);
        return @this;
    }
    #endregion Operators
}
