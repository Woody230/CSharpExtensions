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

    public override ExtendedList<T> ShallowCopy()
    {
        var list = new List<T>(this);
        return new ExtendedList<T>(list);
    }

    #region Operators
    public static ExtendedList<T> operator +(ExtendedList<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }
    public static ExtendedList<T> operator -(ExtendedList<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveAll(other);
        return copy;
    }
    public static ExtendedList<T> operator +(ExtendedList<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }
    public static ExtendedList<T> operator -(ExtendedList<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Remove(item);
        return copy;
    }
    #endregion Operators
}
