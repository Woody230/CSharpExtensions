using System.Collections.Generic;
using System.Linq;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedList<T>: ExtensibleList<T>
{
    public ExtendedList(IEnumerable<T> collection): this(collection.ToList())
    {
    }

    public ExtendedList(IList<T> list) : base(list)
    {
    }

    public ExtendedList(): this(new List<T>())
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
