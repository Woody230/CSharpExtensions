using System.Collections.Generic;
using System.Linq;

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

    public override ExtendedList<T> ShallowCopy()
    {
        var list = new List<T>(this);
        return new ExtendedList<T>(list);
    }

    #region Operators
    public static ExtendedList<T> operator +(ExtendedList<T> @this, IEnumerable<T> other) => @this.Plus(other);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, IEnumerable<T> other) => @this.Minus(other);
    public static ExtendedList<T> operator +(ExtendedList<T> @this, T item) => @this.Plus(item);
    public static ExtendedList<T> operator -(ExtendedList<T> @this, T item) => @this.Minus(item);
    #endregion Operators
}
