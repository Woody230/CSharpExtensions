using System.Collections.Generic;
using System.Linq;
using Woody230.Collections.Generic;

namespace Woody230.Collections.Extensible.Generic;

/// <inheritdoc/>
public sealed class ExtendedSet<T>: ExtensibleSet<T>
{
    public ExtendedSet(IEnumerable<T> collection): this(collection.ToHashSet())
    {
    }

    public ExtendedSet(ISet<T> set): base(set)
    {
    }

    public ExtendedSet(): this(new HashSet<T>())
    {
    }

    public override ExtendedSet<T> ShallowCopy()
    {
        var set = new HashSet<T>(this);
        return new ExtendedSet<T>(set);
    }

    #region Operators
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.AddAll(other);
        return copy;
    }
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, IEnumerable<T> other)
    {
        var copy = @this.ShallowCopy();
        copy.RemoveAll(other);
        return copy;
    }
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Add(item);
        return copy;
    }
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, T item)
    {
        var copy = @this.ShallowCopy();
        copy.Remove(item);
        return copy;
    }

    #endregion Operators
}
