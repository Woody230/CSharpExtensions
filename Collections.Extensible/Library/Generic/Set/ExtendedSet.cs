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
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, IEnumerable<T> other) => @this.Plus(other);
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, IEnumerable<T> other) => @this.Minus(other);
    public static ExtendedSet<T> operator +(ExtendedSet<T> @this, T item) => @this.Plus(item);
    public static ExtendedSet<T> operator -(ExtendedSet<T> @this, T item) => @this.Minus(item);

    #endregion Operators
}
